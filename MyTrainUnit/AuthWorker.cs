using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrain;
using System;
using System.Linq;

namespace MyTrainUnit
{
    [TestClass]
    public class AuthWorker
    {
        [TestMethod]
        public void TestAuthWorkerMethod()
        {
            //Arrange
            Users Worker;
            string PhoneNumber = "89625748052";
            string Password = "12345678";
            //Act

            using (MyTrainEntities db = new MyTrainEntities())
                {
                    Worker = (Users)db.Users.Where(x => x.NumberPhone == PhoneNumber && x.Password == Password).FirstOrDefault();
                }

                //Assert
                Assert.IsNotNull(Worker);
        }
    }
}
