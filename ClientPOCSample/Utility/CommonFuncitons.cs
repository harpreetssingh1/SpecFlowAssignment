using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SharpGamingAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SharpGamingAutomation.Utility
{
    public class CommonFuncitons
    {

        private IWebDriver Driver;
        IJavaScriptExecutor js;
        public CommonFuncitons(IWebDriver driver)
        {
            Driver = driver;
          js = (IJavaScriptExecutor)Driver;
        }

        
        public void LogMessage(String messageToLog)
        {


            Console.WriteLine(messageToLog);

        }
        public void LogErrorMessage(String messageToLog)
        {

            Console.WriteLine(messageToLog);


        }
        public void ClickWebelement(IWebElement webele, String Ele_name)
        {
            try
            {
               
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                wait.Until(driver => webele.Displayed);
                webele.Click();
                LogMessage("The '" + Ele_name + "' is clicked");
            }
            catch (Exception e)
            {
                LogErrorMessage("The '" + Ele_name + "' is not avilable \n");
                Console.WriteLine(e.StackTrace);

            }
        }
        public void Sendkeys(IWebElement webele, String value, String Ele_name)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                wait.Until(driver => webele.Displayed);
                webele.Click();
                webele.SendKeys(Keys.Control+"A");
                 webele.SendKeys(value);
                LogMessage("'" + value + "' is entered into the '" + Ele_name + "' textbox");
            }
            catch (Exception e)
            {
                LogErrorMessage("\nThe " + Ele_name + " is not avilable \n");
                Console.WriteLine(e.StackTrace);
            }
        }



        public void VerifyDisplayed(IWebElement ele, String objname)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(driver => ele.Displayed);
            if (ele.Displayed)
            {
                LogMessage("The element '" + objname + "' is visible--PASS.");
            }
            else
            {
                LogMessage("The element '" + objname + "' is not visible--FAIL");
            }
        }

        public Boolean VerifyVisible(IWebElement ele, String objname)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(driver => ele.Displayed);
            if (ele.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ScrollToElement(IWebElement ele)
        {
            try
            {
                js.ExecuteScript("arguments[0].scrollIntoView();", ele);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void WaitForElementLoad(int seconds)
        {
            var timePass = seconds + "000";
            Thread.Sleep(Int32.Parse(timePass));
        }
       
    }

}





