﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoQaProject.Pages.AutomationPracticePage
{
    public partial class AutomationPage
    {
        public IWebElement NewTabBtn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/p[4]/button"));
                
            }
        }
    }
}
