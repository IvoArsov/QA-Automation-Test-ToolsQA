using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoQaProject.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement heading => Driver.FindElement(By.ClassName("entry-title"));
        public IWebElement regBtn => Driver.FindElement(By.Id("menu-item-374"));
    }
}
