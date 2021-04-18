using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = " Eklendi";
        public static string Deleted = " Silindi";
        public static string Updated = " Güncellendi";
        public static string CarDescriptionInvalid = "Araba Açıklaması Geçersiz";
        public static string Listed = " Listelendi";
        public static string ErrorCarListed = "Arabalar Listelenemedi";
        public static string MainTenanceTime = "Bakım Zamanı";
        public static string PassLengt = "Şifre Uzuluğu Min. 6 Karakter Olmalı";
        public static string RentalFail = "Bu Araç Kirada";
        public static string CarCountOfBrandError="Bu markada en fazla 15 araç olabilir";
        public static string CarImageLimited="Bir aracın e fazla 5 resmi olabilir";
        public static string AuthorizationDenied="Bu işlei yapmaya yetkiniz yoktur.";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";

        public static string UserRegistered = "Kullanıcı Mevcut.";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
