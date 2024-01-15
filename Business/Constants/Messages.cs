using Core.Entities.Concrete;

namespace Business.Constants;

public static class Messages
{
    public static string ProductAdded = "Ürün Başarıyla Eklendi";
    public static string ProductDeleted = "Ürün Başarıyla Silindi";
    public static string ProductUpdated = "Ürün Başarıyla Güncellendi";
    
    public static string UserNotFound = "Kullanıcı Bulunamadı!";
    public static string PasswordError = "Şifre Hatalı";
    public static string SuccessfulyLogin = "Sisteme Giriş Başarılı";
    public static string UserAlreadyExists = "Bu Kullanıcı Zaten Mevcut";
    public static string UserRegistered = "Kullanıcı Başarıyla Kaydedildi";
    public static string AccessTokenCreated = "Access Token Başarıyla Oluşturuldu";
    
    public static string AuthorizationDenied ="Erişim Yetkiniz Yok.!";
}