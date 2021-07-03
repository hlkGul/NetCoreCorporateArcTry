using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //success bilgisi true oldugu icin direkt true gonderildi
        public SuccessResult( string message) : base(true,message)
        {

        }
        //sadece true bilgisi verildi mesaj verilmedi
        //parametresiz constructor base deki tek arametreli ile islem yapacak
        public SuccessResult (): base(true)
        {

        }
    }
}
