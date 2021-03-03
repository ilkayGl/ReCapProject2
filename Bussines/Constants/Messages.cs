using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bussines.Constants
{
    public static class Messages
    {
        //Brand Messages
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandsListed = "Markalar Listelendi";

        //Car Messages
        public static string CarAdded = "Araba Eklendi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarsListed = "Arabalar Listelendi";

        //Color Messages
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorsListed = "Renkler Listelendi";

        //User Messages
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UsersListed = "Kullanıcılar Listelendi";

        //Customer Messages
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomersListed = "Müşteriler Listelendi";

        //CarImage Messages
        public static string CarImageAdded = "Car Image Eklendi";
        public static string CarImageUpdated = "Araba Resimi Güncellendi";
        public static string CarImageDeleted = "Araba Resimi Silindi";
        public static string CarImagesListed = "Araba Resimleri Listelendi";

        //Rental Messages
        public static string RentalAdded = "Kira Bilgileri Eklendi";
        public static string RentalUpdated = "Kira Bilgileri Güncellendi";
        public static string RentalDeleted = "Kira Bilgileri Silindi";
        public static string RentalsListed = "Kira Bilgileri Listelendi";
        public static string RentalReturned = "Kiralanan Araç Başarıyla İade Edildi";



        //Error Messages
        public static string BrandNameInvalid = "Marka Adı Geçersiz";
        public static string CarNameInvalid = "Araç Adı Geçersiz";
        public static string ColorNameInvalid = "Renk Adı Geçersiz";
        public static string RentalInvalid = "İstediğiniz Araba Mevcut Değil";
        public static string MaintenanceTime = "Bakım Modu";
        public static string CarImageCountOfCarIdError = "Bir arabada sadece 5 fotoğraf olabilir";
        public static string CarImagePathAlreadyExists = "Araba yolu zaten var";
        public static string AuthorizationDenied = "Erişim reddedildi. Yetkili değilsin.";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı mevcut.";
        public static string AccessTokenCreated = "Token oluşturuldu.";


    }
}
