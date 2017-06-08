using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQaProject.Models;
using OpenQA.Selenium;

namespace DemoQaProject.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        private String url = "http://demoqa.com/registration/";

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.url);
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(this.FirstName, user.FirstName);
            Type(this.LastName, user.LastName);
            ClickOnElements(this.MaritalStatus, user.MaritalStatus);
            ClickOnElements(this.Hobbies, user.Hobbies);
            this.CountryOption.SelectByText(user.Country);
            this.MounthOption.SelectByText(user.BirthMonth);
            this.DayOption.SelectByText(user.BirthDay);
            this.YearOption.SelectByText(user.BirthYear);
            Type(this.Phone, user.Phone);
            Type(this.UserName, user.UserName);
            Type(this.Email, user.Email);
            this.UploadButton.Click();
            this.Driver.SwitchTo().ActiveElement().SendKeys(user.Picture);
            Type(this.Description, user.Description);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
            this.SubmitButton.Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        private void ClickOnElements(List<IWebElement> elementStatus, string input)
        {

            char[] inputArr = input.ToCharArray();
            for (int i = 0; i < elementStatus.Count; i++)
            {
                if (inputArr[i] == '1')
                {
                    elementStatus[i].Click();
                }
            }
        }
    }
}
