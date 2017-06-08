using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoQaProject.Pages.ResizablePage
{
    public partial class ResizablePage
    {
        public IWebElement ResizeBtn
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"resizable\"]/div[3]")); }
        }

        public IWebElement ResizeWindow
        {
            get { return this.Driver.FindElement(By.Id("resizable")); }
        }
    }
}
