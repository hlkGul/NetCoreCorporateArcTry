using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

