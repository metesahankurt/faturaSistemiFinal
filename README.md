# Fatura Kasa Sistemi

C# (.NET 8.0) ve Windows Forms ile geliştirilmiş, MySQL tabanlı, kullanıcı dostu bir fatura ve kasa yönetim sistemidir.  
**Ürün, müşteri, fatura işlemleri ve kasa raporları** kolayca yönetilebilir.  
Tüm işlemler sol menüden erişilebilir.

---

## Özellikler

- Ürün tanımlama ve listeleme
- Müşteri ekleme ve listeleme
- Fatura oluşturma ve PDF olarak dışa aktarma
- Fatura arama/listeleme ve seçili faturayı PDF olarak dışa aktarma
- Kasa raporu ve günlük satış takibi
- Dinamik olarak güncellenen saat ve sayaçlar (büyük sayılar için otomatik K/M/B kısaltması)
- Modern ve responsive arayüz
- Tüm para birimleri Türk Lirası (₺) olarak gösterilir

---

## Gereksinimler

- **Windows 10/11 (x64)**
- **.NET 8.0 Runtime** (veya SDK)  
  [https://dotnet.microsoft.com/en-us/download/dotnet/8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **MySQL Server** (8.x önerilir)  
  [https://dev.mysql.com/downloads/installer/](https://dev.mysql.com/downloads/installer/)
- **Visual Studio 2022+** (Geliştirici için, son kullanıcı için gerekmez)

---

## Kurulum Adımları

### 1. Kaynak Kodun İndirilmesi

```sh
git clone https://github.com/metesahankurt/faturaSistemi.git
cd faturaSistemi/FaturaKasaSistemi
```

### 2. MySQL Kurulumu ve Ayarları

- MySQL Server'ı kurun ve çalıştırın.
- **Bir veritabanı ve kullanıcı oluşturun** (veya root kullanıcısını kullanabilirsiniz).
- **Kullanıcı şifresini ve bağlantı bilgilerini bir yere not edin.**

#### Örnek MySQL Komutları:
```sql
CREATE DATABASE faturakasa CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
CREATE USER 'faturauser'@'localhost' IDENTIFIED BY 'sifre123';
GRANT ALL PRIVILEGES ON faturakasa.* TO 'faturauser'@'localhost';
FLUSH PRIVILEGES;
```

### 3. Veritabanı Tablolarının Oluşturulması

- Proje ile birlikte gelen `setup.sql` dosyasını (veya size verilen SQL scriptini) MySQL Workbench veya komut satırı ile import edin.
- Eğer elinizde yoksa, ilk çalıştırmada hata alırsanız, size örnek bir SQL scripti sağlanacaktır.

### 4. Bağlantı Bilgilerinin Ayarlanması

- `DbConfig.cs` dosyasını açın:
  ```csharp
  public static string ConnectionString = "server=localhost;database=faturakasa;user=faturauser;password=sifre123;";
  ```
- **Sadece yukarıdaki satırdaki şifre ve kullanıcı adını kendi bilgilerinizle değiştirin.**
- Tüm uygulama boyunca bağlantı buradan yönetilir.

### 5. Gerekli Dosyaların Kontrolü

- `turkiye_il.json` ve `turkiye_ilce.json` dosyaları, `favicon.ico` ve tüm `.resx` dosyaları ile birlikte aynı klasörde olmalıdır.
- Publish edilen klasörde **tüm bu dosyalar** bulunmalıdır.

---

## Yayınlama (Publish) ve Çalıştırma

### 1. Publish Etme

```sh
dotnet publish -c Release -r win-x64 --self-contained true
```

- Yayınlanan dosyalar:  
  `bin/Release/net8.0-windows/win-x64/publish/` klasöründe bulunur.

### 2. Çalıştırma

- Tüm dosyaları aynı klasörde tutun.
- `FaturaKasaSistemi.exe` dosyasını çalıştırın.

---

## Sık Karşılaşılan Sorunlar ve Çözümleri

- **MySQL bağlantı hatası:**  
  - MySQL servisi çalışıyor mu?
  - Kullanıcı adı/şifre doğru mu?  
  - `DbConfig.cs` dosyasındaki connection string güncel mi?
  - Kullanıcı için `mysql_native_password` kullanın.

- **Eksik .resx veya .ico dosyası:**  
  - Tüm publish klasöründe gerekli dosyaların olduğundan emin olun.

- **Veritabanı yok veya tablo eksik:**  
  - `setup.sql` scriptini çalıştırın veya tabloları manuel oluşturun.

- **Çok büyük sayılar kutuya sığmıyor:**  
  - Sayaçlar otomatik olarak K/M/B kısaltması ile gösterilir.

---

## Geliştirici Notları

- Kodun tamamı OOP prensiplerine uygun, sürdürülebilir ve merkezi bağlantı yönetimi ile yazılmıştır.
- Tüm bağlantı ayarları sadece `DbConfig.cs` üzerinden yapılır.
- Herhangi bir hata durumunda ekrana detaylı hata mesajı gelir.

---

## Katkı ve Lisans

- Bu proje eğitim ve demo amaçlıdır.
- Katkıda bulunmak için pull request gönderebilirsiniz.

---

## English Quick Start

1. Install **.NET 8.0 Runtime** and **MySQL Server**.
2. Clone the repo and open `FaturaKasaSistemi/DbConfig.cs`, set your MySQL connection string.
3. Run the SQL script to create tables.
4. Publish with:
   ```
   dotnet publish -c Release -r win-x64 --self-contained true
   ```
5. Copy all files in the publish folder and run `FaturaKasaSistemi.exe`.

---

**Sorunsuz kurulum için sadece yukarıdaki adımları takip edin ve connection string’i kendi bilgilerinize göre güncelleyin.  
Herhangi bir hata alırsanız, README’deki “Sık Karşılaşılan Sorunlar” bölümüne bakın.**

---

Hazır!  
Artık projeyi silip baştan kurduğunuzda, bu README ile hiçbir problem yaşamadan uygulamayı açabilirsiniz.  
Başarılar! 🚀
