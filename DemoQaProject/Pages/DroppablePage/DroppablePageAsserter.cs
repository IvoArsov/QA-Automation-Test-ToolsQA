using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace DemoQaProject.Pages.DropablePage
{
    public static class DroppablePageAsserter
    {
        public static void AssertDroppableOuterMsgExist(this DroppablePage page)
        {
            Assert.IsTrue(page.DroppedMsgPropagationOuter.Displayed);
        }

        public static void AssertDroppableInnerMsgExist(this DroppablePage page)
        {
            Assert.IsTrue(page.DroppedMsgPropagationInner.Displayed);
        }

        public static void AssertRevertDroppedMsgExist(this DroppablePage page)
        {
            Assert.IsTrue(page.DroppedMsgRevert.Displayed);
        }

        public static void AssertRevertDroppedAttrOnRevertableSource(this DroppablePage page)
        {
            Assert.AreEqual("position: relative; width: 100px; right: auto; height: 100px; bottom: auto; left: 0px; top: 0px;", page.RevertableSource.GetAttribute("style"));
        }

        public static void AssertAceptDropableMsg(this DroppablePage page, string text)
        {
            Assert.AreEqual(text, page.DroppableAcceptMsg.Text);
        }
    }
}
