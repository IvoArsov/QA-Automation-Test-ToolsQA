using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DemoQaProject.Pages.SelectablePage
{
    public static class SelectablePageAsserter
    {
        public static void AssertIsSelected(this SelectablePage page)
        {
            Assert.AreEqual("ui-widget-content ui-corner-left ui-selectee ui-selected", page.SelectableItem.GetAttribute("class"));
        }

        public static void AssertSelectableResult(this SelectablePage page)
        {
            Assert.AreEqual("#3", page.SelectableResult.Text);
        }

    }
}
