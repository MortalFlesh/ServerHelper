using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using ServerHelperDll.Logs;
using ServerHelperDll.Checkers;

namespace ServerHelperDll
{
    public class FileHelper
    {
        /// <summary>
        /// Vrátí instanci Singletonu
        /// </summary>
        public static FileHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Zapíše cesty do konfiguračního XML souboru
        /// </summary>
        /// <param name="apachePath">Cesta k rootu apache</param>
        /// <param name="htDocsPath">Cesta do htDocs</param>
        /// <param name="hostPath">Cesta k hostu</param>
        public void SaveConfig(ref string apachePath, ref string htDocsPath, ref string hostPath)
        {
            ApachePath = _repairSlashes(ref apachePath, _APACHE_PATH_SLASHES);
            HtDocsPath = _repairSlashes(ref htDocsPath, _HTDOCS_PATH_SLASHES);
            HostPath = _repairSlashes(ref hostPath, _HOST_PATH_SLASHES);

            _writeToConfig(XmlWriter.Create(_CONFIG_FILE, _xmlSettings));

            _vHostPath = Path.Combine(ApachePath, _HTTPD_VHOST_FILE);            
        }

        /// <summary>
        /// Zapíše do konfiguračního XML záznamy
        /// </summary>
        /// <param name="xmlConfigWriter">Instance XML konfiguračního souboru</param>
        private void _writeToConfig(XmlWriter xmlConfigWriter)
        {
            xmlConfigWriter.WriteStartElement("ServerHelperConfig");
                xmlConfigWriter.WriteStartElement("path");
                    xmlConfigWriter.WriteElementString("apache", ApachePath);
                    xmlConfigWriter.WriteElementString("htDocs", HtDocsPath);
                    xmlConfigWriter.WriteElementString("host", HostPath);
                xmlConfigWriter.WriteEndElement();
            xmlConfigWriter.WriteEndElement();

            xmlConfigWriter.Flush();
            xmlConfigWriter.Close();
        }

        /// <summary>
        /// Nahradí ve cestě špatná lomítka za správná
        /// </summary>
        /// <param name="path">Kontrolovaná cesta, zároveň se opravená cesta vrátí jako reference</param>
        /// <param name="slashTypes">Sada lomítek</param>
        /// <returns></returns>
        private string _repairSlashes(ref string path, string[] slashTypes)
        {
            return path = path.Replace(slashTypes[_BAD_INDEX], slashTypes[_GOOD_INDEX]);
        }

        /// <summary>
        /// Načte konfigurační XML soubor a inicializuje potřebné cesty
        /// </summary>
        /// <returns>TRUE - soubor byl načten | FALSE - soubor neexistuje</returns>
        public bool ReadConfig()
        {
            if (_configExists())
            {
                _initFromConfigXml();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Vrátí, zda existuje konfigurační soubor
        /// </summary>
        /// <returns></returns>
        private bool _configExists()
        {
            return File.Exists(_CONFIG_FILE);
        }

        /// <summary>
        /// Inicializuje třídní proměnné z konfiguračního souboru
        /// </summary>
        private void _initFromConfigXml()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(_CONFIG_FILE);

            ApachePath = xmlConfig.SelectNodes("//path/apache")[0].InnerText;
            HtDocsPath = xmlConfig.SelectNodes("//path/htDocs")[0].InnerText;
            HostPath = xmlConfig.SelectNodes("//path/host")[0].InnerText;

            _vHostPath = Path.Combine(ApachePath, _HTTPD_VHOST_FILE);
        }

        /// <summary>
        /// Přečte a vrátí všechny řádky souboru
        /// </summary>
        /// <returns>Pole s řádky souboru</returns>
        private string[] ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath);
            }
            else return null;
        }

        /// <summary>
        /// Uloží nový web
        /// </summary>
        /// <param name="htDocsPath">Cesta k htDocs</param>
        /// <param name="domain">Doména</param>
        /// <param name="folder">Složka</param>
        public void SaveNewWeb(string htDocsPath, string domain, string folder)
        {
            try
            {
                _writeNewWeb(new Web(domain, htDocsPath, folder));
            }
            catch (FileNotFoundException e)
            {
                _log.Write(e.Message);
            }
        }

        /// <summary>
        /// Přidá nový web:
        /// - do vHostu
        /// - do Hostu
        /// - vytvoří složku
        /// </summary>
        /// <param name="newWeb">Instance nového webu</param>
        /// <exception cref="FileNotFoundException">Není nalezen soubor, do kterého se zapisuje.</exception>
        private void _writeNewWeb(Web newWeb)
        {
            _writeVHost(newWeb);
            _writeHost(newWeb.Domain);
            _createFolderIfNotExists(newWeb.HtDocsPath, newWeb.Folder);
        }

        /// <summary>
        /// Zapíše nový web do virtual hostu
        /// </summary>
        /// <param name="newWeb">Instance nového webu</param>
        /// <exception cref="FileNotFoundException">Virtual host není nalezen</exception>
        private void _writeVHost(Web newWeb)
        {
            if (File.Exists(_vHostPath))
            {
                VHost vHost = VHost.FromFileContent(ReadFile(_vHostPath));

                if (!vHost.IsAlreadyContains(newWeb))
                {
                    vHost.AddNewWeb(newWeb);
                    File.WriteAllLines(_vHostPath, vHost.GetVHostFileContent());
                }
            }
            else
            {
                throw new FileNotFoundException(string.Format("File {0} does not exist!", _vHostPath));
            }
        }

        /// <summary>
        /// Zapíše do hostu nový řádek s doménou
        /// </summary>
        /// <param name="domain">Nová doména</param>
        /// <exception cref="FileNotFoundException">Host není nalezen</exception>
        private void _writeHost(string domain)
        {
            if (File.Exists(HostPath))
            {
                Host host = Host.FromFileContent(ReadFile(HostPath));

                if (!host.IsAlreadyContains(domain))
                {
                    host.AddNewDomain(domain);
                    File.WriteAllLines(HostPath, host.GetHostContent());
                }
            }
            else
            {
                throw new FileNotFoundException(string.Format("File {0} does not exist!", HostPath));
            }
        }

        /// <summary>
        /// Vytvoří novou složku, pokud již neexistuje
        /// </summary>
        /// <param name="path">Cesta k adresáři, kde se má složka vytvořit</param>
        /// <param name="folder">Název nové složky</param>
        private void _createFolderIfNotExists(string path, string folder)
        {
            string newFolder = Path.Combine(path, folder);

            if (!Directory.Exists(newFolder))
            {
                Directory.CreateDirectory(newFolder);
            }
        }

        /// <summary>
        /// Privátní konstruktor, třída je Singleton
        /// - založí konfigurační parametry pro zápis XML
        /// </summary>
        private FileHelper()
        {
            _xmlSettings = new XmlWriterSettings();
            _xmlSettings.Indent = true;
            _xmlSettings.Encoding = Encoding.UTF8;

            _log = Log.CreateFromFileName("FileHelperLog");
        }

        public string ApachePath { private set; get; }
        public string HtDocsPath { private set; get; }
        public string HostPath { private set; get; }

        private static readonly FileHelper _instance = new FileHelper();
        private XmlWriterSettings _xmlSettings;
        private Log _log;
        private string _vHostPath;

        private const string _CONFIG_FILE = "config.xml";
        private const string _HTTPD_VHOST_FILE = "httpd-vhosts.conf";

        private const int _BAD_INDEX = 0, _GOOD_INDEX = 1;
        private string[] _APACHE_PATH_SLASHES = new string[]{"/", "\\"};
        private string[] _HTDOCS_PATH_SLASHES = new string[] { "\\", "/" };
        private string[] _HOST_PATH_SLASHES = new string[] { "/", "\\" };
    }
}
