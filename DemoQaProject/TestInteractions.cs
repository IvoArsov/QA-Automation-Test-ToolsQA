using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoQaProject.Pages.DraggablePage;
using DemoQaProject.Pages.DropablePage;
using DemoQaProject.Pages.ResizablePage;
using DemoQaProject.Pages.SelectablePage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace DemoQaProject
{
    [TestFixture]
    class TestInteractions
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
                                                   "\n" +
                                                   TestContext.CurrentContext.WorkDirectory +
                                                   "\n" +
                                                   TestContext.CurrentContext.Result.PassCount);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext
                                                        .Test.Name + ".jpg",
                                                ScreenshotImageFormat.Jpeg);
            }

           this.driver.Quit();
        }

        [Test]
        [Property ("DragAndDrop", 1)]
        public void DragAndDrop()
        { 
            var droppablePage = new DroppablePage(this.driver);
            this.driver.Navigate().GoToUrl(droppablePage.URL);
            Actions builder = new Actions(this.driver);

            var drag = builder.DragAndDrop(droppablePage.Source, droppablePage.Target);
            drag.Perform();

            Assert.AreEqual("ui-widget-header ui-droppable ui-state-highlight", droppablePage.Target.GetAttribute("class"));
        }

        [Test]
        [Property("DragAndDrop", 1)]
        public void DragAndDropPropagationOuter()
        {
            var droppablePage = new DroppablePage(this.driver);
            this.driver.Navigate().GoToUrl(droppablePage.URL);
            droppablePage.PreventPropagationBtn.Click();
            Actions builder = new Actions(this.driver);

            var drag = builder.DragAndDrop(droppablePage.PreventPropagationSource, droppablePage.PreventPropagationOuterTarget);
            drag.Perform();

            droppablePage.AssertDroppableOuterMsgExist();
        }

        [Test]
        [Property("DragAndDrop", 1)]
        public void DragAndDropPropagationInner()
        {
            var droppablePage = new DroppablePage(this.driver);
            this.driver.Navigate().GoToUrl(droppablePage.URL);
            droppablePage.PreventPropagationBtn.Click();
            Actions builder = new Actions(this.driver);

            var drag = builder.DragAndDrop(droppablePage.PreventPropagationSource, droppablePage.PreventPropagationInnerTarget);
            drag.Perform();

            droppablePage.AssertDroppableInnerMsgExist();
        }

        [Test]
        [Property("DragAndDrop", 1)]
        public void DragAndDropRevertable_IsDroppedMsgExist()
        {
            var droppablePage = new DroppablePage(this.driver);
            this.driver.Navigate().GoToUrl(droppablePage.URL);
            droppablePage.RevertDraggablePositionBtn.Click();
            Actions builder = new Actions(this.driver);

            var drag = builder.DragAndDrop(droppablePage.RevertableSource, droppablePage.RevertableTarget);
            drag.Perform();

            droppablePage.AssertRevertDroppedMsgExist();
        }

        [Test]
        [Property("DragAndDrop", 1)]
        public void DragAndDropRevertable_Position()
        {
            var droppablePage = new DroppablePage(this.driver);
            this.driver.Navigate().GoToUrl(droppablePage.URL);
            droppablePage.RevertDraggablePositionBtn.Click();
            Actions builder = new Actions(this.driver);

            var drag = builder.DragAndDrop(droppablePage.RevertableSource, droppablePage.RevertableTarget);
            drag.Perform();
            Thread.Sleep(1500);

            droppablePage.AssertRevertDroppedAttrOnRevertableSource(); 
        }

        [Test]
        [Property("DragAndDrop", 1)]
        public void DragAndDrop_NonDropable()
        {
            var droppablePage = new DroppablePage(this.driver);
            this.driver.Navigate().GoToUrl(droppablePage.URL);
            droppablePage.AcceptBtn.Click();
            Actions builder = new Actions(this.driver);

            var drag = builder.DragAndDrop(droppablePage.NonDroppableAcceptSource, droppablePage.DroppableAcceptTarget);
            drag.Perform();

            droppablePage.AssertAceptDropableMsg("accept: ‘#draggableaccept’"); 
        }

        [Test]
        [Property("DragAndDrop", 1)]
        public void DragAndDrop_Dropable()
        {
            var droppablePage = new DroppablePage(this.driver);
            this.driver.Navigate().GoToUrl(droppablePage.URL);
            droppablePage.AcceptBtn.Click();
            Actions builder = new Actions(this.driver);

            var drag = builder.DragAndDrop(droppablePage.DroppableAcceptSource, droppablePage.DroppableAcceptTarget);
            drag.Perform();

            droppablePage.AssertAceptDropableMsg("Dropped!");
        }

        [Test]
        [Property("Dragable", 1)]
        public void DragableRectangle()
        {
            var dragablePage = new DraggablePage(this.driver);
            this.driver.Navigate().GoToUrl(dragablePage.URL);
            Actions builder = new Actions(this.driver);

            builder.DragAndDropToOffset(dragablePage.Source, 10, 20);
            builder.Perform();

            dragablePage.AssertDraggableSourceAttributes();
        }

        [Test]
        [Property("Dragable", 1)]
        public void DragableEventsStartCounter()
        {
            var dragablePage = new DraggablePage(this.driver);
            this.driver.Navigate().GoToUrl(dragablePage.URL);
            dragablePage.GoToEvents();
            Actions builder = new Actions(this.driver);

            builder.DragAndDropToOffset(dragablePage.EventSource, 10, 20)
                   .DragAndDropToOffset(dragablePage.EventSource, 10, 20);
            builder.Perform();

            dragablePage.AsserterStartEventCounter();
        }

        [Test]
        [Property("Dragable", 1)]
        public void DragableEventsStopCounter()
        {
            var dragablePage = new DraggablePage(this.driver);
            this.driver.Navigate().GoToUrl(dragablePage.URL);
            dragablePage.GoToEvents();
            Actions builder = new Actions(this.driver);

            builder.DragAndDropToOffset(dragablePage.EventSource, 10, 20)
                   .DragAndDropToOffset(dragablePage.EventSource, 10, 20);
            builder.Perform();

            dragablePage.AsserterStopEventCounter();
        }

        [Test]
        [Property("Dragable", 1)]
        public void DragableEventsDragCounter()
        {
            var dragablePage = new DraggablePage(this.driver);
            this.driver.Navigate().GoToUrl(dragablePage.URL);
            dragablePage.GoToEvents();
            Actions builder = new Actions(this.driver);
            
            builder.DragAndDropToOffset(dragablePage.EventSource, 10, 20)
                   .DragAndDropToOffset(dragablePage.EventSource, 10, 20);
            builder.Perform();

            dragablePage.AsserterDragEventCounter();
        }

        [Test]
        [Property("Resizable", 1)]
        public void Resizable()
        {
            var resiziblePage = new ResizablePage(this.driver);
            this.driver.Navigate().GoToUrl(resiziblePage.URL);
            Actions builder = new Actions(this.driver);

            var resize = builder.DragAndDropToOffset(resiziblePage.ResizeBtn, 100, 100);
            resize.Perform();

            Assert.IsTrue(resiziblePage.ResizeWindow.Size.Width > 230 && resiziblePage.ResizeWindow.Size.Width < 235);
            Assert.IsTrue(resiziblePage.ResizeWindow.Size.Height > 230 && resiziblePage.ResizeWindow.Size.Height < 235);
        }

        [Test]
        [Property("Selectable", 1)]
        public void Selectable()
        {
            var page = new SelectablePage(this.driver);
            this.driver.Navigate().GoToUrl(page.URL);
            Actions builder = new Actions(this.driver);

            var select = builder.Click(page.SelectableItem);
            select.Perform();

            page.AssertIsSelected();
        }

        [Test]
        [Property("Selectable", 1)]
        public void SelectableResult()
        {
            var page = new SelectablePage(this.driver);
            this.driver.Navigate().GoToUrl(page.URL);
            page.GoToSerialize();
            Actions builder = new Actions(this.driver);

            var select = builder.Click(page.SelectableItemSerialize);
            select.Perform();

            page.AssertSelectableResult();
        }
    }
}
