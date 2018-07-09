using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessTcns.ListTcnByMode
{
    public class TcnsByMinMode : AbstrabTcnsByMode
    {       
        public override List<TcnDto> ProcessList(List<TcnDto> baseTcnList)
        {
            var MinTcnList = new List<TcnDto>();

            foreach(var tcn in baseTcnList)
            {
                if (MinTcnList.Exists(t => t.Id == tcn.Id))
                {
                    Update(tcn, MinTcnList);
                }
                else
                    MinTcnList.Add(tcn);
            }
            return MinTcnList;
        }        
        protected override void Update(TcnDto tcnInBaseList, List<TcnDto> minTcnList)
        {
            var index = minTcnList.FindIndex(t => t.Id == tcnInBaseList.Id);
            if (minTcnList[index].Tcn > tcnInBaseList.Tcn)
            {
                minTcnList.RemoveAt(index);
                minTcnList.Insert(index, tcnInBaseList);
            }
        }   
    }
}
