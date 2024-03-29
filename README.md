# .NET 7 ile Northwind API Projesi

Bu projede, Engin Demiroğ'un Backend Geliştirici Kursunu tamamlayarak elde ettiğim bilgi ve becerileri kullanarak .NET 7 ve MySQL ile bir API geliştirdim. Proje, Northwind veritabanının hazır datalarını kullanmakta ve modern yazılım geliştirme tekniklerini entegre etmektedir.

## Özellikler

**.NET 7:** Proje .NET 7 sürümü kullanılarak geliştirildi.  

**MySQL:** Veritabanı olarak MySQL kullanıldı.  

**Autofac:** Dependency injection için Autofac teknolojisi kullanıldı.  

**JWT Token ile Kimlik Doğrulama:** Güvenli API erişimi için JWT tabanlı kimlik doğrulama sistemi entegre edildi.  

**Fluent Validation:** Giriş verilerinin doğrulanması için Fluent Validation kütüphanesi kullanıldı.  

**Caching:** Performans artışı için caching mekanizmaları entegre edildi.  

**HttpContextAccessor:** HTTP bağlamına erişim için HttpContextAccessor kullanıldı.  

**Logging:** Sistem etkinliklerini izlemek ve hata ayıklamak için kapsamlı bir loglama sistemi kuruldu.  

**AOP (Aspect-Oriented Programming) Mimarisi:** Kod tekrarını azaltmak ve çapraz kesit endişelerini yönetmek için AOP mimarisi kullanıldı.  

**Aspectler:** Güvenlik, hata yönetimi ve performans izleme gibi çeşitli aspectler uygulandı.  

## Kurulum ve Kullanım  



### Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:  

**Projeyi GitHub'dan klonlayın:**

git clone [https://github.com/kcd9392/Northwind.git]

**Gerekli paketleri yükleyin:**

dotnet restore

**Uygulamayı çalıştırın:**

dotnet run

## Veritabanı Ayarları

Projeyi başarıyla çalıştırmak için, veritabanı bağlantı dizesini ayarlamanız gerekmektedir:

1. `Northwind/DataAccess/Concrete/EntityFramework/Contexts/NorthWindContext.cs` dosyasını açın.

2. `OnConfiguring` metodunda bulunan bağlantı dizesi (`connectionString`) ayarını, kendi veritabanınızın bilgileri ile güncelleyin. Örnek bir bağlantı dizesi şu şekildedir:

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=your_server;Database=your_database;User Id=your_username;Password=your_password;");
    }
      
   }

Burada your_server, your_database, your_username ve your_password kısımlarını kendi veritabanınızın bilgileri ile değiştirin.

Bu değişiklikleri yaptıktan sonra, projeyi kaydedin ve normal adımları izleyerek projeyi çalıştırın.  

Bu adımları tamamladığınızda, uygulamanız veritabanınıza başarıyla bağlanacaktır.
