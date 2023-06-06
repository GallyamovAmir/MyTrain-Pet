using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyTrain;
using System.Linq;
using System.Collections.Generic;

namespace MyTrainUnit
{
    [TestClass]
    public class ShowRoutes
    {
        [TestMethod]
        public void TestShowRoutesMethod()
        {
            //Arrange
            List<Routes> RoutesList;
            //Act
            using (MyTrainEntities db = new MyTrainEntities())
            {
                RoutesList = db.Routes.ToList();
            }

            //Assert
            Assert.IsNotNull(RoutesList);
        }
    }
}
