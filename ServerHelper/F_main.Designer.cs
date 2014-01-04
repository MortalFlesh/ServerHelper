namespace ServerHelper
{
    partial class F_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chb_newWebRestartApache = new System.Windows.Forms.CheckBox();
            this.b_newWebSave = new System.Windows.Forms.Button();
            this.l_newWebFolder = new System.Windows.Forms.Label();
            this.l_newWebDomain = new System.Windows.Forms.Label();
            this.tb_newWebFolder = new System.Windows.Forms.TextBox();
            this.tb_newWebDomain = new System.Windows.Forms.TextBox();
            this.l_apacheFolderPath = new System.Windows.Forms.Label();
            this.tb_apacheFolderPath = new System.Windows.Forms.TextBox();
            this.gb_apacheSettings = new System.Windows.Forms.GroupBox();
            this.l_hostPath = new System.Windows.Forms.Label();
            this.l_htDocsPath = new System.Windows.Forms.Label();
            this.tb_hostPath = new System.Windows.Forms.TextBox();
            this.tb_htDocsPath = new System.Windows.Forms.TextBox();
            this.gb_apache = new System.Windows.Forms.GroupBox();
            this.b_switchApache = new System.Windows.Forms.Button();
            this.l_apache2_4_status = new System.Windows.Forms.Label();
            this.l_apache2_4 = new System.Windows.Forms.Label();
            this.l_apache_2_2_status = new System.Windows.Forms.Label();
            this.l_apache2_2 = new System.Windows.Forms.Label();
            this.gb_services = new System.Windows.Forms.GroupBox();
            this.b_showServices = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_apacheSettings.SuspendLayout();
            this.gb_apache.SuspendLayout();
            this.gb_services.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_newWebRestartApache);
            this.groupBox1.Controls.Add(this.b_newWebSave);
            this.groupBox1.Controls.Add(this.l_newWebFolder);
            this.groupBox1.Controls.Add(this.l_newWebDomain);
            this.groupBox1.Controls.Add(this.tb_newWebFolder);
            this.groupBox1.Controls.Add(this.tb_newWebDomain);
            this.groupBox1.Location = new System.Drawing.Point(13, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nový web";
            // 
            // chb_newWebRestartApache
            // 
            this.chb_newWebRestartApache.AutoSize = true;
            this.chb_newWebRestartApache.Location = new System.Drawing.Point(10, 71);
            this.chb_newWebRestartApache.Name = "chb_newWebRestartApache";
            this.chb_newWebRestartApache.Size = new System.Drawing.Size(174, 17);
            this.chb_newWebRestartApache.TabIndex = 2;
            this.chb_newWebRestartApache.Text = "Restartovat Apache po uložení";
            this.chb_newWebRestartApache.UseVisualStyleBackColor = true;
            // 
            // b_newWebSave
            // 
            this.b_newWebSave.Location = new System.Drawing.Point(6, 94);
            this.b_newWebSave.Name = "b_newWebSave";
            this.b_newWebSave.Size = new System.Drawing.Size(247, 39);
            this.b_newWebSave.TabIndex = 3;
            this.b_newWebSave.Text = "Uložit";
            this.b_newWebSave.UseVisualStyleBackColor = true;
            this.b_newWebSave.Click += new System.EventHandler(this.b_newWebSave_Click);
            // 
            // l_newWebFolder
            // 
            this.l_newWebFolder.AutoSize = true;
            this.l_newWebFolder.Location = new System.Drawing.Point(7, 48);
            this.l_newWebFolder.Name = "l_newWebFolder";
            this.l_newWebFolder.Size = new System.Drawing.Size(88, 13);
            this.l_newWebFolder.TabIndex = 1;
            this.l_newWebFolder.Text = "Složka v htDocs:";
            // 
            // l_newWebDomain
            // 
            this.l_newWebDomain.AutoSize = true;
            this.l_newWebDomain.Location = new System.Drawing.Point(7, 22);
            this.l_newWebDomain.Name = "l_newWebDomain";
            this.l_newWebDomain.Size = new System.Drawing.Size(50, 13);
            this.l_newWebDomain.TabIndex = 1;
            this.l_newWebDomain.Text = "Doména:";
            // 
            // tb_newWebFolder
            // 
            this.tb_newWebFolder.Location = new System.Drawing.Point(105, 45);
            this.tb_newWebFolder.Name = "tb_newWebFolder";
            this.tb_newWebFolder.Size = new System.Drawing.Size(148, 20);
            this.tb_newWebFolder.TabIndex = 1;
            // 
            // tb_newWebDomain
            // 
            this.tb_newWebDomain.Location = new System.Drawing.Point(105, 19);
            this.tb_newWebDomain.Name = "tb_newWebDomain";
            this.tb_newWebDomain.Size = new System.Drawing.Size(148, 20);
            this.tb_newWebDomain.TabIndex = 0;
            // 
            // l_apacheFolderPath
            // 
            this.l_apacheFolderPath.AutoSize = true;
            this.l_apacheFolderPath.Location = new System.Drawing.Point(7, 22);
            this.l_apacheFolderPath.Name = "l_apacheFolderPath";
            this.l_apacheFolderPath.Size = new System.Drawing.Size(82, 13);
            this.l_apacheFolderPath.TabIndex = 1;
            this.l_apacheFolderPath.Text = "Cesta k Apachi:";
            // 
            // tb_apacheFolderPath
            // 
            this.tb_apacheFolderPath.Location = new System.Drawing.Point(105, 22);
            this.tb_apacheFolderPath.Name = "tb_apacheFolderPath";
            this.tb_apacheFolderPath.Size = new System.Drawing.Size(232, 20);
            this.tb_apacheFolderPath.TabIndex = 0;
            // 
            // gb_apacheSettings
            // 
            this.gb_apacheSettings.Controls.Add(this.l_hostPath);
            this.gb_apacheSettings.Controls.Add(this.l_htDocsPath);
            this.gb_apacheSettings.Controls.Add(this.l_apacheFolderPath);
            this.gb_apacheSettings.Controls.Add(this.tb_hostPath);
            this.gb_apacheSettings.Controls.Add(this.tb_htDocsPath);
            this.gb_apacheSettings.Controls.Add(this.tb_apacheFolderPath);
            this.gb_apacheSettings.Location = new System.Drawing.Point(13, 13);
            this.gb_apacheSettings.Name = "gb_apacheSettings";
            this.gb_apacheSettings.Size = new System.Drawing.Size(343, 106);
            this.gb_apacheSettings.TabIndex = 3;
            this.gb_apacheSettings.TabStop = false;
            this.gb_apacheSettings.Text = "Nastavení Apache";
            // 
            // l_hostPath
            // 
            this.l_hostPath.AutoSize = true;
            this.l_hostPath.Location = new System.Drawing.Point(7, 74);
            this.l_hostPath.Name = "l_hostPath";
            this.l_hostPath.Size = new System.Drawing.Size(75, 13);
            this.l_hostPath.TabIndex = 1;
            this.l_hostPath.Text = "Cesta k hostu:";
            // 
            // l_htDocsPath
            // 
            this.l_htDocsPath.AutoSize = true;
            this.l_htDocsPath.Location = new System.Drawing.Point(7, 48);
            this.l_htDocsPath.Name = "l_htDocsPath";
            this.l_htDocsPath.Size = new System.Drawing.Size(83, 13);
            this.l_htDocsPath.TabIndex = 1;
            this.l_htDocsPath.Text = "Cesta k htDocs:";
            // 
            // tb_hostPath
            // 
            this.tb_hostPath.Location = new System.Drawing.Point(105, 74);
            this.tb_hostPath.Name = "tb_hostPath";
            this.tb_hostPath.Size = new System.Drawing.Size(232, 20);
            this.tb_hostPath.TabIndex = 2;
            // 
            // tb_htDocsPath
            // 
            this.tb_htDocsPath.Location = new System.Drawing.Point(105, 48);
            this.tb_htDocsPath.Name = "tb_htDocsPath";
            this.tb_htDocsPath.Size = new System.Drawing.Size(232, 20);
            this.tb_htDocsPath.TabIndex = 1;
            // 
            // gb_apache
            // 
            this.gb_apache.Controls.Add(this.b_switchApache);
            this.gb_apache.Controls.Add(this.l_apache2_4_status);
            this.gb_apache.Controls.Add(this.l_apache2_4);
            this.gb_apache.Controls.Add(this.l_apache_2_2_status);
            this.gb_apache.Controls.Add(this.l_apache2_2);
            this.gb_apache.Location = new System.Drawing.Point(284, 126);
            this.gb_apache.Name = "gb_apache";
            this.gb_apache.Size = new System.Drawing.Size(72, 87);
            this.gb_apache.TabIndex = 1;
            this.gb_apache.TabStop = false;
            this.gb_apache.Text = "Apache";
            // 
            // b_switchApache
            // 
            this.b_switchApache.Location = new System.Drawing.Point(7, 58);
            this.b_switchApache.Name = "b_switchApache";
            this.b_switchApache.Size = new System.Drawing.Size(59, 23);
            this.b_switchApache.TabIndex = 1;
            this.b_switchApache.Text = "Přepnout";
            this.b_switchApache.UseVisualStyleBackColor = true;
            this.b_switchApache.Click += new System.EventHandler(this.b_switchApache_Click);
            // 
            // l_apache2_4_status
            // 
            this.l_apache2_4_status.AutoSize = true;
            this.l_apache2_4_status.Location = new System.Drawing.Point(33, 39);
            this.l_apache2_4_status.Name = "l_apache2_4_status";
            this.l_apache2_4_status.Size = new System.Drawing.Size(0, 13);
            this.l_apache2_4_status.TabIndex = 0;
            // 
            // l_apache2_4
            // 
            this.l_apache2_4.AutoSize = true;
            this.l_apache2_4.Location = new System.Drawing.Point(7, 39);
            this.l_apache2_4.Name = "l_apache2_4";
            this.l_apache2_4.Size = new System.Drawing.Size(25, 13);
            this.l_apache2_4.TabIndex = 0;
            this.l_apache2_4.Text = "2.4:";
            // 
            // l_apache_2_2_status
            // 
            this.l_apache_2_2_status.AutoSize = true;
            this.l_apache_2_2_status.Location = new System.Drawing.Point(32, 18);
            this.l_apache_2_2_status.Name = "l_apache_2_2_status";
            this.l_apache_2_2_status.Size = new System.Drawing.Size(0, 13);
            this.l_apache_2_2_status.TabIndex = 0;
            // 
            // l_apache2_2
            // 
            this.l_apache2_2.AutoSize = true;
            this.l_apache2_2.Location = new System.Drawing.Point(6, 18);
            this.l_apache2_2.Name = "l_apache2_2";
            this.l_apache2_2.Size = new System.Drawing.Size(25, 13);
            this.l_apache2_2.TabIndex = 0;
            this.l_apache2_2.Text = "2.2:";
            // 
            // gb_services
            // 
            this.gb_services.Controls.Add(this.b_showServices);
            this.gb_services.Location = new System.Drawing.Point(284, 219);
            this.gb_services.Name = "gb_services";
            this.gb_services.Size = new System.Drawing.Size(72, 52);
            this.gb_services.TabIndex = 2;
            this.gb_services.TabStop = false;
            this.gb_services.Text = "Služby";
            // 
            // b_showServices
            // 
            this.b_showServices.Location = new System.Drawing.Point(7, 16);
            this.b_showServices.Name = "b_showServices";
            this.b_showServices.Size = new System.Drawing.Size(59, 23);
            this.b_showServices.TabIndex = 0;
            this.b_showServices.Text = "Zobrazit";
            this.b_showServices.UseVisualStyleBackColor = true;
            this.b_showServices.Click += new System.EventHandler(this.b_showServices_Click);
            // 
            // F_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 283);
            this.Controls.Add(this.gb_services);
            this.Controls.Add(this.gb_apache);
            this.Controls.Add(this.gb_apacheSettings);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_main";
            this.Text = "ServerHelper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_apacheSettings.ResumeLayout(false);
            this.gb_apacheSettings.PerformLayout();
            this.gb_apache.ResumeLayout(false);
            this.gb_apache.PerformLayout();
            this.gb_services.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_newWebSave;
        private System.Windows.Forms.Label l_apacheFolderPath;
        private System.Windows.Forms.TextBox tb_apacheFolderPath;
        private System.Windows.Forms.Label l_newWebFolder;
        private System.Windows.Forms.Label l_newWebDomain;
        private System.Windows.Forms.TextBox tb_newWebFolder;
        private System.Windows.Forms.TextBox tb_newWebDomain;
        private System.Windows.Forms.GroupBox gb_apacheSettings;
        private System.Windows.Forms.CheckBox chb_newWebRestartApache;
        private System.Windows.Forms.Label l_htDocsPath;
        private System.Windows.Forms.TextBox tb_htDocsPath;
        private System.Windows.Forms.GroupBox gb_apache;
        private System.Windows.Forms.Label l_apache2_4;
        private System.Windows.Forms.Label l_apache2_2;
        private System.Windows.Forms.Label l_apache2_4_status;
        private System.Windows.Forms.Label l_apache_2_2_status;
        private System.Windows.Forms.Button b_switchApache;
        private System.Windows.Forms.GroupBox gb_services;
        private System.Windows.Forms.Button b_showServices;
        private System.Windows.Forms.Label l_hostPath;
        private System.Windows.Forms.TextBox tb_hostPath;

    }
}

