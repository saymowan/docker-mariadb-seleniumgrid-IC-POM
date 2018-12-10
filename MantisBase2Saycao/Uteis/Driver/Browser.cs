using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.Uteis.Driver
{
    public class Browser : DriverFactory
    {


        public static ChromeDriver ChromeLocal()
        {
            return new ChromeDriver(ConfigurationManager.AppSettings["PathChromeDriver"].ToString());
        }



        public static void Remote(string navegador)
        {
            string Iphub = ConfigurationManager.AppSettings["IpHub"].ToString();

            switch (navegador)
            {
                case ("firefox"):
                    FirefoxOptions firefox = new FirefoxOptions();
                    firefox.SetPreference("intl.accept_languages", "pt-BR");
                    firefox.AddArgument("-width");
                    firefox.AddArgument("1920");
                    firefox.AddArgument("-height");
                    firefox.AddArgument("1080");

                    INSTANCE = new RemoteWebDriver(new Uri(Iphub), firefox.ToCapabilities());
                    //INSTANCE.Manage().Window.Maximize();
                    break;

                case ("chrome"):
                    ChromeOptions chrome = new ChromeOptions();
                    chrome.AddArgument("no-sandbox");
                    chrome.AddArguments("headless");
                    chrome.AddArgument("--allow-running-insecure-content");
                    chrome.AddArgument("--lang=pt-BR");
                    chrome.AddArgument("--window-size=1920,1080");

                    INSTANCE = new RemoteWebDriver(new Uri(Iphub), chrome.ToCapabilities());
                    //INSTANCE.Manage().Window.Maximize();
                    break;

                case ("ie"):
                    InternetExplorerOptions ie = new InternetExplorerOptions();
                    INSTANCE = new RemoteWebDriver(new Uri(Iphub), ie.ToCapabilities());
                    //INSTANCE.Manage().Window.Maximize();
                    break;

                case ("opera"):
                    OperaOptions opera = new OperaOptions();
                    opera.BinaryLocation = "/usr/bin/opera";
                    INSTANCE = new RemoteWebDriver(new Uri(Iphub), opera.ToCapabilities());
                    INSTANCE.Manage().Window.Maximize();
                    break;

                default:
                    throw new NotImplementedException();

            }
        }//fim void


    }//fim class
}//fim namespace
