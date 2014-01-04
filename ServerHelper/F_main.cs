using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerHelperDll;

namespace ServerHelper
{
    public partial class F_main : Form
    {
        public F_main()
        {
            InitializeComponent();
            LoadConfig();

            SetApachesStatus();
        }

        private void b_newWebSave_Click(object sender, EventArgs e)
        {
            SaveConfig();

            if (tb_newWebDomain.Text.Length > 2 && tb_newWebFolder.Text.Length > 2)
            {
                SaveNewWeb(tb_htDocsPath.Text, tb_newWebDomain.Text, tb_newWebFolder.Text);
            }

            RestartInputs();
            if (chb_newWebRestartApache.Checked) RestartAppache();
        }

        private void SaveConfig()
        {
            string apachePath = tb_apacheFolderPath.Text;
            string htDocsPath = tb_htDocsPath.Text;
            string hostPath = tb_hostPath.Text;

            _fileHelper.SaveConfig(ref apachePath, ref htDocsPath, ref hostPath);

            tb_apacheFolderPath.Text = apachePath;
            tb_htDocsPath.Text = htDocsPath;
            tb_hostPath.Text = hostPath;
        }

        private void LoadConfig()
        {
            if (_fileHelper.ReadConfig())
            {
                tb_apacheFolderPath.Text = _fileHelper.ApachePath;
                tb_htDocsPath.Text = _fileHelper.HtDocsPath;
                tb_hostPath.Text = _fileHelper.HostPath;
            }
        }

        private void RestartInputs()
        {
            tb_newWebDomain.Text = _EMPTY;
            tb_newWebFolder.Text = _EMPTY;
        }

        private void RestartAppache()
        {
            ServicesHelper apache2_2 = new ServicesHelper(ServicesHelper.APPACHE2_2);
            ServicesHelper apache2_4 = new ServicesHelper(ServicesHelper.APPACHE2_4);

            ChangeButtonText(b_newWebSave, _RESTARTING, false);

            if (apache2_2.isRunning())
            {
                if (apache2_2.RestartService())
                {
                    // restart hotov
                    ChangeButtonText(b_newWebSave, b_newWebSave.Tag.ToString(), true);
                }
            }
            else if (apache2_4.isRunning())
            {
                if (apache2_4.RestartService())
                {
                    // restart hotov
                    ChangeButtonText(b_newWebSave, b_newWebSave.Tag.ToString(), true);
                }
            }

            SetApachesStatus();
        }

        private void SetApachesStatus()
        {
            SetApacheStatus(ServicesHelper.APPACHE2_2, l_apache_2_2_status);
            SetApacheStatus(ServicesHelper.APPACHE2_4, l_apache2_4_status);
        }

        private void SetApacheStatus(string apacheName, Label statusLabel)
        {
            ServicesHelper apache = new ServicesHelper(apacheName);

            statusLabel.Text = apache.isRunning() ? _OK : _STOP;
        }

        private void SaveNewWeb(string htDocsPath, string domain, string folder)
        {
            _fileHelper.SaveNewWeb(htDocsPath, domain, folder);
        }

        private void b_switchApache_Click(object sender, EventArgs e)
        {
            ServicesHelper apache2_2 = new ServicesHelper(ServicesHelper.APPACHE2_2);
            ServicesHelper apache2_4 = new ServicesHelper(ServicesHelper.APPACHE2_4);

            ChangeButtonText(b_switchApache, _SWITCHING, false);

            if (apache2_2.isRunning())
            {
                if (apache2_2.StopService())
                {
                    apache2_4.StartService();
                }
            }
            else if (apache2_4.isRunning())
            {
                if (apache2_4.StopService())
                {
                    apache2_2.StartService();
                }
            }

            ChangeButtonText(b_switchApache, b_switchApache.Tag.ToString(), true);

            SetApachesStatus();
        }

        private void ChangeButtonText(Button button, string text, bool enabled)
        {
            button.Tag = button.Text;
            button.Text = text;
            button.Enabled = enabled;
        }

        private void b_showServices_Click(object sender, EventArgs e)
        {
            ServicesHelper.ShowServicesWindow();
        }

        private FileHelper _fileHelper = FileHelper.Instance;

        private const string _RESTARTING = "Restartuji ...";
        private const string _OK = "OK";
        private const string _STOP = "STOP";
        private const string _EMPTY = "";
        private const string _SWITCHING = "Přepíná";
    }
}
