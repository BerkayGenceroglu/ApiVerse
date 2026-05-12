# 🌐 ApiVerse

<div align="center">

![ApiVerse Banner](https://via.placeholder.com/900x200/1a1a2e/6c63ff?text=ApiVerse+-+Multi+Module+API+Integration+Platform)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC%20%7C%20Web%20API-512BD4?style=for-the-badge&logo=dotnet)](https://docs.microsoft.com/aspnet/core)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=csharp)](https://docs.microsoft.com/dotnet/csharp/)
[![OpenAI](https://img.shields.io/badge/OpenAI-GPT--4o-412991?style=for-the-badge&logo=openai)](https://openai.com/)
[![MassTransit](https://img.shields.io/badge/MassTransit-Messaging-FF6B35?style=for-the-badge)](https://masstransit.io/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](LICENSE)

**Birden fazla harici API'yi tek çatı altında toplayan, GPT-4o destekli AI analiz katmanına sahip çok modüllü ASP.NET Core MVC/Web API platformu.**

[Özellikler](#-özellikler) • [Mimari](#-mimari) • [Kurulum](#-kurulum) • [Modüller](#-modüller) • [API Dokümantasyonu](#-api-dokümantasyonu) • [Ekran Görüntüleri](#-ekran-görüntüleri)

</div>

---

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Özellikler](#-özellikler)
- [Mimari](#-mimari)
- [Teknoloji Stack'i](#-teknoloji-stacki)
- [Modüller](#-modüller)
  - [Kripto Para Modülü](#-kripto-para-modülü)
  - [GitHub Trending Modülü](#-github-trending-modülü)
  - [Google Books Modülü](#-google-books-modülü)
  - [Spotify Modülü](#-spotify-modülü)
  - [İş İlanları Modülü](#-i̇ş-i̇lanları-modülü)
  - [AI Analiz Katmanı](#-ai-analiz-katmanı)
- [Kurulum](#-kurulum)
- [Yapılandırma](#-yapılandırma)
- [API Dokümantasyonu](#-api-dokümantasyonu)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [Katkıda Bulunma](#-katkıda-bulunma)

---

## 🎯 Proje Hakkında

**ApiVerse**, farklı kategorilerde çeşitli harici API'leri (kripto para, GitHub, kitap, müzik, iş ilanları) tek bir modern web platformunda birleştiren, üzerine GPT-4o tabanlı AI analiz katmanı eklenmiş çok modüllü bir ASP.NET Core uygulamasıdır.

Proje; **ApiVerse.Api** (Web API backend) ve **ApiVerse.UI** (ASP.NET Core MVC frontend) olmak üzere iki ana projeden oluşmaktadır. Modüller arası iletişim **MassTransit** ile mesaj bazlı bir mimariyle yönetilmektedir.

---

## ✨ Özellikler

| Özellik | Açıklama |
|---|---|
| 🔌 Çoklu API Entegrasyonu | Kripto, GitHub, Books, Spotify, Jobs API desteği |
| 🤖 AI Destekli Analiz | GPT-4o ile modül bazlı içerik analizi ve önerileri |
| 📨 Mesaj Kuyruğu | MassTransit ile asenkron mesajlaşma altyapısı |
| 🎨 Modern UI | Razor Views ile dinamik, responsive arayüzler |
| 🔒 Güvenli Yapı | API Key yönetimi, environment-based config |
| 📊 Gerçek Zamanlı Veri | Anlık kripto fiyatları, trending repolar, playlist verileri |

---

## 🏗️ Mimari

```
ApiVerse/
│
├── ApiVerse.Api/                    # Web API Backend
│   ├── Controllers/                 # API endpoint controller'ları
│   │   ├── CryptoController.cs
│   │   ├── GitHubController.cs
│   │   ├── BooksController.cs
│   │   ├── SpotifyController.cs
│   │   └── JobsController.cs
│   ├── Services/                    # İş mantığı servisleri
│   │   ├── OpenAIService.cs         # GPT-4o entegrasyonu
│   │   ├── CryptoService.cs
│   │   ├── GitHubService.cs
│   │   └── ...
│   ├── Models/                      # DTO ve domain modelleri
│   ├── Consumers/                   # MassTransit consumer'ları
│   └── Program.cs
│
├── ApiVerse.UI/                     # ASP.NET Core MVC Frontend
│   ├── Controllers/                 # MVC controller'ları
│   ├── Views/                       # Razor view'ları
│   │   ├── Crypto/
│   │   ├── GitHub/
│   │   ├── Books/
│   │   ├── Spotify/
│   │   └── Jobs/
│   ├── wwwroot/                     # Statik dosyalar (CSS, JS, img)
│   └── Program.cs
│
└── ApiVerse.sln
```

> 📸 **Mimari Diyagram**
>
> ![Architecture Diagram](https://via.placeholder.com/900x450/1a1a2e/ffffff?text=📸+Mimari+Diyagram+Ekran+Görüntüsü+Buraya)

---

## 🛠️ Teknoloji Stack'i

### Backend
| Teknoloji | Versiyon | Kullanım Amacı |
|---|---|---|
| ASP.NET Core | 8.0 | Web API & MVC framework |
| C# | 12.0 | Ana programlama dili |
| MassTransit | 8.x | Mesaj kuyruğu / asenkron iletişim |
| HttpClient | Built-in | Harici API çağrıları |
| OpenAI SDK | Latest | GPT-4o AI analiz entegrasyonu |

### Frontend
| Teknoloji | Kullanım Amacı |
|---|---|
| Razor Views | Server-side rendering |
| Bootstrap 5 | Responsive UI framework |
| JavaScript / jQuery | Dinamik UI etkileşimleri |
| HTML5 / CSS3 | Sayfa yapısı ve stiller |

### Harici API'ler
| API | Modül | Açıklama |
|---|---|---|
| CoinGecko / Binance | Kripto | Kripto para fiyatları ve verileri |
| GitHub REST API | GitHub | Trending repolar, dil filtresi |
| Google Books API | Kitaplar | Kitap arama ve öneri sistemi |
| Spotify Web API | Müzik | Playlist ve şarkı verileri |
| Adzuna API | İş İlanları | Türkiye'deki iş ilanı listelemeleri |
| OpenAI GPT-4o | AI Analiz | Tüm modüller için AI içerik analizi |

---

## 📦 Modüller

### 💰 Kripto Para Modülü

Anlık kripto para fiyatlarını, değişim oranlarını ve piyasa verilerini getiren modül. GPT-4o entegrasyonu sayesinde piyasa analizi ve yatırım yorumları da sunulmaktadır.

**Özellikler:**
- Anlık fiyat verileri (BTC, ETH, vb.)
- 24 saatlik değişim oranları
- Piyasa hacmi ve sıralama bilgileri
- **AI destekli piyasa analizi** (GPT-4o ile HTML formatında çıktı)

> 📸 **Kripto Modülü Ekran Görüntüsü**
>
> ![Crypto Module](https://via.placeholder.com/900x500/1a1a2e/f7931a?text=📸+Kripto+Modülü+Ekran+Görüntüsü+Buraya)

> 📸 **AI Kripto Analiz Çıktısı**
>
> ![Crypto AI Analysis](https://via.placeholder.com/900x400/1a1a2e/412991?text=📸+GPT-4o+Kripto+Analiz+Çıktısı+Buraya)

---

### 🐙 GitHub Trending Modülü

GitHub üzerindeki günlük ve haftalık trend repoları listeleyen, dil bazlı filtreleme destekleyen modül.

**Özellikler:**
- Günlük / haftalık trending repolar
- **Dil bazlı filtreleme** (C#, Python, JavaScript vb.)
- Repo detayları (star, fork, açıklama)
- Geliştirici profil widget'ları
- URL encoding ile özel dil filtresi desteği

> 📸 **GitHub Trending Modülü Ekran Görüntüsü**
>
> ![GitHub Module](https://via.placeholder.com/900x500/1a1a2e/24292e?text=📸+GitHub+Trending+Modülü+Ekran+Görüntüsü+Buraya)

> 📸 **Dil Filtreleme Ekran Görüntüsü**
>
> ![GitHub Language Filter](https://via.placeholder.com/900x400/1a1a2e/24292e?text=📸+Dil+Filtresi+Ekran+Görüntüsü+Buraya)

---

### 📚 Google Books Modülü

Google Books API ile kitap arama, öneri ve listeleme işlemleri yapan modül.

**Özellikler:**
- Anahtar kelime ile kitap arama
- Kategori bazlı listeleme
- Kitap detay sayfaları (yazar, yayınevi, ISBN, önizleme linki)
- **AI destekli kitap önerisi** (GPT-4o ile kişiselleştirilmiş öneri)

> 📸 **Google Books Modülü Ekran Görüntüsü**
>
> ![Books Module](https://via.placeholder.com/900x500/1a1a2e/4285F4?text=📸+Google+Books+Modülü+Ekran+Görüntüsü+Buraya)

> 📸 **Kitap Arama Sonuçları**
>
> ![Books Search](https://via.placeholder.com/900x400/1a1a2e/4285F4?text=📸+Kitap+Arama+Ekran+Görüntüsü+Buraya)

---

### 🎵 Spotify Modülü

Spotify Web API ile Türkiye Top-50 ve diğer playlist verilerini çeken, şarkı bilgilerini listeleyen modül.

**Özellikler:**
- Türkiye Top-50 playlist verileri
- Şarkı, sanatçı, albüm bilgileri
- Spotify'da dinleme linkleri
- Client Credentials Flow ile token yönetimi

> 📸 **Spotify Modülü Ekran Görüntüsü**
>
> ![Spotify Module](https://via.placeholder.com/900x500/1a1a2e/1DB954?text=📸+Spotify+Modülü+Ekran+Görüntüsü+Buraya)

> 📸 **Playlist Listesi Ekran Görüntüsü**
>
> ![Spotify Playlist](https://via.placeholder.com/900x400/1a1a2e/1DB954?text=📸+Playlist+Görünümü+Ekran+Görüntüsü+Buraya)

---

### 💼 İş İlanları Modülü

Adzuna API kullanılarak Türkiye'deki güncel iş ilanlarını listeleyen ve filtreleyen modül.

**Özellikler:**
- Şehir ve kategori bazlı filtreleme
- İlan detayları (şirket, konum, maaş aralığı)
- Sayfalama (pagination) desteği
- **AI destekli ilan analizi** (pozisyon uygunluk değerlendirmesi)

> 📸 **İş İlanları Modülü Ekran Görüntüsü**
>
> ![Jobs Module](https://via.placeholder.com/900x500/1a1a2e/0077B5?text=📸+İş+İlanları+Modülü+Ekran+Görüntüsü+Buraya)

> 📸 **Filtreleme Ekran Görüntüsü**
>
> ![Jobs Filter](https://via.placeholder.com/900x400/1a1a2e/0077B5?text=📸+İş+İlanı+Filtresi+Ekran+Görüntüsü+Buraya)

---

### 🤖 AI Analiz Katmanı

Tüm modüllere entegre edilmiş GPT-4o destekli analiz katmanı. Her modüldeki veri, OpenAI API'ye gönderilerek anlamlı HTML formatında sonuçlar üretilmekte ve Razor View'larında render edilmektedir.

**Özellikler:**
- Modül bazında özelleştirilmiş prompt'lar
- HTML formatında yapılandırılmış AI çıktısı
- Razor `@Html.Raw()` ile güvenli render
- MassTransit üzerinden asenkron AI istek yönetimi

**Örnek Akış:**
```
Kullanıcı İsteği
      ↓
MVC Controller
      ↓
MassTransit Message Bus
      ↓
ApiVerse.Api → OpenAI GPT-4o
      ↓
HTML Formatlı Yanıt
      ↓
Razor View Render
```

> 📸 **AI Analiz Çıktısı Örneği**
>
> ![AI Analysis Output](https://via.placeholder.com/900x500/1a1a2e/412991?text=📸+AI+Analiz+Çıktısı+Ekran+Görüntüsü+Buraya)

---

## 🚀 Kurulum

### Gereksinimler

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [VS Code](https://code.visualstudio.com/)
- (Opsiyonel) [RabbitMQ](https://www.rabbitmq.com/) — MassTransit transport için

### 1. Repoyu Klonlayın

```bash
git clone https://github.com/BerkayGenceroglu/ApiVerse.git
cd ApiVerse
```

### 2. API Anahtarlarını Ayarlayın

`ApiVerse.Api/appsettings.json` ve `ApiVerse.UI/appsettings.json` dosyalarını doldurun (bkz. [Yapılandırma](#-yapılandırma)).

### 3. Bağımlılıkları Yükleyin

```bash
# API projesi
cd ApiVerse.Api
dotnet restore

# UI projesi
cd ../ApiVerse.UI
dotnet restore
```

### 4. Projeleri Çalıştırın

Önce **API** projesini başlatın:

```bash
cd ApiVerse.Api
dotnet run
# API: https://localhost:7001
```

Ardından **UI** projesini başlatın:

```bash
cd ApiVerse.UI
dotnet run
# UI: https://localhost:7000
```

> 💡 **Visual Studio kullanıyorsanız:** Solution'ı açın, birden fazla başlangıç projesi olarak `ApiVerse.Api` ve `ApiVerse.UI`yi seçin ve F5 ile çalıştırın.

> 📸 **Kurulum Adımları Ekran Görüntüsü**
>
> ![Setup Screenshot](https://via.placeholder.com/900x400/1a1a2e/28a745?text=📸+Kurulum+Ekran+Görüntüsü+Buraya)

---

## ⚙️ Yapılandırma

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
  },
  "MassTransit": {
    "Host": "localhost",
    "VirtualHost": "/",
    "Username": "guest",
    "Password": "guest"
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

## 📖 API Dokümantasyonu

### Base URL

```
https://localhost:7001/api
```

### Endpoints

#### 💰 Kripto

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/crypto/list` | Tüm kripto para listesi |
| `GET` | `/crypto/{symbol}` | Belirli kripto detayı |
| `POST` | `/crypto/analyze` | GPT-4o ile piyasa analizi |

#### 🐙 GitHub

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/github/trending` | Günlük trending repolar |
| `GET` | `/github/trending?language=C%23` | Dil bazlı filtreleme |
| `GET` | `/github/trending?since=weekly` | Haftalık trending |

#### 📚 Books

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/books/search?q={query}` | Kitap arama |
| `GET` | `/books/{id}` | Kitap detayı |
| `POST` | `/books/recommend` | AI kitap önerisi |

#### 🎵 Spotify

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/spotify/top50` | Türkiye Top-50 listesi |
| `GET` | `/spotify/playlist/{id}` | Playlist detayı |

#### 💼 Jobs

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/jobs/list` | İş ilanları listesi |
| `GET` | `/jobs/list?location=Istanbul` | Şehir bazlı ilanlar |
| `POST` | `/jobs/analyze` | AI ilan analizi |

> 📸 **Swagger UI Ekran Görüntüsü**
>
> ![Swagger UI](https://via.placeholder.com/900x500/1a1a2e/85ea2d?text=📸+Swagger+UI+Ekran+Görüntüsü+Buraya)

---

## 📸 Ekran Görüntüleri

### Ana Sayfa

> ![Homepage](https://via.placeholder.com/900x550/1a1a2e/6c63ff?text=📸+Ana+Sayfa+Ekran+Görüntüsü+Buraya)

### Dashboard Genel Görünüm

> ![Dashboard](https://via.placeholder.com/900x550/1a1a2e/6c63ff?text=📸+Dashboard+Genel+Ekran+Görüntüsü+Buraya)

### Mobil Görünüm

> ![Mobile View](https://via.placeholder.com/400x750/1a1a2e/6c63ff?text=📸+Mobil+Görünüm+Ekran+Görüntüsü+Buraya)

---

## 🤝 Katkıda Bulunma

1. Bu repoyu fork'layın
2. Feature branch oluşturun: `git checkout -b feature/yeni-modul`
3. Değişikliklerinizi commit edin: `git commit -m 'feat: yeni modül eklendi'`
4. Branch'i push edin: `git push origin feature/yeni-modul`
5. Pull Request açın

---

## 👤 Geliştirici

<div align="center">

**Berkay Gençeroğlu**

[![GitHub](https://img.shields.io/badge/GitHub-BerkayGenceroglu-181717?style=for-the-badge&logo=github)](https://github.com/BerkayGenceroglu)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Berkay_Gençeroğlu-0077B5?style=for-the-badge&logo=linkedin)](https://linkedin.com/in/BerkayGenceroglu)

*Üsküdar Üniversitesi — Bilgisayar Mühendisliği*

</div>

---

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.

---

<div align="center">

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!

Made with ❤️ using ASP.NET Core & OpenAI GPT-4o

</div>
