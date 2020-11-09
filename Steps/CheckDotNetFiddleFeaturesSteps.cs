using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Windows.Forms;
using OpenQA.Selenium.Remote;
using SpecflowFiddlerTests.Pages;

namespace SpecflowFiddlerTests.Steps
{
    [Binding]
    [Parallelizable(ParallelScope.Children)]
    public class CheckDotNetFiddleFeaturesSteps
    {
        private DotNetFiddleHomePage homepage => new DotNetFiddleHomePage(_driver);
        private RemoteWebDriver _driver;
        string name;
        string linkValue;
        public ScenarioContext _scenarioContext;

        public CheckDotNetFiddleFeaturesSteps(RemoteWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        [Given(@"the first Name starts with (.*) in (.*)")]
        public void GivenTheFirstNameStartsWithLetters(string p0, string p1)
        {
            homepage.NavigatetoDotNetFiddlerPage();
            name = p1.ToUpper();
        }

        [When(@"the (.*) is performed")]
        public void WhenTheCondition(string p0)
        {

            if (p0 == "NuGet Packages: nUnit (3.12.0) is selected")
            {
                homepage.InstallNugetPackage(name);
            }

            if (p0 == "“Share” button is clicked")
            {
                linkValue = homepage.ClickShareLink(name);
            }

            if (p0 == "Options panel hide button is clicked")
            {
                homepage.ClickHideOptionsPanel(name);
            }

            if (p0 == "Save button is clicked")
            {
                homepage.ClickSaveButton(name);
            }

            if (p0 == "Getting started button is clicked")
            {
                homepage.ClickGettingStartedButton(name);
            }
        }

        [Then(@"the (.*) is expected")]
        public void ThenTheOutcome(string p0)
        {
            if (p0 == "nUnit package is added")
            {
                homepage.AssertNugetPackage();
            }

            if (p0 == "the link starts with `https://dotnetfiddle.net/`")
            {
                homepage.AssertSharelink(linkValue);
            }

            if (p0 == "“Options” panel is hidden")
            {
                homepage.AssertOptionsPanelisHidden();
            }

            if (p0 == "Login window is displayed")
            {
                homepage.AssertLoginDisplayed();
            }

            if (p0 == "Back to Editor button appears")
            {
                homepage.AssertBacktoEditorDisplayed();
            }
        }

    }
}

