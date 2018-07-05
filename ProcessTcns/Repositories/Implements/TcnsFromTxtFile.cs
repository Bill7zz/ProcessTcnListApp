using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessTcns
{
    public class TcnsFromTxtFile : ITcnRepository
    {
        private readonly string Path;
        public TcnsFromTxtFile(string path)
        {
            Path = path;
        }
        //// TODO: add Using for handle StreamReader
        public List<TcnDto> GetList()
        {
            var line = string.Empty;
            var tcnList = new List<TcnDto>();
            using (var file = new System.IO.StreamReader(Path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var tcnDto = ProcessLine(line);
                    if (tcnDto == null)
                        continue;

                    tcnList.Add(tcnDto);
                }
                return tcnList;
            }
        }
        private TcnDto ProcessLine(string line)
        {
            try
            {
                var lineArray = line.Split(' ');
                if (!lineArray.Any())
                {
                    return null;
                }

                var tcn = new TcnDto
                {
                    Id = Int32.Parse(lineArray[0]),
                    Tcn = long.Parse(lineArray[1])
                };
                return tcn;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error processing line: {line}");
                return null;
                //// TODO: include exception log
            }
        }
    }
}
