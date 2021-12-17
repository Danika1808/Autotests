using System.Threading;
using Autotests.Models.Task;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Autotests.Helpers.Tests
{
    public class TaskHelper : HelperBase
    {
        public TaskHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        private IWebElement GetTaskElementByTitle(string title) =>
            (IWebElement) ApplicationManager.Js.ExecuteScript(
                $"return [...document.querySelectorAll('.tc_title')].find(x => x.innerText === '{title}');");

        public void AddItem(CreateData createData)
        {
            //Navigate main
            ApplicationManager.NavigationHelper.NavigateMain();
            Thread.Sleep(1000);
            
            //Open add panel
            var addButton = (IWebElement) ApplicationManager.Js.ExecuteScript(
                "return document.getElementById('nav_add');");
            addButton.Click();
            //Fill task title
            Thread.Sleep(500);
            var taskTitle = (IWebElement) ApplicationManager.Js.ExecuteScript(
                "return document.getElementById('firstTitle');");
            taskTitle.Click();
            taskTitle.SendKeys(createData.TaskData.Title);
            //Save task
            var saveBtn = (IWebElement) ApplicationManager.Js.ExecuteScript(
                "return document.querySelector('.tray_footer .btn');");
            saveBtn.Click();
            Thread.Sleep(500);
            
            //Assert created
            var task = GetTaskElementByTitle(createData.TaskData.Title);
            Assert.IsNotNull(task);
        }

        public void EditItem(EditData editData)
        {
            AddItem(new CreateData(editData.OldTaskData));
            
            //Open title edit field
            var taskTitle = GetTaskElementByTitle(editData.OldTaskData.Title);
            taskTitle.Click();
            //Edit title
            var taskTitleField = taskTitle.FindElement(By.ClassName("cellText"));
            taskTitleField.SendKeys(Keys.Control + "a" + Keys.Backspace);
            taskTitleField.SendKeys(editData.NewTaskData.Title);
            taskTitleField.SendKeys(Keys.Enter);
            Thread.Sleep(500);
            
            //Assert edited
            var task = GetTaskElementByTitle(editData.NewTaskData.Title);
            Assert.IsNotNull(task);
        }

        public void DeleteItem(DeleteData deleteData)
        {
            AddItem(new CreateData(deleteData.TaskData));
            
            //Delete
            var taskTitle = GetTaskElementByTitle(deleteData.TaskData.Title);
            var taskEl = taskTitle.FindElement(By.XPath(".."));
            taskEl.FindElement(By.CssSelector(".cellTrash")).Click();
            Thread.Sleep(100);
            taskEl.FindElement(By.CssSelector(".delYes")).Click();
            Thread.Sleep(500);
            
            //Assert deleted
            var task = GetTaskElementByTitle(deleteData.TaskData.Title);
            Assert.IsNull(task);
        }
    }
}