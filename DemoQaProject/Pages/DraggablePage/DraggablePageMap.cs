using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoQaProject.Pages.DraggablePage
{
    public partial class DraggablePage
    {
        public IWebElement Source
        {
            get { return this.Driver.FindElement(By.Id("draggable")); }
        }

        public IWebElement EventBtn
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-4\"]")); }
        }

        public IWebElement EventSource
        {
            get { return this.Driver.FindElement(By.Id("dragevent")); }
        }

        public IWebElement EventStartCounter
        {
            get { return this.Driver.FindElement(By.Id("event-start")); }
        }

        public IWebElement EventStopCounter
        {
            get { return this.Driver.FindElement(By.Id("event-stop")); }
        }

        public IWebElement EventDragCounter
        {
            get { return this.Driver.FindElement(By.Id("event-drag")); }
        }
    }
}
