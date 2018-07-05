using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessTcns;
using ProcessTcns.ListTcnByMode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTcnsTest.ListTcnByMode.test
{
    [TestClass]
    public class TcnsByMinModeTest
    {
       protected static string path = @"C:\TCNs.txt";
        [TestMethod]
        public void IsFalseIfMaxTcnDosentExistInMinTcnList()
        {                        
            var tcnsFromTxtFile = new TcnsFromTxtFile(path);
            var BaseTcnList = new List<TcnDto>(tcnsFromTxtFile.GetList());
            
            var tcnsByMinMode = new TcnsByMinMode();            
            var MinTcnList = new List<TcnDto>(tcnsByMinMode.GetList(BaseTcnList));

            var result = MinTcnList.Contains(BaseTcnList[5]);
            Console.WriteLine();
            Assert.IsFalse(result);
        }
    }
}
