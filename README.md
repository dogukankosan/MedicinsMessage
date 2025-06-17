![image](https://github.com/user-attachments/assets/75982661-c181-417c-9fad-e0584d14d02e)

# 💬 MedicinsMessage

## 📝 Tanıtım

**MedicinsMessage**, sağlık sektörü ve klinik ortamlar için mesajlaşma, bildirim ve hasta iletişimi süreçlerini dijitalleştiren bir ASP.NET MVC projesidir. Kullanıcı dostu arayüzüyle doktor, hemşire ve idari personel arasında etkili bilgi akışı sağlar.

---

## 🚀 Özellikler

- 👤 Doktor, hemşire ve personel yönetimi
- ✉️ Dahili mesajlaşma sistemi
- 🔔 Bildirim ve uyarı yönetimi
- 🗂️ Hasta bilgilerinin güvenli paylaşımı
- 📅 Takvim ve randevu hatırlatma
- 🔒 Rol tabanlı yetkilendirme ve güvenli oturum yönetimi
- 🌐 Modern ve responsive arayüz (Bootstrap desteği)

---

## 🏗️ Teknik Altyapı

- **Backend:** ASP.NET MVC (C#), Entity Framework
- **Frontend:** Razor View Engine, Bootstrap, jQuery
- **Veritabanı:** MSSQL (Code First veya Database First desteği)
- **Katmanlar:**
  - `Entities/` : Model sınıfları
  - `DataAccess/` : EF veri erişim katmanı
  - `Business/` : İş kuralları ve servisler
  - `Presentation/` : MVC controller ve view’lar
  - `Content/` : Statik dosyalar (CSS, JS, img)
- **Güvenlik:** Kimlik doğrulama, cookie tabanlı oturum yönetimi, rol tabanlı erişim
- **Ekstra:**  
  - Bildirim ve mesaj geçmişi loglama
  - Validasyon ve hata yönetimi

---

## 📂 Klasör Yapısı

```
MedicinsMessage/
├── Business/         # Servisler ve iş kuralları
├── DataAccess/       # Veri erişim katmanı (EF)
├── Entities/         # Model sınıfları
├── Presentation/     # MVC controller ve view’lar
├── Content/          # Statik dosyalar (CSS, JS, img)
├── App_Start/        # Konfigürasyonlar (Route, Filter vb.)
├── Web.config        # Uygulama ayarları
└── ...
```

---

## ⚙️ Kurulum & Kullanım

1. Projeyi klonlayın veya indirin.
2. MSSQL üzerinde veritabanı bağlantı ayarlarını `Web.config`’te yapın.
3. Gerekli NuGet paketlerini yükleyin (Entity Framework, Bootstrap vb.).
4. Visual Studio ile projeyi açıp çalıştırın.

---

## 🤝 Katkı

Katkı sağlamak için projeyi forklayabilir ve pull request gönderebilirsiniz.

---

## 📄 Lisans

MIT License

---

## 📬 İletişim

- 👨‍💻 Geliştirici: [@dogukankosan](https://github.com/dogukankosan)  
- 🐞 Suggestions or issues: [Issues sekmesi](https://github.com/dogukankosan/LogoWhatsappEntegrasyon/issues)

---
