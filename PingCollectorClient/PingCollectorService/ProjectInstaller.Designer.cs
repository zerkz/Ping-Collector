namespace PingCollectorService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pingCollectorProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.pingCollectorInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // pingCollectorProcessInstaller
            // 
            this.pingCollectorProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.pingCollectorProcessInstaller.Password = null;
            this.pingCollectorProcessInstaller.Username = null;
            this.pingCollectorProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
            // 
            // pingCollectorInstaller
            // 
            this.pingCollectorInstaller.Description = "Collects internet performance data.";
            this.pingCollectorInstaller.DisplayName = "Ping Collector Service";
            this.pingCollectorInstaller.ServiceName = "PingCollectorService";
            this.pingCollectorInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.pingCollectorInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.pingCollectorInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.pingCollectorProcessInstaller,
            this.pingCollectorInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller pingCollectorProcessInstaller;
        private System.ServiceProcess.ServiceInstaller pingCollectorInstaller;
    }
}