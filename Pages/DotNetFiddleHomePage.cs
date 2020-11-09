using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using SpecflowFiddlerTests.Hooks;
using System.Threading;

namespace SpecflowFiddlerTests.Pages
{
    public class DotNetFiddleHomePage
    {
        public RemoteWebDriver _driver;
        public Logger logger = LogManager.GetCurrentClassLogger();
        public WebDriverWait wait;

        By lblLastRuntime = By.XPath("//*[@id='stats']/table/tbody/tr[1]/td[2]");
        By lblOutput = By.Id("output");
        By btnRunButton = By.Id("run-button");
        By txtSearch = By.CssSelector("input[class='new-package form-control input-sm']");
        By sddNunit = By.Id("ui-id-1");
        By sddNunit312 = By.XPath("//*[@id='menu']/li[1]/ul/li[1]/a");
        By lblOnDisk = By.XPath("//*[@id='CodeForm']/div[2]/div[2]/div[5]/div/div/ul/li/div/a/i");
        By btnShare = By.Id("Share");
        By txtShareLink = By.Id("ShareLink");
        By btnHideOptionsPanel = By.XPath("//*[@id='CodeForm']/div[2]/div[2]/div[1]/button[1]");
        By pnlOptionsPanel = By.XPath("//*[@id='CodeForm']/div[2]/div[2]");
        By btnSaveButton = By.Id("save-button");
        By txtEmail = By.Id("Email");
        By btnGettingStarted = By.PartialLinkText("Getting Started");
        By btnBacktoEditor = By.PartialLinkText("Back To Editor");

        public DotNetFiddleHomePage(RemoteWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        public void NavigatetoDotNetFiddlerPage()
        {
            string url = "https://dotnetfiddle.net/";
            _driver.Url = url;
            logger.Info($"Opened Url=>{url}");
         }

        public string GetRunTimeSeconds()
        {
            string lastRuntime;
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(lblLastRuntime));
                lastRuntime = _driver.FindElement(lblLastRuntime).Text;
            }

            catch (StaleElementReferenceException)
            {
                _driver.Navigate().Refresh();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(lblLastRuntime));
                lastRuntime = _driver.FindElement(lblLastRuntime).Text;
            }
            var RuntimeSeconds = lastRuntime.Split(':')[2];
            var Seconds = RuntimeSeconds.Split(' ')[0];
            return RuntimeSeconds;
        }

        public string GetOutputText()
        {
            string outputText = _driver.FindElement(lblOutput).Text;
            return outputText;
        }

        public void ClickRunButton()
        {
            string beforeRunseconds = GetRunTimeSeconds();
            _driver.FindElement(btnRunButton).Click();

            string afterRunseconds = GetRunTimeSeconds();
            int time_in_seconds = 10;

            while (beforeRunseconds == afterRunseconds)
            {
                afterRunseconds = GetRunTimeSeconds();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time_in_seconds);

                if (beforeRunseconds != afterRunseconds)
                {
                    logger.Info($"Run time stats seconds have changed from=>{beforeRunseconds}to{afterRunseconds}");
                    break;
                }
                else
                {
                    time_in_seconds++;
                }
            }
        }

        public void InstallNugetPackage(string name)
        {
            var firstname = name.Split(' ')[0];

            if (firstname.StartsWithAny("A", "B", "C", "D", "E"))
            {
                try
                {
                     wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(lblLastRuntime));
                    _driver.FindElement(txtSearch).SendKeys("nUnit (3.12.0)");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(sddNunit));
                    _driver.FindElement(sddNunit).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(sddNunit312));
                    _driver.FindElement(sddNunit312).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(lblOnDisk));

                }
                catch (StaleElementReferenceException)
                {
                    //wait until the element is visible again
                    _driver.Navigate().Refresh();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(lblLastRuntime));
                    _driver.FindElement(txtSearch).SendKeys("nUnit (3.12.0)");
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(sddNunit));
                    _driver.FindElement(sddNunit).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(sddNunit312));
                    _driver.FindElement(sddNunit312).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(lblOnDisk));
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        public void AssertNugetPackage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(lblOnDisk));
            Assert.IsTrue(_driver.FindElement(lblOnDisk).Displayed);
        }

        public string ClickShareLink(string name)
        {
            var firstname = name.Split(' ')[0];
            var linkValue = "";

            if (firstname.StartsWithAny("F", "G", "H", "I", "J", "K"))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(btnShare));
                    _driver.FindElement(btnShare).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(txtShareLink));
                    _driver.FindElement(txtShareLink).Click();
                    linkValue = _driver.FindElement(txtShareLink).GetAttribute("value");
                }
                catch (StaleElementReferenceException)
                {
                    //wait until the element is visible again
                    _driver.Navigate().Refresh();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(btnShare));
                    _driver.FindElement(btnShare).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(txtShareLink));
                    _driver.FindElement(txtShareLink).Click();
                    linkValue = _driver.FindElement(txtShareLink).GetAttribute("value");
                }
                catch (ElementClickInterceptedException)
                {
                    //Thread.Sleep(10000);
                    //_driver.FindElement(txtShareLink).Click();
                    linkValue = _driver.FindElement(txtShareLink).GetAttribute("value");
                }
                catch (Exception ex)
                {
                    throw (ex);
                }                
            }
            return linkValue;
        }

        public void AssertSharelink(string linkValue)
        {
            Assert.IsTrue(linkValue.StartsWith("https://dotnetfiddle.net/"));
        }

        public void ClickHideOptionsPanel(string name)
        {
            var firstname = name.Split(' ')[0];

            if (firstname.StartsWithAny("L", "M", "N", "O", "P"))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(btnHideOptionsPanel));
                    _driver.FindElement(btnHideOptionsPanel).Click();
                }

                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        public void AssertOptionsPanelisHidden()
        {
            Assert.AreNotEqual("left: 0px;", _driver.FindElement(pnlOptionsPanel).GetAttribute("style"));
        }

        public void ClickSaveButton(string name)
        {
            var firstname = name.Split(' ')[0];

            if (firstname.StartsWithAny("Q", "R", "S", "T", "U"))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(btnSaveButton));
                    _driver.FindElement(btnSaveButton).Click();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        public void AssertLoginDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(txtEmail));
            Assert.IsTrue(_driver.FindElement(txtEmail).Displayed);
        }

        public void ClickGettingStartedButton(string name)
        {
            var firstname = name.Split(' ')[0];

            if (firstname.StartsWithAny("V", "W", "X", "Y", "Z"))
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(btnGettingStarted));
                    _driver.FindElement(btnGettingStarted).Click();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        public void AssertBacktoEditorDisplayed()
        {
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(btnBacktoEditor));
            Assert.IsTrue(_driver.FindElement(btnBacktoEditor).Displayed);
        }
    }
}

