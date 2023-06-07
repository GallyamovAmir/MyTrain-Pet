using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTrainUnit
{
    [TestClass]
    public class ChangeRoleUser
    {
        [TestMethod]
        public void TestChangeRoleUserMethod()
        {
            var db = new MyTrainEntities();
            //Arrange
            int Id = 2;
            int role = 2;
            int useridbefore;
            int userafter;
            //Act
            useridbefore = db.Users.Find(Id).RoleID;
            Users user = db.Users.Find(Id);
            user.RoleID = role;
            db.SaveChanges();
            userafter = db.Users.Find(Id).RoleID;

            
            //Assert
            Assert.AreNotEqual(useridbefore, userafter);
        }
    }
}
