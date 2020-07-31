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
        public void ConnectOpenTest()
        {
            Connect.NameConnectionString = "Test";

            Connect.ConnectOpen();

            string res = "Подключение установлено \nDatabase:Test_Action \n";

            Assert.AreEqual(Connect._resultConnection, res);
        }

        [TestMethod()]
        public void ConnectCloseTest()
        {
            Assert.Fail();
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