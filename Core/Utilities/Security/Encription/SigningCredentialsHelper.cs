using System;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encription
{
    public class SigningCredentialsHelper
    {
        //asp.net tarafında da yaptıgımız hash islemlerinde oldugu gibi sistemin tanımasi icin 
        public  static  SigningCredentials CreateSigningCredantials(SecurityKey securityKey) {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);    
        }
    }
}
