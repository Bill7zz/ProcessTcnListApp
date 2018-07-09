using ProcessTcns;
using ProcessTcns.ListTcnByMode;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ViewTcnList
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)//// TODO: Create a full Windows Form for UX
        {
            Console.WriteLine("*** Welconme to TCN List APP ***");
            Console.WriteLine("Press Enter to choose a file to process");
            Console.ReadKey();

            var path = ChooseFile();
            var tcnsFromTxtFile = new TcnsFromTxtFile(path);
            var list = new List<TcnDto>(tcnsFromTxtFile.GenerateList());

            var tcnsByMaxMode = new TcnsByMaxMode();
            var tcnsByMinMode = new TcnsByMinMode();

            var MaxTcnList = new List<TcnDto>(tcnsByMaxMode.ProcessList(list));
            var MinTcnList = new List<TcnDto>(tcnsByMinMode.ProcessList(list));
        
            ShowList(list, "***Original List ****\n");
            ShowList(MaxTcnList, "\n***List of tcn with max value****\n");
            ShowList(MinTcnList, "\n***List of tcn with min value****\n");

            Console.ReadKey();
        }
        private static void ShowList(List<TcnDto> list, string message)
        {        
            Console.WriteLine(message);
            foreach (var t in list)
                Console.WriteLine($"{t.Id} {t.Tcn}");
        }
        private static string ChooseFile()
        {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.ShowDialog();
                return openFile.FileName;        
        }
    }
}
