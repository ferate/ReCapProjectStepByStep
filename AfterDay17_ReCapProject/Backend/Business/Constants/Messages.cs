using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static readonly string SaveSuccessful = "Kaydetme İşlemi Başarılı";
        public static readonly string SaveFailed = "Kaydetme İşlemi Sırasında Hata Oluştu";
        public static readonly string DeleteSuccessful = "Silme İşlemi Başarılı";
        public static readonly string DeleteFailed = "Silme İşlemi Sırasında Hata Oluştu";
        public static readonly string UpdateSuccessful = "Güncelleme İşlemi Başarılı";
        public static readonly string UpdateFailed = "Güncelleme İşlemi Sırasında Hata Oluştu";
        public static readonly string ListedSuccessful = "Listeleme İşlemi Başarılı";
        public static readonly string ListedFailed = "Listeleme İşlemi Sırasında Hata Oluştu";


        public static readonly string AuthorizationDenied = "Yetkiniz yok";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";



    }
}
