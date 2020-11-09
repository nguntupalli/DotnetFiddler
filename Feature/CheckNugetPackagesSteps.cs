using System;
using TechTalk.SpecFlow;

namespace SpecflowFiddlerTests.Feature
{
    [Binding]
    public class CheckNugetPackagesSteps
    {
        [Given(@"the first Name starts with (.*) in (.*)")]
        public void GivenTheFirstNameStartsWithIn(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
