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
> ![Kripto Para Listesi](https://via.placeholder.com/900x500/0d1117/f7931a?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

> 📸 **GPT-4o Piyasa Analizi Çıktısı**
>
> ![AI Kripto Analizi](https://via.placeholder.com/900x400/0d1117/412991?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

---

## 2. GitHub Trending Modülü

**Yol:** `/GitHub/Trending`

**Açıklama:**
GitHub üzerindeki günlük ve haftalık trend repoları listeleyen, dil bazlı filtreleme destekleyen modül. GitHub REST API ve URL encoding ile C#, Python, JavaScript gibi dil filtrelemeleri yapılmaktadır.

**Özellikler:**
- 🔥 **Günlük / Haftalık Trending** — Zaman aralığına göre en popüler repolar
- 🗂️ **Dil Bazlı Filtreleme** — C#, Python, JavaScript, Go vb. dil seçimi (URL encoding destekli)
- ⭐ **Repo Detayları** — Star sayısı, fork, açıklama ve dil bilgisi
- 🧑‍💻 **Geliştirici Widget'ı** — Repo sahibine ait profil bilgileri

> 📸 **GitHub Trending Listesi**
>
> ![GitHub Trending](https://via.placeholder.com/900x500/0d1117/24292e?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

> 📸 **Dil Filtresi Seçimi**
>
> ![Dil Filtresi](https://via.placeholder.com/900x400/0d1117/24292e?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

---

## 3. Google Books Modülü

**Yol:** `/Books/Index`

**Açıklama:**
Google Books API ile kitap arama, listeleme ve öneri yapabilen modül. Kullanıcılar anahtar kelime veya kategori ile kitap arayabilir; GPT-4o ile kişiselleştirilmiş öneri alabilir.

**Özellikler:**
- 🔍 **Kitap Arama** — Başlık, yazar veya ISBN ile arama
- 🏷️ **Kategori Bazlı Listeleme** — Türe göre filtrelenmiş kitap listesi
- 📖 **Kitap Detayı** — Yazar, yayınevi, sayfa sayısı, ISBN, önizleme linki
- 🤖 **AI Kitap Önerisi** — Tercihlerinize göre GPT-4o destekli kişisel öneri

> 📸 **Kitap Arama Sonuçları**
>
> ![Google Books](https://via.placeholder.com/900x500/0d1117/4285F4?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

> 📸 **Kitap Detay Sayfası**
>
> ![Kitap Detay](https://via.placeholder.com/900x400/0d1117/4285F4?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

---

## 4. Spotify Modülü

**Yol:** `/Spotify/Index`

**Açıklama:**
Spotify Web API ile Türkiye Top-50 ve çeşitli playlist verilerini çeken modül. Şarkı, sanatçı ve albüm bilgileri listelenmekte, Spotify bağlantıları sağlanmaktadır. Client Credentials Flow ile otomatik token yönetimi yapılmaktadır.

**Özellikler:**
- 🇹🇷 **Türkiye Top-50** — Türkiye günlük en çok dinlenen şarkılar
- 🎵 **Şarkı & Sanatçı Bilgisi** — Albüm kapağı, sanatçı adı, şarkı ismi
- 🔗 **Spotify Linki** — Şarkıyı Spotify'da dinlemek için yönlendirme
- 🔑 **Token Yönetimi** — Client Credentials Flow ile otomatik erişim token'ı

> 📸 **Türkiye Top-50 Listesi**
>
> ![Spotify Top 50](https://via.placeholder.com/900x500/0d1117/1DB954?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

> 📸 **Playlist Görünümü**
>
> ![Spotify Playlist](https://via.placeholder.com/900x400/0d1117/1DB954?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

---

## 5. İş İlanları Modülü

**Yol:** `/Jobs/Index`

**Açıklama:**
Adzuna API kullanılarak Türkiye'deki güncel iş ilanlarını listeleyen ve filtreleyen modül. Şehir ve kategori bazlı filtreleme, sayfalama ve AI destekli ilan analizi özelliklerine sahiptir.

**Özellikler:**
- 🏙️ **Şehir & Kategori Filtresi** — İstanbul, Ankara gibi şehir bazlı ve kategori bazlı filtreleme
- 🏢 **İlan Detayları** — Şirket adı, konum, maaş aralığı, iş tanımı
- 📄 **Sayfalama** — Büyük ilan listeleri için pagination desteği
- 🤖 **AI İlan Değerlendirmesi** — GPT-4o ile pozisyon uygunluk analizi

> 📸 **İş İlanları Listesi**
>
> ![İş İlanları](https://via.placeholder.com/900x500/0d1117/0077B5?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

> 📸 **Şehir / Kategori Filtresi**
>
> ![İş İlanı Filtresi](https://via.placeholder.com/900x400/0d1117/0077B5?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

---

## 6. AI Analiz Katmanı

**Yol:** Her modülün `/Analyze` endpoint'i

**Açıklama:**
Tüm modüllere entegre edilmiş GPT-4o destekli analiz katmanı. Modülden gelen veri OpenAI API'ye gönderilir; üretilen HTML çıktı Razor View içinde `@Html.Raw()` ile render edilir.

**Özellikler:**
- 🧠 **Modül Bazlı Prompt** — Her modül için özelleştirilmiş system prompt
- 🌐 **HTML Formatlı Çıktı** — AI yanıtı doğrudan HTML olarak üretilir, sayfaya render edilir
- 📨 **MassTransit ile Asenkron** — AI istekleri message bus üzerinden yönetilir
- ⚡ **Hızlı Yanıt** — Streaming olmadan yapılandırılmış tek yanıt modeli

**AI Akış Diyagramı:**
```
Kullanıcı → MVC Controller → MassTransit Bus
                                    ↓
                            ApiVerse.Api Consumer
                                    ↓
                            OpenAI GPT-4o
                                    ↓
                            HTML Formatlı Yanıt
                                    ↓
                            Razor @Html.Raw() Render
```

> 📸 **AI Analiz Çıktısı Örneği**
>
> ![AI Analiz](https://via.placeholder.com/900x500/0d1117/412991?text=📸+Buraya+Ekran+Görüntüsü+Ekleyin)

---

## ⚙️ Kurulum ve Çalıştırma

### Gereksinimler

- .NET 8.0 SDK
- Visual Studio 2022 veya VS Code
- (Opsiyonel) RabbitMQ — MassTransit transport için

### Adımlar

```bash
# 1. Repoyu klonla
git clone https://github.com/BerkayGenceroglu/ApiVerse.git

# 2. Proje dizinine git
cd ApiVerse

# 3. appsettings.json dosyalarını yapılandır
# ApiVerse.Api ve ApiVerse.UI için API anahtarlarını ekle

# 4. API projesini çalıştır
cd ApiVerse.Api
dotnet run
# → https://localhost:7001

# 5. UI projesini çalıştır (yeni terminal)
cd ApiVerse.UI
dotnet run
# → https://localhost:7000
```

> 💡 **Visual Studio kullanıyorsanız:** Solution'ı açın, her iki projeyi de başlangıç projesi olarak seçip F5 ile çalıştırın.

---

## 🔧 Yapılandırma

### ApiVerse.Api — `appsettings.json`

```json
{
  "OpenAI": {
    "ApiKey": "sk-xxxxxxxxxxxxxxxxxxxx",
    "Model": "gpt-4o"
  },
  "GitHub": {
    "Token": "ghp_xxxxxxxxxxxxxxxxxxxx"
  },
  "Spotify": {
    "ClientId": "your_spotify_client_id",
    "ClientSecret": "your_spotify_client_secret"
  },
  "Adzuna": {
    "AppId": "your_adzuna_app_id",
    "AppKey": "your_adzuna_app_key"
  }
}
```

### ApiVerse.UI — `appsettings.json`

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7001"
  }
}
```

> ⚠️ **Önemli:** API anahtarlarını asla kaynak koduna veya Git'e commit etmeyin. `.gitignore`'a `appsettings.Development.json` ekleyerek hassas bilgileri güvende tutun.

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

Teşekkürler! Bu projeyi incelediğiniz için memnuniyet duyarım.  
Her türlü geri bildirime açığım.

**İyi kodlamalar! 🚀**
