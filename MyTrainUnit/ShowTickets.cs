using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTrainUnit
{
    [TestClass]
    public class ShowTickets
    {
        [TestMethod]
        public void TestShowTicketsMethod()
        {
            //Arrange
            List<Tickets> TicktsList;
            //Act
            using (MyTrainEntities db = new MyTrainEntities())
            {
                TicktsList = db.Tickets.ToList();
            }

            //Assert
            Assert.IsNotNull(TicktsList);
        }
    }
}
