﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoQaProject.Pages.SelectablePage
{
    public partial class SelectablePage : BasePage
    {
        public SelectablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get { return base.url + "selectable/"; }
        }

        public void GoToSerialize()
        {
            SerializeBtn.Click();
        }
    }
}
