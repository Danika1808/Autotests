namespace Autotests.Helpers.Tests
{
    public abstract class HelperBase
    {
        protected HelperBase(ApplicationManager applicationManager)
        {
            ApplicationManager = applicationManager;
        }

        protected ApplicationManager ApplicationManager { get; }
    }
}