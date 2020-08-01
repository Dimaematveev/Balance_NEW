using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connected.Tests
{
    [TestClass()]
    public class ConnectBLTests
    {
        [TestMethod()]
        public void ConnectOpen_resultConnection_ConnectComplited()
        {
            //arrange
            string res = "Подключение установлено \nDatabase:Test_Action \n";

            //act
            ConnectBL.NameConnectionString = "Test";
            ConnectBL.ConnectOpen();
            //assert
            Assert.AreEqual(ConnectBL._resultConnection, res,$"Наше значение _resultConnection = [{ConnectBL._resultConnection}], а должно быть [{res}]. Это успешное соединение!!!");
        }
        [TestMethod()]
        public void ConnectOpen_IsOpen_True()
        {
            ConnectBL.NameConnectionString = "Test";

            ConnectBL.ConnectOpen();

            Assert.IsTrue(ConnectBL._IsOpen, $"Это успешное соединение поэтому IsOpen должно быть true, а у нас [{ConnectBL._IsOpen}].");
        }


        [TestMethod()]
        public void ExecActionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExecuteProcedureTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataTest()
        {
            Assert.Fail();
        }
    }
}