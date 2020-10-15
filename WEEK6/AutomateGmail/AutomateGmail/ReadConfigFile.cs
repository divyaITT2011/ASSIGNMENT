using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Specialized;
//using AventStack.ExtentReports.Configuration;

namespace AutomateGmail
{
    public class ReadConfigFile
    {
        public string emailID;
        public string password;
        public string toEmail;

        public ReadConfigFile()
        {
            ReadAllSettings();
        }
        public string GetEmailID() {
            return this.emailID;
         }
        public string GetPassword() {
            return this.password;
        }
        
        public  void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                    this.emailID = "";
                    this.password = "";
                }
                else
                {                    
                        this.emailID = ConfigurationManager.AppSettings["email"];
                        this.password = ConfigurationManager.AppSettings["password"];
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }
    }
}
