using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CategoryAdded = "Kategori Eklendi!";
        public static string CategoryNameInvalid = "Kategori ismi geçersiz!";
        public static string CategoryListed = "Kategoriler Listelendi!!";
        public static string CategoryUpdated = "Kategori Güncellendi!!";
        public static string CategoryDeleted = "Kategori Silindi!!";

        public static string SubCategoryAdded = "Alt Kategori Eklendi!";
        public static string SubCategoryNameInvalid = "Alt Kategori ismi geçersiz!";
        public static string SubCategoryListed = "Alt Kategoriler Listelendi!!";
        public static string SubCategoryUpdated = "Alt Kategori Güncellendi!!";

        public static string ProductAdded = "Ürün Eklendi!";
        public static string ProductNameInvalid = "Ürün ismi geçersiz!";
        public static string MaintenanceTime = "Sistem Bakımda!";
        public static string ProductListed = "Ürünler Listelendi!!";
        public static string ProductUpdated = "Ürün Güncellendi!!";
        public static string ProductCountOfSubCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Aynı isimde zaten başka bi ürün var!!";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";


        public static string AuthorizationDenied = "Yetkiniz yok!!";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

    }
}
