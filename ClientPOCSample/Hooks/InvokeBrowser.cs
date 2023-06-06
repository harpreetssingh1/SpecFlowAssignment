
using Automation.Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 2)]
namespace ClientPOCSample.Hooks
{
    [Binding]
    public sealed class InvokeBrowser 
    {

        private readonly ScenarioContext scenarioContext;
        public InvokeBrowser(ScenarioContext scenario)
        {
            scenarioContext = scenario;
        }
        [BeforeScenario]
        public void BeforeScenario()
        {

            SeleniumDriver seleniumDriver = new SeleniumDriver(scenarioContext);
            scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
        
        
    }
}
