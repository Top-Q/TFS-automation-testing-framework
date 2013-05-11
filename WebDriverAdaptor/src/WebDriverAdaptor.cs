using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TfsAutomation.Adaptors;
using System.Xml.Serialization;
using TfsAutomationCore.Tests.Adaptors.WebDriver;
//TfsAutomationCore.Tests.Adaptors.WebDriverAdaptor

namespace TfsAutomationCore.Tests.Adaptors
{
    public class WebDriverAdaptor : AdaptorImpl
    {

       // public string Host
       // { get; set; }

        public IWebDriver driver
        { get; set; }
        protected WebDriverType webDriverType;
        public string webDriver
        { get; set; }
        

        //#region Drivers Paths
        
        protected string chromeDriverPath
        { get; set; }
        protected string ieDriverServerPath
        { get; set; }
        
        protected bool lazyInit = false;
        private bool browserIsOpened = false;
         
        protected string browserPath;
        protected bool windowMaximize = true;
        protected string domain 
         { get; set; }
        protected string chromeProfile = null;
	    protected string chromeExtension = null;
        protected string firefoxExtension = null;
        protected string firefoxProfile = null;
        protected string timeOut = "30000";
	    protected bool ignoreCertificateErrors = false;

        public override void Init()
        {
            report.Report("In WebDriver adaptor init");

            if (!lazyInit)
            {
                openBrowser();
               
            }
          
            
        }

        private void openBrowser()
        {
            if (browserIsOpened == false)
            {
                driver = createWebDriver();
                browserIsOpened = true;
            }
        }

        public override void Close()
        {
            report.Report("In WebDriver adaptor close");
            if(driver!=null)
            {
                driver.Quit();
            }
        }


        private IWebDriver createWebDriver()
        {
            IWebDriver driver = null;

            initBrowserType();

            switch (webDriverType)
            {
                case WebDriverType.CHROME:
                    //Need to Impl 
                    break;
                case WebDriverType.IEXPLORER:
                    if(String.IsNullOrEmpty(ieDriverServerPath))
                    {
                        driver = new InternetExplorerDriver();

                    }else
                    {
                        driver = new InternetExplorerDriver(ieDriverServerPath);

                    }
                    
                    break;
                case WebDriverType.FIREFOX:
                        driver = new FirefoxDriver();
                  
                    break;

                default:
                    throw new NotSupportedException("WebDriver init error - the driver" + webDriverType + " is not supported");
                    break;

            }

            return driver;
        }

        private void initBrowserType()
        {
            if(webDriver !=null)
            {

                foreach (var type in Enum.GetValues(typeof(WebDriverType)))
                {
                   if(webDriver.ToLower().Equals(type.ToString().ToLower()))
                   {
                       webDriverType = (WebDriverType)type;
                       return;

                   }
                }
            }
           
        }

        //private WebDriverType initWebDriverType()
        //{
        //    WebDriverType type = WebDriverType.NOT_INIT;

        //    if(webDriver!=null)
        //    {
        //        if(webDriver.ToLower().Equals("firefox"))
        //        {
        //            type = WebDriverType.FIREFOX;
        //        }
        //        else if (webDriver.ToLower().Equals("iexplorer"))
        //        {
        //            type = WebDriverType.IEXPLORER;
        //        }
        //        else if (webDriver.ToLower().Equals("chrome"))
        //        {
        //            type = WebDriverType.CHROME;
        //        }

        //    }
        //    return type;
        //}

        public bool GetBrowserIsOpened()
        {
            return browserIsOpened;
        }


    }
}
