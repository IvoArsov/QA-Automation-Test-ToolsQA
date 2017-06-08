using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQaProject.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement FirstName => Driver.FindElement(By.Id("name_3_firstname"));
        public IWebElement LastName => Driver.FindElement(By.Id("name_3_lastname"));
        public List<IWebElement> MaritalStatus => Driver.FindElements(By.Name("radio_4[]")).ToList();
        public List<IWebElement> Hobbies => Driver.FindElements(By.Name("checkbox_5[]")).ToList();
        private IWebElement CountryDD => this.Driver.FindElement(By.Id("dropdown_7"));
        public SelectElement CountryOption => new SelectElement(CountryDD);
        private IWebElement MounthDD => this.Driver.FindElement(By.Id("mm_date_8"));
        public SelectElement MounthOption => new SelectElement(MounthDD);
        private IWebElement DayDD => this.Driver.FindElement(By.Id("dd_date_8"));
        public SelectElement DayOption => new SelectElement(DayDD);
        private IWebElement YearDD => this.Driver.FindElement(By.Id("yy_date_8"));
        public SelectElement YearOption => new SelectElement(YearDD);
        public IWebElement Phone => this.Driver.FindElement(By.Id("phone_9"));
        public IWebElement UserName => this.Driver.FindElement(By.Id("username"));
        public IWebElement Email => this.Driver.FindElement(By.Id("email_1"));
        public IWebElement UploadButton => this.Driver.FindElement(By.Id("profile_pic_10"));
        public IWebElement Description => this.Driver.FindElement(By.Id("description"));
        public IWebElement Password => this.Driver.FindElement(By.Id("password_2"));
        public IWebElement ConfirmPassword => this.Driver.FindElement(By.Id("confirm_password_password_2"));
        public IWebElement SubmitButton => this.Driver.FindElement(By.Name("pie_submit"));
        public IWebElement SuccessMessage => this.Driver.FindElement(By.ClassName("piereg_message"));

        public IWebElement ErrorMessagesForNames
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span"));
            }
        }

        public IWebElement ErrorMessagesForPhone
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForEmail
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span"));
            }
        }
        
        public IWebElement ErrorMessagesForUsername
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForHobby
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span"));
            }
        }

        public IWebElement ErrorMessagesForPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForConfirmPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span"));
            }
        }


        public IWebElement ErrorMessagesForInvalidImgPath
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[9]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[9]/div/div/span"));
            }
        }

        public IWebElement MessageForPasswordQuality
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("piereg_passwordStrength")));
                return this.Driver.FindElement(By.Id("piereg_passwordStrength"));
            }
        }

        //TODO
    }
}
