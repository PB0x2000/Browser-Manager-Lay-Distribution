using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V115.Emulation;
using OpenQA.Selenium.DevTools.V115.Network;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

namespace Browser_Manager
{
    internal class Selenium
    {



        public static ChromeDriver start_chrome(DataManager.Profile profile, bool headless)
        {
            try
            {
                var chromeOptions = new ChromeOptions();
                OpenQA.Selenium.Proxy proxyy = new OpenQA.Selenium.Proxy();
                proxyy.Kind = ProxyKind.Manual;
                proxyy.IsAutoDetect = false;
                proxyy.SslProxy = profile.Proxy;
                chromeOptions.Proxy = proxyy;
                if(headless == true) 
                { 
                    chromeOptions.AddArgument("--headless");
                }
                string dir = Directory.GetCurrentDirectory() + @"Profiles\" + Helper.CalculateMD5(profile.ID) + @"\Chrome";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                chromeOptions.AddArgument(String.Concat(@"--user-data-dir=", dir));
                chromeOptions.AddArgument("mute-audio");
                chromeOptions.AddArgument("--maximized");
                chromeOptions.AddExtension(Directory.GetCurrentDirectory() + @"\Chrome\plugin.crx");
                chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
                var chromeDriverService = ChromeDriverService.CreateDefaultService("Chrome");
                chromeDriverService.HideCommandPromptWindow = true;
                chromeDriverService.SuppressInitialDiagnosticInformation = true;
                ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
                driver.Navigate().GoToUrl("https://new.laydistribution.com/en/music/catalog/releases");
                return driver;
            }
            catch(Exception ex)
            {
                Helper.log(ex.ToString());
                return null;
            }
        }
    }
}
