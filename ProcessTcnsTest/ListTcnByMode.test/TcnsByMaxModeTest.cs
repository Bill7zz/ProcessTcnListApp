using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessTcns;
using ProcessTcns.ListTcnByMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTcnsTest.ListTcnByMode.test
{
    [TestClass]
    public class TcnsByMaxModeTest
    {
        protected static string path = @"C:\TCNs.txt";
        [TestMethod]
        public void IsFalseIfMinTcnDosentExistInMaxTcnList()
        {
            var tcnsFromTxtFile = new TcnsFromTxtFile(path);
            var baseTcnList = new List<TcnDto>(tcnsFromTxtFile.GetList());

            var tcnsByMaxMode = new TcnsByMaxMode();
            var MaxTcnList = new List<TcnDto>(tcnsByMaxMode.GetList(baseTcnList));

            var result = MaxTcnList.Contains(baseTcnList[4]);
            Console.WriteLine();
            Assert.IsFalse(result);

        }

    }
}
