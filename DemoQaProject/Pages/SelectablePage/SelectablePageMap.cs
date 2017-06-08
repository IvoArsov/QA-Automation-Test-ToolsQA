using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoQaProject.Pages.SelectablePage
{
    public partial class SelectablePage
    {
        public IWebElement SelectableItem
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[5]")); }
        }

        public IWebElement SerializeBtn
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]")); }
        }

        public IWebElement SelectableResult
        {
            get { return this.Driver.FindElement(By.Id("select-result")); }
        }

        public IWebElement SelectableItemSerialize
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"selectable-serialize\"]/li[3]")); }
        }
    }
}
