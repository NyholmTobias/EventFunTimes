using EventFunTimesAPI.Models;
using EventFunTimesAPI.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace EventFunTimesAPITest.Models
{
    [TestClass()]
    public class CriteriasTests
    {
        private Mock<IWeatherService> _weatherService { get; set; }

        [TestInitialize]
        public void Init()
        {
            _weatherService = new Mock<IWeatherService>();
        }

        [TestMethod()]
        public void CreateCriteriasShouldSetInsideEventFieldToTrue()
        {
            _weatherService.Setup(x => x.GetWeather().Result).Returns(new Weather { WindSpeed = 50, Temperature = -7 });
            var testCriterias = new Criterias(_weatherService.Object);

            Assert.IsTrue(testCriterias.InsideEvent);
        }

        [TestMethod()]
        public void CreateCriteriasShouldSetInsideEventFieldToFalse()
        {
            _weatherService.Setup(x => x.GetWeather().Result).Returns(new Weather { WindSpeed = 2, Temperature = 15 });
            var testCriterias = new Criterias(_weatherService.Object);

            Assert.IsFalse(testCriterias.InsideEvent);
        }
    }
}