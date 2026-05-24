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

# 📚 Kütüphane Otomasyon Sistemi - Kurulum ve Çalıştırma Kılavuzu

Bu rehber, projenin lokal bilgisayarınızda sorunsuz bir şekilde ayağa kaldırılması ve veritabanı bağlantılarının hatasız kurulabilmesi için adım adım hazırlanmıştır.

---

## 🛠️ 1. Adım: Veritabanının SQL Server'a Yüklenmesi (Import)

Projenin ana dizininde (bu klasörde) yer alan `KütüphaneOtomasyonuBerke.bacpac` yedek dosyası, veritabanı şemasını, tabloları ve test verilerini eksiksiz barındırmaktadır. Yüklemek için:

1. **Microsoft SQL Server Management Studio (SSMS)** programını açın ve veritabanı sunucunuza bağlanın.
2. Sol tarafta bulunan **Object Explorer** menüsündeki **Databases** klasörünün üzerine **sağ tıklayın**.
3. Açılan menüden **"Import Data-tier Application..."** seçeneğine tıklayın.
4. Karşınıza gelen sihirbaz penceresinde **Next (İleri)** butonuna basın.
5. **"Import from local disk"** seçeneğinin yanındaki **Browse... (Gözat)** butonuna tıklayarak projenin ana dizinindeki **`KütüphaneOtomasyonuBerke.bacpac`** dosyasını seçin ve **Next** deyin.
6. Bir sonraki ekranda veritabanı adı otomatik olarak `KütüphaneOtomasyonuBerke` şeklinde gelecektir. Ayarları değiştirmeden sırasıyla **Next** ve **Finish** butonlarına basın.
7. Yükleme işlemi tamamlandığında ekranda tüm adımların yanında yeşil check `(Success)` logoları görünecektir. **Close** diyerek pencereyi kapatın.
8. **Databases** klasörüne sağ tıklayıp **Refresh (Yenile)** yaptığınızda veritabanının başarıyla eklendiğini görebilirsiniz.

---

## 💻 2. Adım: Projenin Visual Studio ile Açılması

1. Proje ana klasöründe bulunan **`KütüphaneOtomasyonuBerke.sln`** çözüm dosyasına çift tıklayarak projeyi **Visual Studio** üzerinde açın.
2. Proje açıldığında sağ taraftaki **Solution Explorer** penceresinde projenin tüm formlarını, kütüphanelerini ve kaynak kodlarını görebilirsiniz.

---

## 🔌 3. Adım: Merkezi Veritabanı Bağlantı Kontrolü

Projenin yerel SQL Server'ınız ile doğrudan konuşabilmesi için bağlantı mimarisi esnek ve merkezi hale getirilmiştir. 

Eğer yerel SQL Server sunucunuz standart yerel adresi (lokal servis / nokta `.` / `localhost`) kullanıyorsa, kod içerisindeki merkezi Connection String yapısı sayesinde **proje ek bir konfigürasyon değişikliği gerektirmeden doğrudan çalışacaktır:**

```csharp
// Projede kullanılan merkezi SQL Server bağlantı şablonu
string connectionString = "Data Source=.;Initial Catalog=KütüphaneOtomasyonuBerke;Integrated Security=True;";

**Geliştirici:** Berke Oğuz Yavuzcan
