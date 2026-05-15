<h1 align="center">⚡​ ApiVerse — Çok Modüllü API ve AI Entegrasyon Platformu 💻​</h1>

<p align="center">
Kripto, deprem, konum, yakıt, döviz, futbol, kitap, müzik ve film verilerini tek bir çatı altında toplayan; GPT-4o destekli yapay zeka analiz katmanına sahip ASP.NET Core MVC / Web API tabanlı bir platformdur.
</p>

---

## 🧾 Proje Tanıtımı

**ApiVerse**, farklı kategorilerdeki harici API'leri tek bir modern web platformunda birleştiren, üzerine **GPT-4o tabanlı yapay zeka analiz katmanı** entegre edilmiş çok modüllü bir ASP.NET Core uygulamasıdır.

Proje iki ana katmandan oluşmaktadır:

**ApiVerse.Api** (Web API Backend):
- Tüm harici API çağrılarını yönetir
- GPT-4o ile AI analiz üretir
- MassTransit ile asenkron mesaj kuyruğu işler
- UI katmanına veri sağlar

**ApiVerse.UI** (ASP.NET Core MVC Frontend):
- Razor Views ile dinamik sayfalar sunar
- Her modülü ayrı bölüm olarak listeler
- AI'dan dönen HTML içeriği render eder
- Kullanıcıya interaktif arayüz sağlar

---

## 🚀 Kullanılan Teknolojiler

| Katman | Teknolojiler |
|--------|-------------|
| **Backend** | `ASP.NET Core Web API`, `C#`, `HttpClient`, `MassTransit` |
| **Frontend** | `ASP.NET Core MVC`, `Razor Views`, `Bootstrap 5`, `JavaScript`, `jQuery` |
| **Yapay Zeka** | `OpenAI GPT-4o`, `Prompt Engineering`, `HTML Formatlı AI Çıktısı` |
| **Mimari** | `MVC Pattern`, `Service Layer`, `Dependency Injection`, `Message Bus` |
| **Harici API'ler** | `CoinGecko`, `GitHub REST API`, `Google Books`, `Spotify Web API`, `Adzuna` |

---

## 🧱 Proje Yapısı

```
ApiVerse/
│
├── 📁 ApiVerse.Api/                      → Web API Backend
│   ├── Controllers/                      → API Endpoint Controller'ları
│   │   ├── CryptoController.cs
│   │   ├── GitHubController.cs
│   │   ├── BooksController.cs
│   │   ├── SpotifyController.cs
│   │   └── JobsController.cs
│   ├── Services/                         → İş Mantığı Servisleri
│   │   ├── OpenAIService.cs              
│   │   ├── CryptoService.cs
│   │   ├── GitHubService.cs
│   │   ├── BooksService.cs
│   │   ├── SpotifyService.cs
│   │   └── JobsService.cs
│   ├── Models/                           → DTO ve Domain Modelleri
│   ├── Consumers/                        → MassTransit Consumer'ları
│   └── Program.cs
│
├── 📁 ApiVerse.UI/                       → ASP.NET Core MVC Frontend
│   ├── Controllers/                      → MVC Controller'ları
│   ├── Views/                            → Razor View'ları
│   │   ├── Crypto/
│   │   ├── GitHub/
│   │   ├── Books/
│   │   ├── Spotify/
│   │   └── Jobs/
│   ├── wwwroot/                          → Statik Dosyalar (CSS, JS, img)
│   └── Program.cs
│
├── ApiVerse.sln
├── .gitignore
└── .gitattributes
```

---

## 🏗 Mimari Yapı

```
┌─────────────────────────────────────────┐
│   📱 Presentation Layer (MVC Views)     │
│   - Razor Views                         │
│   - Bootstrap 5 UI                      │
│   - JavaScript / AJAX                   │
└──────────────┬──────────────────────────┘
               │
               ↓
┌─────────────────────────────────────────┐
│   🔌 API Layer (Web API Controllers)    │
│   - Harici API Çağrıları                │
│   - HttpClient Yönetimi                 │
│   - Request / Response Modelleme        │
└──────────────┬──────────────────────────┘
               │
               ↓
┌─────────────────────────────────────────┐
│   📨 Messaging Layer (MassTransit)      │
│   - Asenkron Mesaj Kuyruğu              │
│   - Producer / Consumer Pattern         │
│   - Modüller Arası İletişim             │
└──────────────┬──────────────────────────┘
               │
               ↓
┌─────────────────────────────────────────┐
│   🤖 AI Layer (OpenAI GPT-4o)           │
│   - Modül Bazlı Özel Prompt'lar         │
│   - HTML Formatlı Yapılandırılmış Çıktı │
│   - Razor @Html.Raw() ile Render        │
└─────────────────────────────────────────┘
```

---

## 🤖 Yapay Zeka Entegrasyonu

**ApiVerse**'in en öne çıkan özelliği, her modüle ayrı ayrı entegre edilmiş GPT-4o tabanlı yapay zeka katmanıdır:

- 📊 Kripto Analizi — Kripto para piyasasındaki verileri analiz eder ve yatırım odaklı yorumlar üretir
- 🌍 Deprem Verisi — Anlık deprem verilerini takip eder ve bölgesel analizler sunar
- 📍 Konum Servisi — Kullanıcının konum bazlı verilerine göre bilgi ve öneriler üretir
- ⛽ Yakıt Fiyatları — Güncel akaryakıt fiyatlarını takip eder ve karşılaştırmalı analiz sunar
- 💱 Döviz Verisi — Güncel kur bilgilerini alır ve değişim trendlerini analiz eder
- ⚽ Futbol Verisi — Maç sonuçları, takım istatistikleri ve güncel futbol verilerini analiz eder
- 📚 Kitap Önerisi — Kullanıcı ilgi alanlarına göre kişiselleştirilmiş kitap önerileri sunar
- 🎵 Müzik Verisi — Popüler müzik trendlerini ve sanatçı verilerini analiz eder
- 🎬 Film Verisi — Film bilgilerini ve izleme trendlerini analiz ederek öneriler sunar
- 🌐 HTML Çıktı Üretimi — Yapay zeka yanıtlarını doğrudan HTML formatında oluşturup Razor View içinde dinamik olarak render eder
- 📱 Sosyal Medya Analizi — YouTube, Reddit, Spotify ve diğer platformlardan trend içerikleri çekerek analiz eder
---

# 📦 MODÜLLER
## UI Giriş ve Kayıt


## 1. Giriş Yap (Login)

**Yol:** `/Account/Login`

**Açıklama:**
Kayıtlı kullanıcıların sisteme giriş yapabildiği kimlik doğrulama sayfası. ASP.NET Core Identity altyapısı ile güvenli oturum yönetimi sağlanmaktadır.

> 📸 **Login Sayfası**<img width="1860" height="953" alt="login" src="https://github.com/user-attachments/assets/482ece3b-ac7c-423a-869e-218c2a9cc765" />

---

## 2. Üye Ol (Register)

**Yol:** `/Account/Register`

**Açıklama:**
Yeni kullanıcıların sisteme üye olabildiği kayıt sayfası. ASP.NET Core Identity üzerinden kullanıcı oluşturma işlemi gerçekleştirilmekte, form doğrulama ve şifre güçlülük kontrolü uygulanmaktadır.

> 📸 **Register Sayfası**

<img width="1862" height="947" alt="Register" src="https://github.com/user-attachments/assets/48b7c9dd-31ed-4943-8c21-6be8afc09c67" />

---

## 3. Profil Sayfası (Profile)

**Yol:** `/Account/Profile`

**Açıklama:**
Giriş yapmış kullanıcının hesap bilgilerini görüntüleyebildiği ve güncelleyebildiği profil yönetim sayfası. ASP.NET Core Identity üzerinden kullanıcı bilgileri güncellenmektedir.


> 📸 **Profil Bilgileri Sayfası**
<img width="1846" height="959" alt="Profile" src="https://github.com/user-attachments/assets/781b1448-8492-4b4c-a681-9171905f8de6" />



---

## 1. Kripto Para Modülü

**Yol:** `/Crypto/Index`

**Açıklama:**
Anlık kripto para fiyatlarını, 24 saatlik değişim oranlarını ve piyasa verilerini listeleyen modül. GPT-4o entegrasyonu ile piyasa analizi ve yorum üretimi de sağlanmaktadır.

**Özellikler:**
- 💰 **Anlık Fiyat Verileri** — BTC, ETH ve diğer kripto paraların güncel fiyatları
- 📈 **24 Saatlik Değişim** — Yüzdelik değişim oranları (yeşil/kırmızı renk kodlaması)
- 🏆 **Piyasa Sıralama** — Market cap sıralaması ve hacim bilgileri
- 🤖 **AI Piyasa Analizi** — GPT-4o ile üretilmiş piyasa yorumu ve değerlendirme (HTML çıktı)

> 📸 **Kripto Para Listesi**
>
><img width="1865" height="951" alt="Kripto1" src="https://github.com/user-attachments/assets/95dcafde-6b8b-4b87-9b93-ac9c4113bd41" />

> 📸 **GPT-4o Piyasa Analizi Çıktısı**
>
> <img width="1852" height="951" alt="kripto2" src="https://github.com/user-attachments/assets/3665720f-017d-41b7-a4f4-c49941a14b04" />


---

## 2. Deprem Modülü

**Yol:** `/Earthquake/LiveEarthquakePage`

**Açıklama:**
Gerçek zamanlı deprem verilerini çekerek anlık olarak listeleyen ve bölgesel analiz imkânı sunan modül. API üzerinden gelen sismik veriler işlenerek kullanıcıya güncel ve anlaşılır bir şekilde sunulmaktadır.

**Özellikler:**
- 🌍 **Anlık Deprem Verileri** — Güncel sismik hareketler saniyelik olarak listelenir  
- 📍 **Bölgesel Filtreleme** — Depremleri büyüklük ve lokasyona göre filtreleme  
- 📊 **Detaylı Deprem Bilgisi** — Büyüklük, derinlik, tarih ve konum bilgileri  
- ⚠️ **Gerçek Zamanlı Güncelleme** — API üzerinden sürekli veri akışı ile güncel takip  

---

### 📸 Deprem Listeleme Ekranı

<img width="1863" height="959" alt="Deprem1" src="https://github.com/user-attachments/assets/1fbce976-e3ab-4002-9a04-6726b3dfc4e7" />

---

### 📸 Deprem Detay Görünümü

<img width="1860" height="953" alt="deprem2" src="https://github.com/user-attachments/assets/1420caa1-ab99-46a0-b485-3cd95296c41a" />

---

## 3. Konum & AI Öneri Modülü

**Yol:** `/Location/Index`

**Açıklama:**
Kullanıcının konum verisini kullanarak çevresindeki önemli noktaları analiz eden ve GPT-4o destekli yapay zeka ile kişiselleştirilmiş öneriler sunan modül. Konum bazlı veriler AI katmanı ile zenginleştirilerek daha anlamlı hale getirilir.

**Özellikler:**
- 📍 **Konum Tespiti** — Kullanıcının anlık konumunu algılar  
- 🧭 **Yakın Çevre Analizi** — Konuma göre ilgili yer ve bilgi önerileri sunar  
- 🤖 **AI Destekli Öneri** — GPT-4o ile kişiye özel açıklama ve tavsiyeler üretir  
- 📊 **Akıllı Veri Yorumlama** — Ham konum verisini anlamlı içgörülere dönüştürür  

---

### 📸 Konum Tabanlı Sonuçlar

<img width="1860" height="951" alt="location1" src="https://github.com/user-attachments/assets/cf1d72c9-282b-4ed7-90ff-7ed3707f1b79" />


---

### 📸 AI Öneri Paneli

<img width="1858" height="951" alt="location2" src="https://github.com/user-attachments/assets/0f0e0d9d-ea19-46ea-8365-d84af6cfee16" />


---

## 4. Sosyal Medya Trend Modülü

**Yol:** `/SocialMedia/Index`

**Açıklama:**
YouTube, Spotify ve Reddit platformlarından popüler içerikleri çekerek tek bir ekranda toplayan ve GPT-4o ile analiz eden modül. Trend veriler kullanıcıya daha anlaşılır ve yorumlanabilir şekilde sunulur.

**Özellikler:**
- 📺 **YouTube Trend Videoları** — Popüler videolar ve içerik akışı  
- 🎵 **Spotify Trend Şarkılar** — En çok dinlenen şarkılar ve playlist verileri  
- 🤖 **Reddit Trend Postları** — Toplulukta öne çıkan gönderiler ve başlıklar  
- 📊 **AI Trend Analizi** — GPT-4o ile platformlar arası trend karşılaştırması ve yorumlama  
- 🔄 **Tek Panel Görünüm** — Tüm sosyal medya trendleri tek ekranda birleşik sunum  

<img width="1280" height="661" alt="image" src="https://github.com/user-attachments/assets/3a7b29f7-dff2-4312-9140-7213dad46875" />

---

### 📸 YouTube ,Spotify & Reddit Trend Paneli Trend Görünümü

<img width="1857" height="951" alt="location3" src="https://github.com/user-attachments/assets/f71b66d3-69d0-42a3-9626-8d212474338f" />



---

## 5. Güncel Döviz Bilgi & AI Öneri Modülü

**Yol:** `/Currency/Index`

**Açıklama:**
Güncel döviz kurlarını anlık olarak takip eden ve GPT-4o destekli yapay zeka ile kullanıcıya analiz ve yönlendirme sunan modül. Kur değişimleri yorumlanarak yatırım ve finansal kararlar için daha anlamlı hale getirilir.

**Özellikler:**
- 💱 **Anlık Döviz Kurları** — USD, EUR, GBP ve diğer para birimlerinin güncel değerleri  
- 📊 **Kur Değişim Takibi** — Günlük ve anlık değişim oranlarının analizi  
- 🌍 **Çoklu Para Birimi Desteği** — Farklı ülkelerin para birimleri arasında karşılaştırma  
- 🤖 **AI Finans Yorumu** — GPT-4o ile kur hareketlerine dair yorum ve olası senaryo analizi  
- 📈 **Trend Analizi** — Kurların yükseliş/düşüş eğilimlerinin görselleştirilmesi  

---

### 📸 Döviz Kurları Paneli

<img width="1848" height="951" alt="döviz" src="https://github.com/user-attachments/assets/a890fbe3-e5e3-459a-bd9d-afd95b4bc2e7" />

---

## 6. Süper Lig Fikstür & AI Tahmin Modülü

**Yol:** `/Football/Index`

**Açıklama:**
Süper Lig fikstür verilerini çekerek maçları listeleyen ve GPT-4o destekli yapay zeka ile maç tahminleri, form durumu ve analizler sunan modül. Takım performansları ve geçmiş veriler üzerinden yorumlar üretilir.

**Özellikler:**
- ⚽ **Güncel Fikstür** — Süper Lig maç programı ve karşılaşma listesi  
- 📊 **Takım Form Durumu** — Son maç performanslarına göre analiz  
- 🧠 **AI Maç Tahmini** — GPT-4o ile olası maç sonucu tahminleri  
- 📈 **İstatistiksel Analiz** — Gol, puan ve performans verilerinin değerlendirilmesi  
- 🔄 **Canlı Güncellenen Veri** — Fikstür ve sonuçların anlık olarak güncellenmesi  

---

### 📸 Süper Lig Fikstür Görünümü

<img width="1848" height="956" alt="MATCHLAST" src="https://github.com/user-attachments/assets/ad34e4e4-d003-420e-8257-f66c3ac1bce5" />
<img width="1850" height="953" alt="THİSWEEK" src="https://github.com/user-attachments/assets/c75d03b9-0ba8-426f-a611-7bbf41823be1" />
<img width="1846" height="952" alt="MATCHAFTER" src="https://github.com/user-attachments/assets/e94e1b72-4a76-4a0c-b415-f78f357d28e8" />

---

### 📸 AI Maç Tahmin Paneli

<img width="1516" height="1544" alt="AİÖNERİ" src="https://github.com/user-attachments/assets/6c5ccdca-fd80-45a3-8e4a-850a5239a7a4" />


---


## 7. Güncel Yakıt & AI Tahmin Modülü

**Yol:** `/Fuel/Index`

**Açıklama:**
Güncel akaryakıt fiyatlarını anlık olarak takip eden ve GPT-4o destekli yapay zeka ile fiyat değişimlerini analiz edip tahminler üreten modül. Kullanıcıya hem mevcut fiyatlar hem de olası fiyat yönü hakkında yorumlar sunar.

**Özellikler:**
- ⛽ **Güncel Yakıt Fiyatları** — Benzin, motorin ve LPG fiyatlarının anlık takibi  
- 📊 **Fiyat Değişim Analizi** — Günlük ve haftalık değişimlerin karşılaştırılması  
- 🧠 **AI Fiyat Tahmini** — GPT-4o ile yakıt fiyatlarının olası artış/azalış senaryoları  
- 🌍 **Bölgesel Karşılaştırma** — Şehir bazlı fiyat farklılıklarının analizi  
- 📈 **Trend Görselleştirme** — Yakıt fiyatlarının zaman içindeki değişim eğilimi  

---

### 📸 Yakıt Fiyatları ve  AI Tahmin & Analiz Paneli

<img width="1216" height="637" alt="image" src="https://github.com/user-attachments/assets/99d87534-e2d7-486e-8559-3cc570f3ea3c" />



---

## 8. Hava Durumu Bilgi & AI Öneri Modülü

**Yol:** `/Weather/Index`

**Açıklama:**
Gerçek zamanlı hava durumu verilerini çekerek kullanıcıya anlık durum, saatlik/günlük tahmin ve GPT-4o destekli kişisel öneriler sunan modül. Hava koşullarına göre giyinme, aktivite ve planlama önerileri üretir.

**Özellikler:**
- 🌤️ **Anlık Hava Durumu** — Sıcaklık, hissedilen değer, nem ve rüzgar bilgisi  
- 📅 **Günlük & Saatlik Tahmin** — Gün içi ve ileri günlere ait hava durumu analizi  
- 📍 **Konum Bazlı Veri** — Kullanıcının bulunduğu konuma göre otomatik hava bilgisi  
- 🤖 **AI Öneri Sistemi** — GPT-4o ile hava durumuna göre günlük yaşam önerileri  
- 🎯 **Aktivite Önerileri** — Hava koşullarına uygun dış mekan/iç mekan önerileri  

---

### 📸 Hava Durumu ve AI Öneri Paneli

<img width="1859" height="955" alt="WEATHER" src="https://github.com/user-attachments/assets/2a65991b-ac5f-405c-bee1-c629d1f6e16d" />

---

## 9. Film Öneri Sistemi

**Yol:** `/Movies/Index`

**Açıklama:**
Film verilerini analiz ederek kullanıcıya tür, puan, yıl ve izleme alışkanlıklarına göre kişiselleştirilmiş film önerileri sunan modül. GPT-4o destekli yapay zeka ile içerik yorumlama ve öneri sistemi birlikte çalışır.

**Özellikler:**
- 🎬 **Film Listeleme** — Güncel ve popüler filmlerin listelenmesi  
- 🎭 **Tür Bazlı Filtreleme** — Aksiyon, dram, komedi, bilim kurgu gibi kategoriler  
- ⭐ **Puan & Yorum Analizi** — Film değerlendirme ve kullanıcı yorumlarının analizi  
- 🤖 **AI Film Önerisi** — GPT-4o ile kullanıcıya özel film tavsiyeleri  
- 📊 **Trend Film Analizi** — Popüler film eğilimlerinin takip edilmesi  

---

### 📸 Film Listesi


<img width="1855" height="961" alt="flim" src="https://github.com/user-attachments/assets/1353296c-286f-4698-9391-38221516cfce" />


---

## 10. Kitap Arama & AI Öneri Sistemi

**Yol:** `/Books/Index`

**Açıklama:**
Google Books API üzerinden kitap verilerini çekerek kullanıcıya arama, filtreleme ve GPT-4o destekli kişiselleştirilmiş kitap önerileri sunan modül. Kullanıcının ilgi alanlarına göre en uygun kitapları analiz ederek önerir.

**Özellikler:**
- 🔍 **Kitap Arama** — Başlık, yazar veya anahtar kelime ile kitap arama  
- 🏷️ **Kategori Bazlı Listeleme** — Türlere göre filtrelenmiş kitap sonuçları  
- 📖 **Kitap Detayları** — Yazar, yayınevi, sayfa sayısı, ISBN ve açıklama bilgisi  
- 🤖 **AI Kitap Önerisi** — GPT-4o ile kullanıcı ilgi alanına göre kişisel öneriler  
- 📊 **Okuma Trend Analizi** — Popüler kitaplar ve okuma eğilimlerinin analizi  

---

### 📸 Kitap Arama Sonuçları

<img width="1844" height="1356" alt="Book2" src="https://github.com/user-attachments/assets/e9d3141d-a950-4f3b-a2a7-96a0e35e6b8e" />


---

## 11. Güncel Haber & Bilgi Sistemi

**Yol:** `/News/Index`

**Açıklama:**
Farklı kaynaklardan (haber API’leri ve RSS feed’ler) güncel haberleri çekerek kullanıcıya kategorize edilmiş şekilde sunan modül. Spor, teknoloji, ekonomi ve dünya gündemi gibi alanlarda anlık bilgi akışı sağlar.

**Özellikler:**
- 📰 **Güncel Haber Akışı** — En son yayınlanan haberlerin listelenmesi  
- 🗂️ **Kategori Bazlı Filtreleme** — Spor, ekonomi, teknoloji, dünya gündemi  
- 🌍 **Kaynak Bazlı Çekim** — Farklı haber API ve RSS kaynaklarından veri toplama  
- ⚡ **Anlık Güncellenen İçerik** — Sürekli yenilenen haber akışı  
- 📄 **Detay Görünümü** — Haber başlığı, açıklama, tarih ve kaynak bilgisi  

---

### 📸 Haber Listesi

<img width="1845" height="1333" alt="News" src="https://github.com/user-attachments/assets/2bc7d489-5e44-4b17-9c74-f2f035afda45" />

---



---

## 👤 Geliştirici

**Berkay Gençeroğlu**

- GitHub: [@BerkayGenceroglu](https://github.com/BerkayGenceroglu)
- LinkedIn: [Berkay Gençeroğlu](https://www.linkedin.com/in/berkay-gencero%C4%9Flu-586b52331/)

---

## 📫 İletişim

Proje hakkında sorularınız, önerileriniz ya da katkı istekleriniz için benimle iletişime geçebilirsiniz:

- 📧 E-posta: **berkaygenceroglu6@gmail.com**
- 🔗 LinkedIn: [Berkay Gençeroğlu](https://www.linkedin.com/in/berkay-gencero%C4%9Flu-586b52331/)

---

## 💬 Son Söz
<img width="417" height="337" alt="image" src="https://github.com/user-attachments/assets/a70e40a1-6c86-4953-97e5-43fa6b003d08" />

Teşekkürler! Bu projeyi incelediğiniz için memnuniyet duyarım.  
Her türlü geri bildirime açığım.

**İyi kodlamalar! 🚀**
