using System.Collections.Generic;

namespace ProcessTcns
{
    interface ITcnRepository
    {
        List<TcnDto> GetList();
    }
}
