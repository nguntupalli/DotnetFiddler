using System;
using TechTalk.SpecFlow;

namespace SpecflowFiddlerTests.Steps
{
    [Binding]
    public class CheckNugetPackagesSteps
    {
        [Given(@"the first Name starts with ""(.*)"" in ""(.*)""")]
        public void GivenTheFirstNameStartsWithIn(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the nuget packages nunit (.*)\.(.*) is selected")]
        public void WhenTheNugetPackagesNunit_IsSelected(Decimal p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The Nunit package is added")]
        public void ThenTheNunitPackageIsAdded()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
