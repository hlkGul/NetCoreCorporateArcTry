using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        //constructor readonly oldugu icin fonksiyonların set proparty si olmasa da burada set yapılabilir
        //succes bilgisini tek parametreli constructor set edecek ikisinin de calısması icin boyle bir yapıuyguladık.
        public Result(bool success, string message):this(success)
        {
            Message = message;

        }
        
        public Result(bool success)
        {
            Success = success;

        }

        //sadece getter oldugu icin lambda exp olabilir
        public bool Success { get; }

        public string Message { get;  }
    }
}
