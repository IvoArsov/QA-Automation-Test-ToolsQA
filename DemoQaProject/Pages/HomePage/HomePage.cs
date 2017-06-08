using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoQaProject.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        private String url = "http://demoqa.com/";

        public HomePage(IWebDriver driver) : base(driver) 
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.url);
        }
    }
}
