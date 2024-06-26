﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Handheld_Hardware_Tools
{
    public class Log_Writer
    {
        private static Log_Writer _instance = null;


        private static readonly object lockObj = new object();

        private string appDir = AppDomain.CurrentDomain.BaseDirectory;

        private Log_Writer()
        {

        }
        public void writeLog(string newLog, string errorNum = "")
        {
            try
            {
                //create directory if it doesn't exist, YOU DONT NEED TO CREATE THE FILE. Streamwriter will do this
                //creating the file manually can cause "another process is using the file" error
                if (!Directory.Exists(appDir + "\\Logs")) { System.IO.Directory.CreateDirectory(appDir + "\\Logs"); }
                using (StreamWriter w = File.AppendText(appDir + "\\Logs\\application_log.txt"))
                {
                    if (errorNum != "") { newLog = "Error " + errorNum + ": " + newLog; }

                    Log(newLog, w);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error writing to log file. " + ex.Message);
            }


        }
        private void Log(string logMessage, TextWriter w)
        {
            try
            {
                w.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()} {logMessage}");
                w.Flush();
            }
            catch { }
        }
    
        public static Log_Writer Instance
        {
            get
            {
                
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new Log_Writer();
                        }
                    }
                }



                return _instance;
            }
        }


    }


   
}
