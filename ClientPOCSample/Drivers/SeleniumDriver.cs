using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Automation.Drivers
{
    class SeleniumDriver
    {
        private IWebDriver driver;

        private readonly ScenarioContext scenarioContext;
        public SeleniumDriver(ScenarioContext scenario)
        {
            scenarioContext = scenario;
        }
        public IWebDriver Setup(string BrowserName)
        {
            dynamic Capability = GetBrowserOption(BrowserName);
           switch(BrowserName)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default :
                    driver = new ChromeDriver();
                    break;
            }
            //driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"),Capability.ToCapabilities());
            scenarioContext.Set(driver, "WebDriver");
            return driver;
        }
        private dynamic GetBrowserOption(string BrowserName)
        {
            if (BrowserName.ToLower() == "chrome")
            {
                return new ChromeOptions();

            }
            if (BrowserName.ToLower() == "firefox")
            {
                return new FirefoxOptions();
            }
            if (BrowserName.ToLower() == "edge")
            {
                return new EdgeOptions();
            }
            return new ChromeOptions();
        }
    }
}
