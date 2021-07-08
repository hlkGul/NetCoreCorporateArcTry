using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kullanici giris yaptiginda veritabaninan giderek claimlerini de icerisinde bulunduran jwt üretecek 
        AccessToken CreateToken(User user, List<OperationClaim> operationClaim);
    }
}
