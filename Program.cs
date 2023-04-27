using Blazored.LocalStorage;
using FinalYearProjectWasmPortal;
using FinalYearProjectWasmPortal.Helpers;
using FinalYearProjectWasmPortal.Services;
using FinalYearProjectWasmPortal.Settings;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<ProfileStateService>();
builder.Services.AddScoped<AppState>();
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
var appSettings = appSettingsSection.Get<AppSettings>();

builder.Services.AddHttpClientForApiAuth(appSettings.APIBaseUrl);
builder.Services.AddGeneratedApiClients(appSettings.APIBaseUrl);

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthenticationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<HubConnection>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();