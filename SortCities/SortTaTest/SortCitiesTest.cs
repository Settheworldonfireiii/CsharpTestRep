using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortCities;
using System.Collections.Generic;

namespace SortTestProj
{
    [TestClass]
    public class SortCitiesTest
    {
        //тестируем на пустой ввод
        [TestMethod]
        [ExpectedException(typeof(EmptyField), "one or more of the fields is empty or null")]
        public void TestEmptyInput()
        {
            //Arrange
            Sortt sorttobj = new Sortt();
            var res = new List<Tuple<String, String>>();
            var inittestdata = new List<Tuple<String, String>>()
            {
                Tuple.Create("Tel Aviv", "Ottawa"),
                Tuple.Create("", "Mombasa"),
                Tuple.Create("Kuala Lumpur", "New York")
            };
            //Act
            res = Sortt.SortCitiesFunct(inittestdata);
          }

        //тестируем на нулевой ввод
        [TestMethod]
        [ExpectedException(typeof(EmptyField), "one or more of the fields is empty or null")]
        public void TestNullInput()
        {
            //Arrange
            Sortt sorttobj = new Sortt();
            var res = new List<Tuple<String, String>>();
            var tuple = Tuple.Create<string, string>(null, null);
            var inittestdata = new List<Tuple<String, String>>()
            {
                Tuple.Create("Tel Aviv", "Ottawa"),
                tuple,
                Tuple.Create("Kuala Lumpur", "New York")
            };
            //Act
            res = Sortt.SortCitiesFunct(inittestdata);
        }

        //тестируем всю функцию
        [TestMethod]
        public void SortCitiesFunctTest()
        {
            //Arrange
            Sortt sorttobj = new Sortt();
            var inittestdata = new List<Tuple<String, String>>()
            {
                Tuple.Create("Tel Aviv", "Ottawa"),
                Tuple.Create("Moscow", "Mombasa"),
                Tuple.Create("Kuala Lumpur", "New York"),
                Tuple.Create("Minsk","Moscow"),
                Tuple.Create("New York", "Bangalore"),
                Tuple.Create("San Francisco", "Shenzhen"),
                Tuple.Create("Bangalore", "Tel Aviv"),
                Tuple.Create("Mombasa", "Kuala Lumpur"),
                Tuple.Create("Ottawa", "San Francisco"),
            };
            var rightresult = new List<Tuple<String, String>>()
           {
               Tuple.Create("Minsk","Moscow"),
               Tuple.Create("Moscow", "Mombasa"),
               Tuple.Create("Mombasa", "Kuala Lumpur"),
               Tuple.Create("Kuala Lumpur", "New York"),
               Tuple.Create("New York", "Bangalore"),
               Tuple.Create("Bangalore", "Tel Aviv"),
               Tuple.Create("Tel Aviv", "Ottawa"),
               Tuple.Create("Ottawa", "San Francisco"),
               Tuple.Create("San Francisco", "Shenzhen")
           };
            //Act
            var result = Sortt.SortCitiesFunct(inittestdata);
            //Assert
            CollectionAssert.AreEquivalent(rightresult, result, "the test failed");
        }

        //тестируем первую составляющую
        [TestMethod]
        public void FirstInInitTest()
        {
            //Arrange
            Sortt sorttobj = new Sortt();
            var result_mylst = new List<Tuple<String, String>>();
            var inittestdata = new List<Tuple<String, String>>()
            {
                Tuple.Create("Tel Aviv", "Ottawa"),
                Tuple.Create("Moscow", "Mombasa"),
                Tuple.Create("Kuala Lumpur", "New York"),
                Tuple.Create("Minsk", "Moscow"),
                Tuple.Create("New York", "Bangalore"),
                Tuple.Create("San Francisco", "Shenzhen"),
                Tuple.Create("Bangalore", "Tel Aviv"),
                Tuple.Create("Mombasa", "Kuala Lumpur"),
                Tuple.Create("Ottawa", "San Francisco")
            };
            var rightresult = new List<Tuple<String, String>>()
           {
               Tuple.Create("Tel Aviv", "Ottawa"),
               Tuple.Create("Ottawa", "San Francisco")
           };
            //Act
            Sortt.FirstInInit(inittestdata, result_mylst);

            //Assert
            CollectionAssert.AreEquivalent(rightresult, result_mylst, "the test failed");
        }

        //тестируем вторую составляющую
        [TestMethod]
        public void SortAfterInitFirstTest()
        {
            //Arrange
            Sortt sorttobj = new Sortt();
            var result_mylst = new List<Tuple<String, String>>()
            {
               Tuple.Create("Tel Aviv", "Ottawa"),
               Tuple.Create("Ottawa", "San Francisco")
            };
            var inittestdata = new List<Tuple<String, String>>()
            {
                Tuple.Create("Moscow", "Mombasa"),
                Tuple.Create("Kuala Lumpur", "New York"),
                Tuple.Create("Minsk", "Moscow"),
                Tuple.Create("New York", "Bangalore"),
                Tuple.Create("San Francisco", "Shenzhen"),
                Tuple.Create("Bangalore", "Tel Aviv"),
                Tuple.Create("Mombasa", "Kuala Lumpur"),
            };
            var rightresult = new List<Tuple<String, String>>()
           {
               Tuple.Create("Tel Aviv", "Ottawa"),
               Tuple.Create("Ottawa", "San Francisco"),
               Tuple.Create("San Francisco", "Shenzhen")
           };
            //Act
            Sortt.SortAfterInitFirst(inittestdata, result_mylst);

            //Assert
            CollectionAssert.AreEquivalent(rightresult, result_mylst, "the test failed");
        }

        //тестируем третью составляющую
        [TestMethod]
        public void SortBeforeInitFirstTest()
        {
            //Arrange
            Sortt sorttobj = new Sortt();
            var result_mylst = new List<Tuple<String, String>>()
            {
               Tuple.Create("Tel Aviv", "Ottawa"),
               Tuple.Create("Ottawa", "San Francisco"),
               Tuple.Create("San Francisco", "Shenzhen")
            };
            var inittestdata = new List<Tuple<String, String>>()
            {
                Tuple.Create("Moscow", "Mombasa"),
                Tuple.Create("Kuala Lumpur", "New York"),
                Tuple.Create("Minsk", "Moscow"),
                Tuple.Create("New York", "Bangalore"),
                Tuple.Create("Bangalore", "Tel Aviv"),
                Tuple.Create("Mombasa", "Kuala Lumpur"),
            };
            var rightresult = new List<Tuple<String, String>>()
           {
               Tuple.Create("Minsk","Moscow"),
               Tuple.Create("Moscow", "Mombasa"),
               Tuple.Create("Mombasa", "Kuala Lumpur"),
               Tuple.Create("Kuala Lumpur", "New York"),
               Tuple.Create("New York", "Bangalore"),
               Tuple.Create("Bangalore", "Tel Aviv"),
               Tuple.Create("Tel Aviv", "Ottawa"),
               Tuple.Create("Ottawa", "San Francisco"),
               Tuple.Create("San Francisco", "Shenzhen")
           };
            //Act
            Sortt.SortBeforeInitFirst(inittestdata, result_mylst);

            //Assert
            CollectionAssert.AreEquivalent(rightresult, result_mylst, "the test failed");
        }

    }
}
