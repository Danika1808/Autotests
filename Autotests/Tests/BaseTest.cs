// Generated by Selenium IDE

using NUnit.Framework;

namespace Autotests.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected ApplicationManager ApplicationManager { get; private set; }

        [SetUp]
        public void SetUp()
        {
            ApplicationManager = ApplicationManager.GetInstance();;
            ApplicationManager.NavigationHelper.NavigateMain();
        }
    }
}