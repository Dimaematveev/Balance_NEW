using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connected.Tests
{
    [TestClass()]
    public class ConnectTests
    {
        [TestMethod()]
        public void ConnectOpen_resultConnection_ConnectComplited()
        {
            Connect.NameConnectionString = "Test";

            Connect.ConnectOpen();

            string res = "Подключение установлено \nDatabase:Test_Action \n";

            Assert.AreEqual(Connect._resultConnection, res,$"Наше значение _resultConnection = [{Connect._resultConnection}], а должно быть [{res}]. Это успешное соединение!!!");
        }
        [TestMethod()]
        public void ConnectOpen_IsOpen_True()
        {
            Connect.NameConnectionString = "Test";

            Connect.ConnectOpen();

            Assert.IsTrue(Connect._IsOpen, $"Это успешное соединение поэтому IsOpen должно быть true, а у нас [{Connect._IsOpen}].");
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