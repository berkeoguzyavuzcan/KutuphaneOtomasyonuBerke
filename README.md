# Kütüphane Otomasyon Sistemi

Bu proje, kütüphane yönetim süreçlerini dijitalleştirmek, kitap stoklarını ve üye hareketlerini kolayca takip etmek amacıyla geliştirilmiş bir masaüstü otomasyon uygulamasıdır.

Doğuş Üniversitesi Görsel Programlama dersi dönem sonu projesi kapsamında geliştirilmiştir.

## 📌 Projenin Amacı ve Kapsamı

Kütüphane Otomasyon Sistemi; kitap ödünç verme/iade alma, yazar-yayınevi eşleştirmeleri ve üye yönetimi gibi temel süreçleri hızlı, güvenli ve hatasız bir şekilde gerçekleştirmeyi sağlar.

Dinamik stok yönetimi ve yetkilendirme altyapısı sayesinde kütüphane yöneticilerine tam kontrol ve güvenli bir veri akışı hedefler.

## 🚀 Temel Özellikler

* **Yetkilendirme Sistemi:** Super Admin, Admin ve Standart Üye olmak üzere üç farklı rol yapısı ve rol bazlı arayüz kısıtlamaları.

* **Dinamik Stok Kontrolü:** Kitap ödünç verildiğinde stok otomatik olarak azalır, iade edildiğinde artar. Stoku tükenen kitapların kiralanması sistem tarafından otomatik olarak engellenir.

* **Otomatik Geri Kazanım:** Bir üyenin sistemden kaydı silindiğinde (pasife alındığında), elindeki tüm aktif ödünç kitaplar otomatik olarak kütüphane stoğuna geri iade edilir.

* **Gelişmiş Arama ve Filtreleme:** Kitap adı, yazar adı, yayınevi veya üye TC kimlik numarasına göre listelerde hızlı arama yapabilme.

* **Kullanıcı Dostu Arayüz:** Temiz, anlaşılır ve formlar arası geçişlerin belleği (RAM) yormadan optimize bir şekilde yapıldığı Windows Forms tasarımı.

* **Veri Güvenliği:** TC Kimlik numarası uzunluğu, boş alan kontrolleri ve veritabanı tutarsızlıklarını önleyen Transaction (işlem güvenliği) altyapısı kullanılmıştır.

## 🛠️ Kullanılan Teknolojiler

* **Programlama Dili:** C#

* **Platform:** Windows Forms

* **Veritabanı:** Microsoft SQL Server (MSSQL)

## ⚙️ Kurulum ve Çalıştırma

1. Bu depoyu yerel bilgisayarınıza klonlayın veya `.zip` olarak indirin.

2. Visual Studio üzerinden `KütüphaneOtomasyonuBerke.sln` dosyasını açın.

3. Microsoft SQL Server üzerinde projenin veritabanını oluşturun.

4. `SqlCon.cs` sınıfı içerisindeki bağlantı cümlesini (Connection String) kendi SQL Server adınıza göre güncelleyin.

5. Çözümü derleyin (Build) ve projeyi başlatın (F5).

## 🔑 Test Ortamı Giriş Bilgileri

Sistemin modüllerini ve yetkilendirme altyapısını test edebilmeniz için örnek yönetici hesap bilgileri aşağıda sunulmuştur:

**Yönetici (Super Admin) Girişi:**

* **Kullanıcı Adı:** berke

* **Şifre:** 123

---

**Geliştirici:** Berke Oğuz Yavuzcan
