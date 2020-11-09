using NUnit.Framework;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SpecflowFiddlerTests.Hooks
{
    [Binding]
    [Parallelizable(ParallelScope.Children)]
    public class Hooks
    {
        public RemoteWebDriver Driver;

        public Hooks(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }

    }
}