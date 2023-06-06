using Automation.Drivers;
using ClientPOCSample.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ClientPOCSample
{
    [Binding]
    public class AssignmentAutomationStepDefinitions
    {

        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        private RegistartionPage Register;
        public AssignmentAutomationStepDefinitions(ScenarioContext scenario)
        {
            scenarioContext = scenario;


        }

        [Given(@"I launch the application")]
        public void ThenILaunchTheApplication(Table table)
        {
            dynamic browserData = table.CreateDynamicInstance();
            driver = scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup(browserData.Browser);
            Register = new RegistartionPage(driver);
            driver.Navigate().GoToUrl("https://demoqa.com/elements");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Then(@"Text Box \(Verification of the details post submission\)")]
        public void ThenTextBoxVerificationOfTheDetailsPostSubmission()
        {
            Register.TextBox();
        }

        [Then(@"Check Box \(Verification of the selected items\)")]
        public void ThenCheckBoxVerificationOfTheSelectedItems()
        {
            Register.CheckBox();
        }

        [Then(@"Web Tables \(Edit the contents of the Web Table\)")]
        public void ThenWebTablesEditTheContentsOfTheWebTable()
        {
            Register.EditWebTable();
        }

        [Then(@"Buttons \(Verify the button selected by the message displayed on button click\)")]
        public void ThenButtonsVerifyTheButtonSelectedByTheMessageDisplayedOnButtonClick()
        {
            Register.Buttons();
        }

        [Then(@"Upload and Download \(Implement logic to perform the required actions\)")]
        public void ThenUploadAndDownloadImplementLogicToPerformTheRequiredActions()
        {
            Register.uploadAndDownload();
        }

        [Then(@"Automation of Alerts, Frame & Windows")]
        public void WhenAutomationOfAlertsFrameWindows()
        {
            Register.alertFrameWindows();
        }

        [Then(@"Enter the invalid data")]
        public void ThenEnterTheInvalidData()
        {
            Register.EnterDetailsWithInvalidData();
        }

        [Then(@"Then Enter the valid data")]
        public void ThenThenEnterTheValidData()
        {
            Register.EnterAccountDetailsWithValidData();
        }


    }
}
