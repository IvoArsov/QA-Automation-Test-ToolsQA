using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DemoQaProject.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertMailMsgExist(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForEmail.Displayed);
            Assert.AreEqual(text, page.ErrorMessagesForEmail.Text);
        }

        public static void AssertNamesMsgExist(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForNames.Displayed);
            Assert.AreEqual(text, page.ErrorMessagesForNames.Text);
        }

        public static void AssertUsernameMsgExist(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForUsername.Displayed);
            Assert.AreEqual(text, page.ErrorMessagesForUsername.Text);
        }

        public static void AssertPhoneMsgExist(this RegistrationPage page)
        {
            Assert.IsTrue(page.ErrorMessagesForPhone.Displayed);
        }

        public static void AssertShortPhoneMsgExist(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPhone.Displayed);
            Assert.AreEqual(text, page.ErrorMessagesForPhone.Text);
        }

        public static void AssertHobbyMsgExist(this RegistrationPage page)
        {
            Assert.IsTrue(page.ErrorMessagesForHobby.Displayed);
        }

        public static void AssertPasswordMsgExist(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPassword.Displayed);
            Assert.AreEqual(text, page.ErrorMessagesForPassword.Text);
        }

        public static void AssertConfirmPasswordMsgExist(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForConfirmPassword.Displayed);
            Assert.AreEqual(text, page.ErrorMessagesForConfirmPassword.Text);
        }

        public static void AssertInvalidImgPathMsgExist(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForInvalidImgPath.Displayed);
            Assert.AreEqual(text, page.ErrorMessagesForInvalidImgPath.Text);
        }

        public static void AssertPasswordQualityChecker(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.MessageForPasswordQuality.Displayed);
            Assert.AreEqual(text, page.MessageForPasswordQuality.Text);
        }
    }
}
