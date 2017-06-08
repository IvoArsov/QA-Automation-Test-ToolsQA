using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DemoQaProject.Pages.DraggablePage
{
    public static class DraggablePageAsserter
    {
        public static void AssertDraggableSourceAttributes(this DraggablePage page)
        {
            Assert.IsTrue(page.Source.GetAttribute("style") != "position: relative; width: 246px; right: auto; height: 150px; bottom: auto; left: 22px; top: 11px;");
        }

        public static void AsserterStartEventCounter(this DraggablePage page)
        {
            Assert.AreEqual("“start” invoked 2x", page.EventStartCounter.Text);
        }

        public static void AsserterStopEventCounter(this DraggablePage page)
        {
            Assert.AreEqual("“stop” invoked 2x", page.EventStopCounter.Text);
        }

        public static void AsserterDragEventCounter(this DraggablePage page)
        {
            Assert.AreEqual("“drag” invoked 2x", page.EventDragCounter.Text);
        }
    }
}