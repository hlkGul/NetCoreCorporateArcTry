using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Constants
{
    //basit bir mesaj icerdigi icin statik newlwnmesine gerek yok
    public static class Messages
    {
        //public ler pascalcase
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi gecersiz";
        public static string MaintenanceTime = "Bakım asamasında";
        public static string ProductListed = "Ürünler Listelendi";

        public static string ProductCountOfCategoryError = "Urun miktarı maksimumu aşıyor";

        public static string ProductNameIsSame = "Boyle bir urun ismi zaten bulunmakta";

        public static string CategoryCountBounded = "Kategori sayısı maksimum";

        public static string AuthorizationDenied = "Yetkilendirme Reddedildi.";

        public static string UserRegistered = "Kayıt Olundu.";

        public static string UserNotFound = "Kullanici Bulunamadi.";
        public static string PasswordError = "Sifre Hatali";
        public static string SuccessfulLogin = "Basarili Giris";
        public static string UserAlreadyExists = "Kullanici Zaten Var.";
        public static string AccessTokenCreated = "Access Token Created";
    }

}