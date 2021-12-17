using System;
using System.Threading;
using Autotests.Helpers.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Autotests.Helpers
{
    public class PageLoadHelper : HelperBase
    {
        public PageLoadHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public bool WaitPageLoad()
        {
            var value = new WebDriverWait(ApplicationManager.WebDriver, TimeSpan.FromSeconds(60))
                .Until(d => ((IJavaScriptExecutor) d)
                    .ExecuteScript("return document.readyState")
                    .Equals("complete"));
            Thread.Sleep(5000);
            return value;
        }

        public bool WaitPageLoad(string url)
        {
            ApplicationManager.WebDriver.Navigate().GoToUrl(url);
            return WaitPageLoad();
        }
    }
}