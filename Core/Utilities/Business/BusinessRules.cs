using System;
using System.Collections.Generic;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params ile virgulle girilebilecek IResult nesneleri alınabilir
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                //parametre ile gonderilen is kurallarından basarısız olanı business a bildiriyoruz.
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
