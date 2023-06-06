using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrain;
using System;
using System.Linq;

namespace MyTrainUnit
{
    [TestClass]
    public class AddCity
    {
        [TestMethod]
        public void TestAddCityMethod()
        {
            //Arrange

            Cities city;
            Cities findcity = null;
            string AddCity = "Елабуга";
            //Act
            var db = new MyTrainEntities();

            city = new Cities();
            city.Name = AddCity;
            db.Cities.Add(city);
            db.SaveChanges();

            findcity = db.Cities.Where(x => x.Name == AddCity).FirstOrDefault();
            //Assert
            Assert.IsNotNull(city);

        }
    }
}
