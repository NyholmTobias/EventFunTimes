using ProjektarbeteAdmin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektarbeteAdmin.Interfaces;
using System;

namespace ProjektarbeteAdmin.Tests
{
    [TestClass()]
    public class MenuTests
    {
        [TestMethod()]
        public void GetInstanceIsNotNull()
        {
            var instance = Menu.GetInstance();
            Assert.IsNotNull(instance);
        }
    }
}