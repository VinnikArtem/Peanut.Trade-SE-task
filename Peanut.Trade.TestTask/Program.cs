using Microsoft.Extensions.Options;
using Peanut.Trade.TestTask.IntegrationService.Models.ClientSettings;
using Peanut.Trade.TestTask.IntegrationService.Services;
using Peanut.Trade.TestTask.IntegrationService.Services.ExchangeClients;
using Peanut.Trade.TestTask.IntegrationService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<BinanceClientSettings>(builder.Configuration.GetSection("BinanceClientSettings"));
builder.Services.Configure<KucoinClientSettings>(builder.Configuration.GetSection("KucoinClientSettings"));

builder.Services.AddTransient<IApiService>(x => new ApiService(
    x.GetService<IHttpClientFactory>(),
    "PeanutTradeClient"));
builder.Services.AddTransient<IExchangeClient>(x => new BinanceClient(
    x.GetService<IApiService>(),
    x.GetService<IOptions<BinanceClientSettings>>().Value));
builder.Services.AddTransient<IExchangeClient>(x => new KucoinClient(
    x.GetService<IApiService>(),
    x.GetService<IOptions<KucoinClientSettings>>().Value));
builder.Services.AddTransient<IArbitrationService, ArbitrationService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
