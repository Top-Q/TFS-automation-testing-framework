using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace TfsAutomation.SutHandling
{
    public class SutManager
    {

        public static readonly string sutDefaultFile = "sut.xml";

        private static string GetSutFolder()
        {
            string sutFolder = ConfigurationManager.AppSettings.Get("SutFolder");
            if (null != sutFolder)
            {
                return sutFolder;
            }
            else
            {
                return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\SUT"; 
            }
            


        }

        
        public static string CurrentSut()
        {
            string sutFile = ConfigurationManager.AppSettings.Get("SutFile");
            if (null != sutFile)
            {
                return GetSutFolder() + @"\" + sutFile;
            }
            else
            {
                return GetSutFolder() + @"\" + sutDefaultFile;
            }
           
        }
    }
}
