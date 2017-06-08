using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQaProject.Pages.DropablePage
{
    public partial class DroppablePage
    {
        public IWebElement Source
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"draggableview\"]/p")); }
        }

        public IWebElement Target
        {
            get { return this.Driver.FindElement(By.Id("droppableview")); }
        }

        public IWebElement PreventPropagationBtn
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]")); }
        }

        public IWebElement PreventPropagationSource
        {
            get { return this.Driver.FindElement(By.Id("draggableprop")); }
        }

        public IWebElement PreventPropagationOuterTarget
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"droppableprop\"]/p")); }
        }

        public IWebElement PreventPropagationInnerTarget
        {
            get { return this.Driver.FindElement(By.Id("droppable2-inner")); }
        }

        public IWebElement DroppedMsgPropagationInner
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"droppable2-inner\"]/p")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppable2-inner\"]/p"));
            }
        }

        public IWebElement DroppedMsgPropagationOuter
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"droppableprop\"]/p")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppableprop\"]/p"));
            }
        }

        public IWebElement RevertDraggablePositionBtn
        {
            get { return this.Driver.FindElement(By.Id("ui-id-4")); }
        }

        public IWebElement RevertableSource
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("draggablerevert")));
                return this.Driver.FindElement(By.Id("draggablerevert"));
            }
        }

        public IWebElement NonRevertableSource
        {
            get { return this.Driver.FindElement(By.Id("draggablerevert2")); }
        }

        public IWebElement RevertableTarget
        {
            get { return this.Driver.FindElement(By.Id("droppablerevert")); }
        }

        public IWebElement DroppedMsgRevert
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"droppablerevert\"]/p")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppablerevert\"]/p"));
            }
        }

        public IWebElement AcceptBtn
        {
            get { return this.Driver.FindElement(By.Id("ui-id-2")); }
        }

        public IWebElement NonDroppableAcceptSource
        {
            get { return this.Driver.FindElement(By.Id("draggable-nonvalid")); }
        }

        public IWebElement DroppableAcceptSource
        {
            get { return this.Driver.FindElement(By.Id("draggableaccept")); }
        }

        public IWebElement DroppableAcceptTarget
        {
            get { return this.Driver.FindElement(By.Id("droppableaccept")); }
        }

        public IWebElement DroppableAcceptMsg
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"droppableaccept\"]/p")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppableaccept\"]/p"));
            }
        }
    }
}
