using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProcessTcns.ListTcnByMode
{
    public abstract class AbstrabTcnsByMode
    {       
        public abstract List<TcnDto> ProcessList(List<TcnDto> baseTcnList);
        protected abstract void Update(TcnDto tcn, List<TcnDto> tcnlist);      
    }
}
