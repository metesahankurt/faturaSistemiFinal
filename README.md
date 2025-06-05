# 📦 Fatura Kasa Sistemi

**Platform:** C# (.NET 8.0), Windows Forms  
**Veritabanı:** MySQL  
**Amaç:** Basit, hızlı ve kullanıcı dostu fatura & kasa yönetimi

Ürünler, müşteriler, faturalar ve kasa hareketleri tek bir modern arayüzden kolayca yönetilir.  
Tüm işlemler sol menü üzerinden erişilebilir şekilde tasarlanmıştır.

---

## 🚀 Özellikler

- 🛒 Ürün ekleme, güncelleme ve listeleme  
- 👤 Müşteri yönetimi  
- 🧾 Fatura oluşturma, arama ve PDF olarak dışa aktarma  
- 💰 Günlük satış takibi & kasa raporları  
- ⏱️ Dinamik saat ve sayaçlar (K/M/B kısaltmalarıyla)  
- 💡 Modern ve responsive tasarım  
- 💸 Tüm para birimi işlemleri Türk Lirası (₺) cinsindendir  

---

## 🧰 Gereksinimler

- **Windows 10 / 11 (x64)**  
- **.NET 8.0 Runtime** veya SDK  
  👉 [.NET 8.0 İndir](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- **MySQL Server 8.x**  
  👉 [MySQL İndir](https://dev.mysql.com/downloads/installer/)  
- **Visual Studio 2022 veya üstü** (Sadece geliştirme için)

---

## ⚙️ Kurulum Adımları

### 1️⃣ Kaynak Kodun İndirilmesi
```bash
git clone https://github.com/metesahankurt/faturaSistemi.git
cd faturaSistemi/FaturaKasaSistemi
```

### 2️⃣ MySQL Veritabanı Kurulumu
```sql
CREATE DATABASE faturakasa CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
CREATE USER 'faturauser'@'localhost' IDENTIFIED BY 'sifre123';
GRANT ALL PRIVILEGES ON faturakasa.* TO 'faturauser'@'localhost';
FLUSH PRIVILEGES;
```

### 3️⃣ SQL Tablolarını Oluşturma

- `setup.sql` dosyasını MySQL Workbench veya komut satırından içe aktarın.  
- Dosya yoksa, ilk çalıştırmada hata alırsanız örnek SQL sağlanacaktır.

### 4️⃣ Bağlantı Ayarlarını Yapılandırma
```csharp
// DbConfig.cs
public static string ConnectionString = "server=localhost;database=faturakasa;user=faturauser;password=sifre123;";
```

> 🔒 Sadece kullanıcı adı ve şifreyi kendi bilgilerinizle değiştirmeniz yeterlidir.

### 5️⃣ Gerekli Dosyaların Kontrolü

- `turkiye_il.json`, `turkiye_ilce.json`, `favicon.ico`, `.resx` dosyaları eksiksiz olmalı  
- Bu dosyalar **yayınlanan klasörde** yer almalıdır

---

## 📤 Yayınlama ve Çalıştırma

### 🔨 Yayınlama (Publish)
```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

> Yayınlanan dosyalar:
> `bin/Release/net8.0-windows/win-x64/publish/`

### ▶️ Uygulamayı Başlatma

- Tüm dosyaları aynı klasöre kopyalayın  
- `FaturaKasaSistemi.exe` dosyasını çalıştırın

---

## ❗ Sık Karşılaşılan Sorunlar

| Sorun | Çözüm |
|------|-------|
| 🔌 MySQL bağlantı hatası | Servis açık mı, `DbConfig.cs` ayarları doğru mu, `mysql_native_password` mı? |
| ❓ Eksik dosya | `.resx`, `.ico`, `.json` dosyaları eksiksiz mi kontrol et |
| 📄 Veritabanı veya tablo eksik | `setup.sql` dosyasını çalıştır |
| 📊 Büyük sayılar taşma yapıyor | Otomatik `K/M/B` formatı uygulanır |

---

## 🛠️ Geliştirici Notları

- Kod yapısı tamamen **OOP** prensiplerine uygundur  
- Tüm bağlantılar merkezi olarak `DbConfig.cs` üzerinden yönetilir  
- Hatalar kullanıcıya detaylı olarak gösterilir (try-catch bloklarıyla)

---

## 🤝 Katkı ve Lisans

- Bu proje açık kaynak, eğitim ve demo amaçlıdır  
- Katkıda bulunmak isteyenler için pull request’ler her zaman açıktır  

---

## 🌍 Quick Start (EN)

1. Install **.NET 8.0** and **MySQL Server**
2. Clone the repo, open `DbConfig.cs`, and set your credentials
3. Import `setup.sql` to create tables
4. Run:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained true
   ```
5. Run `FaturaKasaSistemi.exe`

---

## ✅ Sonuç

Bu README dosyasıyla birlikte, projeyi kurmak ve çalıştırmak **maksimum 5 dakikanızı alır.**  
Connection string'i güncellemeyi unutmayın, başka hiçbir şeye dokunmanıza gerek yok.  
Her şey hazır, her şey kontrol altında 💼  

**Başarılar!** 🚀  
Herhangi bir sorun olursa [issues](https://github.com/metesahankurt/faturaSistemi/issues) sekmesinden bildirmen yeterli.
