using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SharpGamingAutomation.Utility;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClientPOCSample.Pages
{
    class RegistartionPage
    {
        private IWebDriver Driver;
        CommonFuncitons commonFunctions = null;
        IJavaScriptExecutor js;

        //TextBox
        #region
        public IWebElement userName =>  Driver.FindElement(By.Id("userName"));

	    public IWebElement userEmail =>  Driver.FindElement(By.Id("userEmail"));

	    public IWebElement currentAddress =>  Driver.FindElement(By.XPath("//textarea[@id='currentAddress']"));

	    public IWebElement permanentAddress =>  Driver.FindElement(By.XPath("//textarea[@id='permanentAddress']"));

	    public IWebElement submit =>  Driver.FindElement(By.XPath("//button[@id='submit']"));

        public IWebElement verifyUserEmail => Driver.FindElement(By.XPath("//p[@id='email']"));

        public IWebElement verifyCurrentAddress => Driver.FindElement(By.XPath("//p[@id='currentAddress']"));

        public IWebElement verifyPermanentAddress => Driver.FindElement(By.XPath("//p[@id='permanentAddress']"));

        public IWebElement verifyUserName => Driver.FindElement(By.XPath("//p[@id='name']"));

        public IWebElement clickElement => Driver.FindElement(By.XPath("//h5[normalize-space()='Elements']"));

        public IWebElement textBox => Driver.FindElement(By.XPath("//span[normalize-space()='Text Box']"));

        public IWebElement checkBox => Driver.FindElement(By.XPath("//span[normalize-space()='Check Box']"));

        public IWebElement webTables => Driver.FindElement(By.XPath("//span[normalize-space()='Web Tables']"));

        public IWebElement buttons => Driver.FindElement(By.XPath("//span[normalize-space()='Buttons']"));

        public IWebElement uploadDownload => Driver.FindElement(By.XPath("//span[normalize-space()='Upload and Download']"));
     
        #endregion

        public RegistartionPage(IWebDriver BaseDrive)
        {
            Driver = BaseDrive;
            commonFunctions = new CommonFuncitons(Driver);
            js = (IJavaScriptExecutor)Driver;
        }
        public void TextBox()
        {
            Random r = new Random();
            int generateRandomNum = r.Next(1, 999);
            String fullName = "test" + r.Next(1, 999);
            String address = "test" + r.Next(1, 999);
            String EmailId = "test" + generateRandomNum + "@gmail.com";
            commonFunctions.WaitForElementLoad(2);
            //commonFunctions.ClickWebelement(clickElement, "click Button");
            commonFunctions.ClickWebelement(textBox, "click Button");
            commonFunctions.WaitForElementLoad(2);
            commonFunctions.Sendkeys(userName, fullName,"Full Name");
            commonFunctions.Sendkeys(currentAddress, address, "Current Address");
            commonFunctions.Sendkeys(userEmail, EmailId, "Email Id");
            commonFunctions.Sendkeys(permanentAddress, address, "permanent Address");
            commonFunctions.ClickWebelement(submit,"Submit Button");
            commonFunctions.WaitForElementLoad(2);
            commonFunctions.VerifyVisible(verifyUserName, fullName);
            commonFunctions.VerifyVisible(verifyUserEmail, EmailId);
            commonFunctions.VerifyVisible(verifyCurrentAddress, address);
            commonFunctions.VerifyVisible(verifyPermanentAddress, address);
        }

      public void CheckBox()
        {
            commonFunctions.WaitForElementLoad(2);
            commonFunctions.ScrollToElement(checkBox);
            //commonFunctions.ClickWebelement(clickElement, "click Button");
            commonFunctions.ClickWebelement(checkBox, "click Button");
            commonFunctions.WaitForElementLoad(2);
            IWebElement checkBoxSelected = Driver.FindElement(By.XPath("//span[@class='rct-checkbox']//*[name()='svg']"));
            Boolean isSelected = checkBoxSelected.Selected.Equals(true);

            // performing click operation if element is not selected 
            if (isSelected == false)
            {
                checkBoxSelected.Click();
            }

        }

       public void EditWebTable()
        {
            Random r = new Random();
            int generateRandomNum = r.Next(1, 999);
            String fullName = "test" + r.Next(1, 999);
            String address = "test" + r.Next(1, 999);
            String EmailId = "test" + generateRandomNum + "@gmail.com";
            commonFunctions.WaitForElementLoad(2);
            //commonFunctions.ClickWebelement(clickElement, "click Button");
            commonFunctions.ScrollToElement(webTables);
            commonFunctions.ClickWebelement(webTables, "click Button");
            IWebElement edit = Driver.FindElement(By.XPath("//span[@id='edit-record-1']//*[name()='svg']"));
            edit.Click();
            IWebElement updateEmail = Driver.FindElement(By.XPath("//input[@id='userEmail']"));
            updateEmail.SendKeys(EmailId);        
        }

        public void Buttons()
        {
            commonFunctions.WaitForElementLoad(2);
            //commonFunctions.ClickWebelement(clickElement, "click Button");
            commonFunctions.ScrollToElement(buttons);
            commonFunctions.ClickWebelement(buttons, "click Button");
            Actions act = new Actions(Driver);

            //Double click on element
            IWebElement ele = Driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"));
            act.DoubleClick(ele).Perform();         
            IWebElement message = Driver.FindElement(By.XPath(" //p[@id='doubleClickMessage']"));
            message.Equals("You have done a double click");
        }

        public void uploadAndDownload()
        {
            commonFunctions.WaitForElementLoad(2);
            //commonFunctions.ClickWebelement(clickElement, "click Button");
            commonFunctions.ScrollToElement(uploadDownload);
            commonFunctions.ClickWebelement(uploadDownload, "click Button");
            IWebElement upload = Driver.FindElement(By.XPath("//input[@id='uploadFile']"));
            upload.SendKeys("c:\\user\\Harpreet\\profile.jpeg");
            commonFunctions.WaitForElementLoad(2);
            IWebElement download = Driver.FindElement(By.XPath("//a[@id='downloadButton']"));
            download.Click();
        }

        public void alertFrameWindows()
        {
            commonFunctions.WaitForElementLoad(60);
            commonFunctions.ClickWebelement(clickElement, "click Button");
            commonFunctions.WaitForElementLoad(2);
            // Switch to curent active model alert, prompt or confirmation
            IAlert alert = Driver.SwitchTo().Alert();

            //Click on OK button.
            alert.Accept();

            // Click on Cancel button.
            alert.Dismiss();

            //Get the total number of frame

            int frameCount = Driver.FindElements(By.Id("iFrame")).Count;

            //Switch between the frames

            Driver.SwitchTo().Frame(0);

            //Switch to frame by element locator

            IWebElement frameElement = Driver.FindElement(By.Id("iFrame"));
            Driver.SwitchTo().Frame(frameElement);

            //Windows: Using selenium we can handle browser tabs like opening new tabs and switching between those tabs

            //Open new tab

            Driver.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.Control + 't');

            //Shift to previous tab

            Driver.FindElement(By.CssSelector("body")).SendKeys(OpenQA.Selenium.Keys.Control + OpenQA.Selenium.Keys.Tab);

            //Switch between tabs using num keys

            Driver.FindElement(By.CssSelector("body")).SendKeys(OpenQA.Selenium.Keys.Control + OpenQA.Selenium.Keys.NumberPad1);

        }

        public void EnterDetailsWithInvalidData()
        {
            Random r = new Random();
            int generateRandomNum = r.Next(1, 999);
            String invalidFirstName = "test" + generateRandomNum;
            String invalidLastName = "test" + generateRandomNum;
            String invalidEmailId = "test" + generateRandomNum + "@gmailcom";
            String invalidUsername = "T" + r.Next(1, 10);
            String invalidPassword = "P" + generateRandomNum;
            commonFunctions.WaitForElementLoad(2);
            //commonFunctions.ClickWebelement(clickElement, "click Button");
            commonFunctions.ScrollToElement(textBox);
            commonFunctions.ClickWebelement(textBox, "click Button");
            commonFunctions.Sendkeys(userName, invalidFirstName, "Name");
            commonFunctions.Sendkeys(userEmail, invalidEmailId, "Email");
            commonFunctions.WaitForElementLoad(2);
            if ((userEmail.Displayed)&&(userEmail.Displayed))
            {
                if(userEmail.Displayed)
                {
                    commonFunctions.LogMessage("User not able to enter invalid details");
                }
                
            }
            else
            {
                commonFunctions.LogMessage("User  able to enter invalid details");
            }
           
        }
        public void EnterAccountDetailsWithValidData()
        {
            Random r = new Random();
            int generateRandomNum = r.Next(1, 999);
            String validFirstName = "test" + r.Next(1, 999);
            String validLastName = "test" + r.Next(1, 999);
            String validEmailId = "test" + generateRandomNum + "@gmail.com";
            String validUsername = "Trident" + r.Next(1, 999);
            String validPassword = "Test0414@123";
            commonFunctions.WaitForElementLoad(2);
            //commonFunctions.ClickWebelement(clickElement, "click Button");
            commonFunctions.ScrollToElement(textBox);
            commonFunctions.ClickWebelement(textBox, "click Button");
            commonFunctions.Sendkeys(userName, validFirstName, "Name");
            commonFunctions.Sendkeys(userEmail, validLastName, "Email");
            // commonFunctions.WaitForElementLoad(10);
    
            {
                if (userEmail.Selected)
                {
                    commonFunctions.LogMessage("User is able to enter valid data");
                  
                }
                else
                {
                    commonFunctions.WaitForElementLoad(3);
                    commonFunctions.LogMessage("User is not able to enter the invalid data");
                   
                }
            }
        }
             
    }
}
