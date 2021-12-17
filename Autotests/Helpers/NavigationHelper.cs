using Autotests.Helpers.Tests;

namespace Autotests.Helpers
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }
        
        public void NavigateMain() =>
            ApplicationManager.WebDriver.Navigate().GoToUrl(ApplicationManager.Settings.SiteData.MainPageUrl);
    }
}