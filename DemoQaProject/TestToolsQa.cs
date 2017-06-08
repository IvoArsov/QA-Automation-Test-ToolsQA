using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQaProject.Models;
using DemoQaProject.Pages.AutomationPracticePage;
using DemoQaProject.Pages.DropablePage;
using DemoQaProject.Pages.ResizablePage;
using DemoQaProject.Pages.ToolsQAHomePage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DemoQaProject
{
    [TestFixture]
    public class TestToolsQa
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
           
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status ==
                               TestStatus.Failed)
            {
                string filename = ConfigurationManager.AppSettings["Logs"] +
                              TestContext.CurrentContext.Test.Name + ".txt";
                
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                File.WriteAllText(filename, TestContext.CurrentContext
                                                   .Test.FullName +
                                                   "      " + 
                                                   TestContext.CurrentContext.WorkDirectory +
                                                   "    " +
                                                   TestContext.CurrentContext.Result.PassCount);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext
                                                        .Test.Name + ".jpg",
                                                ScreenshotImageFormat.Jpeg);
            }

            this.driver.Quit();

        }

        [Test]
        [Property("ToolsQa", 3)]
        public void HandlePopUp()
        {
            var automationPage = new AutomationPage(this.driver);
            var homePage = new ToolsQaHomePage(this.driver);

            this.driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";
            string firstTab = this.driver.WindowHandles.Last();
            automationPage.NewTabBtn.Click();
            this.driver.SwitchTo().ActiveElement();
            string secondTab = this.driver.WindowHandles.Last();

            this.driver.SwitchTo().Window(firstTab);
            this.driver.SwitchTo().Window(secondTab);
            this.driver.SwitchTo().Window(firstTab);
            this.driver.SwitchTo().Window(secondTab);

            Assert.AreEqual("http://20tvni1sjxyh352kld2lslvc.wpengine.netdna-cdn.com/wp-content/uploads/2014/08/Toolsqa.jpg", homePage.Logo.GetAttribute("src"));
            Assert.AreEqual(2, this.driver.WindowHandles.Count);
        }

        //[Test]
        //[Property("ToolsQa", 3)]
        //public void DragAndDrop()
        //{
        //    var droppablePage = new DroppablePage(this.driver);
        //    this.driver.Navigate().GoToUrl(droppablePage.URL);
        //    Actions builder = new Actions(this.driver);
        //
        //    var drag = builder.DragAndDrop(droppablePage.Source, droppablePage.Target);
        //    drag.Perform();
        //
        //    Assert.AreEqual("ui-widget-header ui-droppable ui-state-highlight", droppablePage.Target.GetAttribute("class"));
        //}

        

        
    }
} 
