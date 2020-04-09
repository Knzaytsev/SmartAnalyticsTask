using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace ReaderTest
{
    [TestClass]
    public class CSVReaderTest
    {
        [TestMethod]
        public void ReadYear_WithoutYears_ReturnsZeroElements()
        {
            // Arrange.
            var path = @"..\..\data\zero_year.csv";
            var expected = new List<int>();

            // Act.
            var reader = new CSVReader(path);
            var actual = reader.ReadYear();

            // Assert.
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadYear_4Years_Returns4Years()
        {
            // Arrange.
            var path = @"..\..\data\many_years.csv";
            var expected = new List<int>()
            {
                2016,
                2015,
                2014,
                2013
            };

            // Act.
            var reader = new CSVReader(path);
            var actual = reader.ReadYear();

            // Assert.
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadCountriesByYear_11CountriesBy2014_Returns10Countries()
        {
            // Arrange.
            var path = @"..\..\data\11_countries.csv";
            var expected = new List<Country>()
            {
                new Country()
                {
                    Name = "K",
                    CountOrders = 11
                },
                new Country()
                {
                    Name = "J",
                    CountOrders = 10
                },
                new Country()
                {
                    Name = "I",
                    CountOrders = 9
                },
                new Country()
                {
                    Name = "H",
                    CountOrders = 8
                },
                new Country()
                {
                    Name = "G",
                    CountOrders = 7
                },
                new Country()
                {
                    Name = "F",
                    CountOrders = 6
                },
                new Country()
                {
                    Name = "E",
                    CountOrders = 5
                },
                new Country()
                {
                    Name = "D",
                    CountOrders = 4
                },
                new Country()
                {
                    Name = "C",
                    CountOrders = 3
                },
                new Country()
                {
                    Name = "B",
                    CountOrders = 2
                }
            };

            // Act.
            var reader = new CSVReader(path);
            var actual = reader.ReadCountriesByYear(2014);

            // Assert.
            AssertCountries(expected, actual);
        }

        [TestMethod]
        public void ReadCountriesByYear_11CountriesBy2015WithDifferentYears_Returns3Countries()
        {
            // Arrange.
            var path = @"..\..\data\different_years.csv";
            var expected = new List<Country>()
            {
                new Country()
                {
                    Name = "G",
                    CountOrders = 7
                },
                new Country()
                {
                    Name = "E",
                    CountOrders = 5
                },
                new Country()
                {
                    Name = "A",
                    CountOrders = 1
                }
            };

            // Act.
            var reader = new CSVReader(path);
            var actual = reader.ReadCountriesByYear(2015);

            // Assert.
            AssertCountries(expected, actual);
        }

        [TestMethod]
        public void ReadCountriesByYear_11CountriesBy2015WithDifferentYears_Returns2Countries()
        {
            // Arrange.
            var path = @"..\..\data\different_years_2_countries.csv";
            var expected = new List<Country>()
            {
                new Country()
                {
                    Name = "A",
                    CountOrders = 8
                },
                new Country()
                {
                    Name = "E",
                    CountOrders = 5
                }
            };

            // Act.
            var reader = new CSVReader(path);
            var actual = reader.ReadCountriesByYear(2015);

            // Assert.
            AssertCountries(expected, actual);
        }

        private void AssertCountries(List<Country> expected, List<Country> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; ++i)
            {
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].CountOrders, actual[i].CountOrders);
            }
        }
    }
}
