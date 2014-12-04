using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;
using PingCollectorConfig.Properties;
using Newtonsoft.Json;
using System.IO;


namespace PingCollectorConfig

{
    public partial class ConfigForm : Form    
    {
        private const String regKey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\ZDWARE\\PING COLLECTOR";
        private Encoding encoding = new System.Text.UTF8Encoding();
        private WebClient wc = new WebClient();
        private Boolean testFlag = false;
        //prod
        private String server = "https://ping-collector.appspot.com/";
        //dev
        //private String server = "http://localhost:8080/";
  
      
        public ConfigForm()
        {
            String ip = null;
            IPHostEntry externalIP = null;
            try
            {
                ip = wc.DownloadString("http://api.exip.org/?call=ip");
                externalIP = Dns.GetHostEntry(ip);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ping Collector was unable to access the internet. Please ensure you have internet access.","Error");
                Environment.Exit(0);
            }


            
                   if (!externalIP.HostName.ToLower().Contains("windstream") && testFlag != true)
                    {
                        MessageBox.Show("You are currently not using a  Windstream Internet Service Provider. \n Ping Collector will not function until you are.","Windstream Internet Required.");
                        Environment.Exit(0);
                    }
             
            InitializeComponent();
        


            byte[] emailProtectedBytes = (byte[])Microsoft.Win32.Registry.GetValue(regKey, "email", null);
            byte[] passProtectedBytes = (byte[])Microsoft.Win32.Registry.GetValue(regKey, "password", null);

            if (emailProtectedBytes != null)
            {
                emailBox.Text  = encoding.GetString(ProtectedData.Unprotect(emailProtectedBytes, encoding.GetBytes("moonshield"), DataProtectionScope.LocalMachine));
            }
            if (passProtectedBytes != null)
            {
                passBox.Text = encoding.GetString(ProtectedData.Unprotect(passProtectedBytes, encoding.GetBytes("moonshield"), DataProtectionScope.LocalMachine));
            }
          
            try
            {
                intervalControl.Value = (int)Microsoft.Win32.Registry.GetValue(regKey, "interval", 60);
            }catch(NullReferenceException e){
                    intervalControl.Value = 60;
            }
        
            
            
        }

   

        private void loginButton_Click(object sender, EventArgs e)
        {
            saveSettings(sender, e);
            int score = (int)PasswordValidator.CheckStrength(passBox.Text);

            if (score < 2)
            {
                MessageBox.Show("Password must be between 8 and 15 characters.", "Unacceptable Password");

            }
            else
            {

                String createAccount = "{\"email\":\"" + emailBox.Text + "\", \"password\":\"" + passBox.Text + "\"}";
               
                try
                {
                    String respString = wc.UploadString(server + "/user", createAccount);
            
                    PingCollectorResponse resp = JsonConvert.DeserializeObject<PingCollectorResponse>(respString);

                    MessageBox.Show(resp.message, "Account Created.");

                }
                catch (WebException exc)
                {
                    handleWebException(exc);
                }
            }

        }

        private void saveSettings(object sender, EventArgs e)
        {
           
            Microsoft.Win32.Registry.SetValue(regKey, "interval", intervalControl.Value,
   Microsoft.Win32.RegistryValueKind.DWord);
            if(passBox.Text != null || !"".Equals(passBox.Text)){
                Microsoft.Win32.Registry.SetValue(regKey, "password", ProtectedData.Protect(encoding.GetBytes(passBox.Text), encoding.GetBytes("moonshield"), DataProtectionScope.LocalMachine),
   Microsoft.Win32.RegistryValueKind.Binary);
            }
             if(emailBox.Text != null || !"".Equals(emailBox.Text)){
                 Microsoft.Win32.Registry.SetValue(regKey, "email", ProtectedData.Protect(encoding.GetBytes(emailBox.Text),encoding.GetBytes("moonshield"), DataProtectionScope.LocalMachine),
   Microsoft.Win32.RegistryValueKind.Binary);
             }
           
        
        }

        private void forgotPassButton_Click(object sender, EventArgs e)
        {
            if (emailBox.Text.Length == 0)
            {
                MessageBox.Show("Please enter an email address.", "Email Required");
            }
            else
            {
                try
                {
                    String resp = wc.DownloadString(server + "user/requestNewPassword?user=" + emailBox.Text);
                    PingCollectorResponse reply = JsonConvert.DeserializeObject<PingCollectorResponse>(resp);
                    MessageBox.Show(reply.message, "New Password Request Successful.");
                }
                catch (WebException exc)
                {
                    handleWebException(exc);

                }
            }

        }

        private void passBox_TextChanged(object sender, EventArgs e)
        {
            int score = (int) PasswordValidator.CheckStrength(passBox.Text);
            progressBar1.Value = score * 20;
        }

        private void aboutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }
        //quicky convience method.. instead of grabbing an entire html parsing library...
        private String getErrorFromHTTPResponse(String response)
        {
            try
            {
                int startIndex = response.IndexOf("<h1>") + 4;
                int endIndex = response.IndexOf("</h1>");
                int length = response.Length;
                return response.Substring(startIndex, endIndex - startIndex);
            }
            catch (Exception e)
            {
                return "Problem parsing error message";
            }
        }


        private void handleWebException(WebException exc)
        {
            if (exc.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse resp = (HttpWebResponse)exc.Response;
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                String errorMsg = reader.ReadToEnd();

                MessageBox.Show(getErrorFromHTTPResponse(errorMsg), resp.StatusCode.ToString());
                reader.Close();
                resp.Close();
            }
            else
            {
                MessageBox.Show(exc.Message, exc.Status.ToString());
            }
        }

       


    
   

       

       
      
    }
}
