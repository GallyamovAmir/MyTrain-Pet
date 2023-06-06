using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrain;
using System;
using System.Linq;

namespace MyTrainUnit
{
    [TestClass]
    public class AddWagon
    {
        [TestMethod]
        public void TestAddWagonMethod()
        {
            //Arrange
            var db = new MyTrainEntities();
            string name = "Синий стриж";
            string count = "10";
            int trainId = 5;
            int typeId = 1;
            int beforeCount = db.Wagons.ToList().Count();
            int afterCount;
            //Act

              

                Wagons wagon = new Wagons();
                wagon.Name = name;
                wagon.Count = count;
                wagon.TrainsId = trainId;
                wagon.TypeId = typeId;
                db.Wagons.Add(wagon);
                db.SaveChanges();

               
                afterCount = db.Wagons.ToList().Count();

            //Assert
            Assert.AreNotEqual(beforeCount, afterCount);
        }
    }
}
