using System;
using System.Collections.Generic;

namespace ProcessTcns.ListTcnByMode
{
    public class TcnsByMaxMode : AbstrabTcnsByMode
    {              
        public override List<TcnDto> GetList(List<TcnDto> baseTcnList)
        {            
            var MaxTcnList = new List<TcnDto>();
            
            foreach(var tcn in baseTcnList)
            {
                if (MaxTcnList.Exists(t => t.Id == tcn.Id))                   
                {
                    Update(tcn, MaxTcnList); 
                }
                else
                    MaxTcnList.Add((tcn));
            }
            return MaxTcnList;
        }
        protected override void Update(TcnDto tcnInBaseList, List<TcnDto> maxTcnList)
        {
            var index = maxTcnList.FindIndex(t => t.Id == tcnInBaseList.Id);
            if (maxTcnList[index].Tcn < tcnInBaseList.Tcn)
            {
                maxTcnList.RemoveAt(index);
                maxTcnList.Insert(index, tcnInBaseList);
            }
        
        }
    }
}
