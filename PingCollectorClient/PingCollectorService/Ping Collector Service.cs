using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;

using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Security.Cryptography;
using System.Timers;


using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Xml.Serialization;
using System.Collections;
using System.Xml;
using Newtonsoft.Json;
using log4net;
using System.Net.Sockets;




namespace PingCollectorService
{
    public partial class PingCollectorService : ServiceBase
    {
        private const String regKey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\ZDWARE\\PING COLLECTOR";
        private Encoding encoding = new System.Text.UTF8Encoding();

        //settings 
        private int pingInterval;
        private int pingDefault = 60;
        protected static readonly ILog log = LogManager.GetLogger(typeof(PingCollectorService));
        private Timer pingTimer;
        private List<String> websites = new List<String>();
        private WebClient wc = new WebClient();
        private PingCrypto crypto = new PingCrypto();
        private Boolean testFlag = false;
        private String fakeEncryptionKey = "huehuehue";


        //prod server
        private String server = "https://ping-collector.appspot.com/recieveReport";
        //dev server
        //private String server = "http://localhost:8080/recieveReport";

        public PingCollectorService()
        {
            InitializeComponent();
            wc.Headers.Add("Content-Type","application/json");
          
        }

     
        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();
            pingTimer = new System.Timers.Timer();

            try
            {
                String ip = wc.DownloadString("http://api.exip.org/?call=ip");
                IPHostEntry externalIP = Dns.GetHostEntry(ip);
                log.Info("||||||||| PING COLLECTOR SERVICE STARTING ||||||||");
                if (!externalIP.HostName.ToLower().Contains("windstream") && testFlag != true)
                {
                    log.Error("You are currently not using a  Windstream Internet Service Provider. Ping Collector will cease to report until you are.");
                    this.Stop();
                }

            }
            catch (WebException e)
            {
                log.Error("Ping Collector was unable to check your ISP. Please ensure you have working internet. Stopping service.");
            }
            catch (SocketException e)
            {
                log.Error("Ping Collector encountered a socket error. Please ensure you have working internet. Stopping service.");
            }
            catch (Exception e)
            {
                log.Error("Generic Error : " + e.ToString());
            }

            pingTimer.Elapsed += new ElapsedEventHandler(onPingTimerElapsed);
            pingTimer.AutoReset = true;
            getSettings();
  
            websites.Add("www.facebook.com");
            websites.Add("www.windstream.net");
            websites.Add("google-public-dns-a.google.com");
            websites.Add("google-public-dns-b.google.com");

            pingTimer.Enabled = true;
            pingTimer.Start();
        }


        protected override void OnStop()
        {
            pingTimer.Stop();
            pingTimer.Close();
         
        }

        private void onPingTimerElapsed(Object source, ElapsedEventArgs e)
        {
            getSettings();

            Report pingCollection = new Report();

            collectPings(websites, pingCollection);

            byte[] emailProtectedBytes = (byte[])Microsoft.Win32.Registry.GetValue(regKey, "email", null);
            byte[] passProtectedBytes = (byte[])Microsoft.Win32.Registry.GetValue(regKey, "password", null);
            try
            {
                if (emailProtectedBytes != null)
                {
                    pingCollection.User = encoding.GetString(ProtectedData.Unprotect(emailProtectedBytes, encoding.GetBytes("moonshield"), DataProtectionScope.LocalMachine));
                }

                if (passProtectedBytes != null)
                {
                    pingCollection.Password = encoding.GetString(ProtectedData.Unprotect(passProtectedBytes, encoding.GetBytes("moonshield"), DataProtectionScope.LocalMachine));
                }
            }
            catch(Exception ex)
            {
                log.Error("Issues retrieving values from registry... " + ex.Message);
            }

            if (pingCollection.User == null || pingCollection.Password == null)
            {
                log.Error("No user or password present. Not sending report");
            }
            else
            {
                try
                {

                    String json = JsonConvert.SerializeObject(pingCollection);
                    SymmetricAlgorithm crypt = SymmetricAlgorithm.Create();
                    //DONT LOOK AT MAH PIRVATE KAYZ
                    String resp = wc.UploadString(server, crypto.Encrypt(json, "f0rth0sewhoc@nnotsp3ak"));
                    log.Info("Ping report sent.");
                    log.Info("Response : " + resp);
                    pingCollection = null;

                    json = null;
                    
                }
                catch (WebException exc)
                {
                    log.Error(exc.Message);
                }
                catch (System.NotSupportedException exc)
                {
                    log.Error(exc.Message);
                }

            }
            pingCollection = new Report();
                   
       
        }

        private void getSettings()
        {
            pingInterval = (int) Microsoft.Win32.Registry.GetValue(regKey, "interval", 60);
            
            if (!(pingInterval >= 30 && pingInterval <= 720))
            {
                pingInterval = pingDefault; // if user manually inputs inside our config a number out of range, revert to default
            }
            pingTimer.Interval = pingInterval * 60000; // convert the minutes into milliseconds.
      
        }








        private void collectPings(List<String> websites, Report pingCollection)
        {
            pingCollection.Timestamp = DateTime.Now;
            foreach(String site in websites){
               pingCollection.Targets.Add(getPingTargetReport(site));
            }         
        }

  

        public static Target getPingTargetReport(String address)
        {
            Ping p = new Ping();
            Target t = new Target();
            t.Address = address;
            t.Pings.Add((Int32)p.Send(address).RoundtripTime);
            t.Pings.Add((Int32)p.Send(address).RoundtripTime);
            t.Pings.Add((Int32)p.Send(address).RoundtripTime);
            t.Pings.Add((Int32)p.Send(address).RoundtripTime);
            t.Pings.Add((Int32)p.Send(address).RoundtripTime);
            p.Dispose();
            return t;
        }



    }
}
