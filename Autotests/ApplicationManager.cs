using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Autotests.Helpers;
using Autotests.Helpers.Tests;
using Autotests.Models;
using Autotests.Models.Settings;
using Autotests.Models.Task;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Autotests
{
    public class ApplicationManager
    {
        private static readonly ThreadLocal<ApplicationManager> App = new ThreadLocal<ApplicationManager>();

        #region Selenium
        public IWebDriver WebDriver { get; }
        public IDictionary<string, object> Vars { get; }
        public IJavaScriptExecutor Js { get; }
        #endregion

        #region Data
        public Settings Settings { get; }
        #endregion

        #region TestData
        public CreateData CreateData { get; }
        public EditData EditData { get; }
        public DeleteData DeleteData { get; }
        public static string XmlDataPath { get; } = "..\\..\\..\\..\\data.xml";
        #endregion

        #region Helpers
        public NavigationHelper NavigationHelper { get; }
        public PageLoadHelper PageLoadHelper { get; }
        #endregion
        
        #region TestHelpers
        public AuthenticationHelper AuthenticationHelper { get; }
        public TaskHelper TaskHelper { get; }

        #endregion

        public ApplicationManager()
        {
            //Selenium
            WebDriver = new ChromeDriver(Directory.GetCurrentDirectory());
            Js = (IJavaScriptExecutor) WebDriver;
            Vars = new Dictionary<string, object>();
            //Data
            Settings = Settings.CreateInstance(".\\Data\\Settings.xml");
            //TestData
            CreateData = new CreateData(new TaskData("Create" + DateTimeHelper.CurrentDateTime));
            EditData = new EditData(new TaskData("EditOld" + DateTimeHelper.CurrentDateTime),
                new TaskData("EditNew" + DateTimeHelper.CurrentDateTime));
            DeleteData = new DeleteData(new TaskData("Delete" + DateTimeHelper.CurrentDateTime));
            //Helpers
            NavigationHelper = new NavigationHelper(this);
            PageLoadHelper = new PageLoadHelper(this);
            //TestHelpers
            AuthenticationHelper = new AuthenticationHelper(this);
            TaskHelper = new TaskHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (App.IsValueCreated) return App.Value;

            var newInstance = new ApplicationManager();
            App.Value = newInstance;
            return App.Value;
        }

        ~ApplicationManager()
        {
            try
            {
                WebDriver.Quit();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}