using Appointment.Application.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Appointment.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAgeMethod()
        {
            var birthdate = DateTime.Parse("1992-03-31");

            var age = birthdate.GetCurrentAge();

            Assert.AreEqual("29", age);
        }
    }
}
