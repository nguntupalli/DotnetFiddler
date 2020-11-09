using BoDi;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SpecflowFiddlerTests.Hooks
{
    [Binding]
    [Parallelizable(ParallelScope.Children)]
    public class DriverSetup
    {
        private IObjectContainer _objectContainer;
        public RemoteWebDriver Driver;

        public DriverSetup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("headless");
            Driver = new ChromeDriver(options);
            _objectContainer.RegisterInstanceAs(Driver);
        }
    }
}
