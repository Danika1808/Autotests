using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Autotests.Helpers.Tests
{
    public class AuthenticationHelper : HelperBase
    {
        private bool _isAuthenticated;

        public AuthenticationHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
            _isAuthenticated = false;
        }

        private IWebElement GetProfileButton() =>
            (IWebElement) ApplicationManager.Js.ExecuteScript(
                "return document.getElementById('tn_avatar');");

        private void SignIn(string login, string password)
        {
            if (_isAuthenticated)
            {
                SignOut();
                Thread.Sleep(1000);
            }

            //Navigate main
            ApplicationManager.NavigationHelper.NavigateMain();

            //Fill email
            var email = (IWebElement) ApplicationManager.Js.ExecuteScript(
                "return document.getElementById('email');");
            email.Click();
            email.SendKeys(login);
            //Fill password
            var passwordEl = (IWebElement) ApplicationManager.Js.ExecuteScript(
                "return document.getElementById('pass');");
            passwordEl.Click();
            passwordEl.SendKeys(password);
            //Click sign in button
            var signInButton = (IWebElement) ApplicationManager.Js.ExecuteScript(
                "return document.getElementById('signinbtn');");
            signInButton.Click();

            _isAuthenticated = GetProfileButton() != null;
        }
        
        public void SignIn()
        {
            SignIn(ApplicationManager.Settings.AuthenticationData.ValidLogin,
                ApplicationManager.Settings.AuthenticationData.ValidPassword);

            //Assert profile button exists
            var profileButton = GetProfileButton();
            Assert.IsNotNull(profileButton);
        }

        public void SignInInvalid()
        {
            SignIn(ApplicationManager.Settings.AuthenticationData.InvalidLogin,
                ApplicationManager.Settings.AuthenticationData.InvalidPassword);

            //Assert profile button does not exist
            var profileButton = GetProfileButton();
            Assert.IsNull(profileButton);
        }

        public void SignOut()
        {
            if (!_isAuthenticated)
            {
                SignIn();
                Thread.Sleep(1000);
            }
            _isAuthenticated = false;

            //Navigate main
            ApplicationManager.NavigationHelper.NavigateMain();

            //Open profile panel
            var profileButton = GetProfileButton();
            profileButton.Click();
            //Click sign out button
            Thread.Sleep(100);
            var signOutButton = (IWebElement) ApplicationManager.Js.ExecuteScript(
                "return document.querySelector('.signout > form > :nth-child(3)');");
            signOutButton.Click();

            //Assert sign out text
            var signOutText = (string) ApplicationManager.Js.ExecuteScript(
                "return document.querySelector('.success').innerText;");
            Assert.AreEqual("You have successfully signed out.", signOutText);
        }

        public void AuthenticateAndWait()
        {
            if (_isAuthenticated)
            {
                return;
            }

            SignIn();
            Thread.Sleep(5000);
        }
    }
}