using SpecflowFiddlerTests.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using NLog;
using OpenQA.Selenium.Remote;

namespace SpecflowFiddlerTests.Steps
{
    [Binding]
    [Parallelizable(ParallelScope.Children)]
    public class RunDotNetFiddleSteps
    {              
        DotNetFiddleHomePage homepage => new DotNetFiddleHomePage(_driver);
        public RemoteWebDriver _driver;
        public ScenarioContext _scenarioContext;
        public string outputText;
        public string beforeSeconds;
        public string afterSeconds;
        
        public Logger logger = LogManager.GetCurrentClassLogger();

        public RunDotNetFiddleSteps(RemoteWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to DotnetFiddle page")]
        public void GivenINavigateToDotnetFiddlePage()
        {
            homepage.NavigatetoDotNetFiddlerPage();       
            beforeSeconds = homepage.GetRunTimeSeconds();
        }

        [Given(@"I click the Run Button")]
        public void GivenIClickTheRunButton()
        {
            homepage.ClickRunButton();
        }
        
        [When(@"I check the output window")]
        public void WhenICheckTheOutputWindow()
        {
            outputText = homepage.GetOutputText();
        }
        
        [Then(@"the output frame should contain the output text as 'Hello World'")]
        public void ThenTheOutputWindowShouldContainTheFollowing()
        {
            afterSeconds = homepage.GetRunTimeSeconds();

            if (beforeSeconds != afterSeconds)
            {
                Assert.IsTrue(outputText == "Hello World");
                logger.Info($"Assertion successful");
            }
            else
            {
                Assert.IsFalse(outputText == "Hello World");
                logger.Info($"BeforeSeconds=>{beforeSeconds}&AfterSeconds=>{afterSeconds} are matching, run button operation did not update the output text");
            }
        }
    }
}
