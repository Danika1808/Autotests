using NUnit.Framework;

namespace Autotests.Tests.Authentication
{
    public class AuthenticationTest : BaseTest
    {
        [Test]
        public void SignIn()
        {
            ApplicationManager.AuthenticationHelper.SignIn();
        }
        
        [Test]
        public void SignInInvalid()
        {
            ApplicationManager.AuthenticationHelper.SignInInvalid();
        }
        
        [Test]
        public void SignOut()
        {
            ApplicationManager.AuthenticationHelper.SignOut();
        }
    }
}