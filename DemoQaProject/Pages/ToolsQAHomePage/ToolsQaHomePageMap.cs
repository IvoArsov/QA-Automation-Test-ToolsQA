using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoQaProject.Pages.ToolsQAHomePage
{
    public partial class ToolsQaHomePage
    {
        public IWebElement Logo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"page\"]/div[1]/header/div/a/img")); 
            }
        }

    }
}
