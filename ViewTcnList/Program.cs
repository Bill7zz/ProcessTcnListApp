using System;
using System.Collections.Generic;
using ProcessTcns;
using ProcessTcns.ListTcnByMode;

namespace ViewTcnList
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\TCNs.txt";
            var tcnsFromTxtFile = new TcnsFromTxtFile(path);
            var baseTcnList = new List<TcnDto>(tcnsFromTxtFile.GetList());

            Console.WriteLine("***Original List ****\n");
            foreach (var t in baseTcnList)
                Console.WriteLine($"{t.Id} {t.Tcn}");

            var tcnsByMaxMode = new TcnsByMaxMode();
            var tcnsByMinMode = new TcnsByMinMode();

            var MaxTcnList = new List<TcnDto>(tcnsByMaxMode.GetList(baseTcnList));
            var MinTcnList = new List<TcnDto>(tcnsByMinMode.GetList(baseTcnList));

            Console.WriteLine("\n***List of tcn with max value****\n");
            foreach (var t in MaxTcnList)
                Console.WriteLine($"{t.Id} {t.Tcn}");

            Console.WriteLine("\n***List of tcn with min value****\n");
            foreach (var t in MinTcnList)
                Console.WriteLine($"{t.Id} {t.Tcn}");

            Console.ReadKey();
        }
    }
}
