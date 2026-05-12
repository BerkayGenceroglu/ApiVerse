using ApiVerse.Api.Abstract;
using ApiVerse.Api.Abstract.BookAbstracts;
using ApiVerse.Api.Abstract.CryptoAbstracts;
using ApiVerse.Api.Abstract.EarthquakeAbstracts;
using ApiVerse.Api.Abstract.ExchangeAbstracts;
using ApiVerse.Api.Abstract.FootballAbstracts;
using ApiVerse.Api.Abstract.FuelAbstracts;
using ApiVerse.Api.Abstract.NewsAbstracts;
using ApiVerse.Api.Abstract.SocialMediaAbstracts;
using ApiVerse.Api.Services;
using ApiVerse.Api.Services.BookService;
using ApiVerse.Api.Services.CryptoService;
using ApiVerse.Api.Services.EarthquakeService;
using ApiVerse.Api.Services.ExchangeService;
using ApiVerse.Api.Services.FuelService;
using ApiVerse.Api.Services.NewsService;
using ApiVerse.Api.Services.SocialMediaService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient() ;
builder.Services.AddHttpClient("FootballClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["FootballApi:BaseUrl"]);
    client.DefaultRequestHeaders.Add("x-rapidapi-key", builder.Configuration["FootballApi:ApiKey"]);
    client.DefaultRequestHeaders.Add("x-rapidapi-host", builder.Configuration["FootballApi:ApiHost"]);
});

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IWeatherApiService, WeatherApiService>();
builder.Services.AddScoped<IYoutubeService, YoutubeService>();
builder.Services.AddScoped<IRedditService, RedditService>();
builder.Services.AddScoped<ISpotifyService, SpotifyService>();
builder.Services.AddScoped<IGoldService, GoldService>();
builder.Services.AddScoped<IBitcoinService, BitcoinService>();
builder.Services.AddScoped<IMoneyService, MoneyService>();
builder.Services.AddScoped<IFootballService, FootballService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IFuelPriceService,FuelService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICryptoService, CryptoService>();
builder.Services.AddHttpClient<IEarthquakeService, EarthquakeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
