using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessTcns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTcn.Text.Tcns.Test
{   [TestClass] 	
    public class TcnsFromTxtFileTest
    {
        protected static string path = @"C:\TCNs.txt";
        [TestMethod]
        public void IsTrueIfIdExistInTcnList()
        {
            var testTcn = new TcnDto();
            testTcn.Id = 4001;
            testTcn.Tcn = 134120065003400;
            var tcnsFromTxtFile = new TcnsFromTxtFile(path);
            var tcnList = new List<TcnDto>(tcnsFromTxtFile.GenerateList());
            Assert.IsTrue(tcnList.Exists(t => t.Id == testTcn.Id));            
        }
    }
}
