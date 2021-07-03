using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //mesaj ve islem sonucunu IResulttan alıp tekrar yazmamak icin ekstradan IDataResult data icerecek.
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
