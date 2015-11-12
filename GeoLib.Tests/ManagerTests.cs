// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagerTests.cs" company="ABC">
//   ABC
// </copyright>
// <summary>
//   Defines the ManagerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GeoLib.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using GeoLib.Data;
    using GeoLib.Services;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The manager tests.
    /// </summary>
    [TestClass]
    public class ManagerTests
    {
        /// <summary>
        /// The Test Zip Code Retrieval.
        /// </summary>
        [TestMethod]
        public void TestZipCodeRetrieval()
        {
            var mockZipCodeRepository = new Mock<IZipCodeRepository>();
            var zipCode = new ZipCode()
                             {
                                 City = "LINCOLN PARK",
                                 State = new State() { Abbreviation = "NJ" },
                                 Zip = "07035"
                             };
            mockZipCodeRepository.Setup(repository => repository.GetByZip("07035")).Returns(zipCode);

            var geoService = new GeoManager(mockZipCodeRepository.Object);

            var data = geoService.GetZipInfo("07035");

            Assert.IsTrue(data.City.ToUpper() == "LINCOLN PARK");
            Assert.IsTrue(data.State == "NJ");
        }

        /// <summary>
        /// The test states retrieval.
        /// </summary>
        [TestMethod]
        public void TestStatesRetrieval()
        {
            var mockStateRepository = new Mock<IStateRepository>();
            var states = new List<State>() { new State() { Abbreviation = "NJ" }, new State() { Abbreviation = "NY" }, new State() { Abbreviation = "AR" } };
            mockStateRepository.Setup(repository => repository.Get(true))
                .Returns(states);

            var geoService = new GeoManager(mockStateRepository.Object);

            var data = geoService.GetStates(true).ToList();
            var statesAbbr = states.Select(state => state.Abbreviation).ToList();
            Assert.IsTrue(!statesAbbr.Except(data).Any());
            Assert.IsTrue(statesAbbr.Count == data.Count);
        }
    }
}
