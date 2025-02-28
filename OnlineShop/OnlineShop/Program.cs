using OnlineShop.Clients;
using OnlineShop.Components;
using OnlineShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

var onlineShopApiUrl=builder.Configuration["OnlineShopApiUrl"]??
    throw new Exception("OnlineShopApiUrl is not set");

builder.Services.AddHttpClient<ProductClient>(
    client=>client.BaseAddress=new Uri(onlineShopApiUrl));
builder.Services.AddHttpClient<ProductTypeClient>(
    client=>client.BaseAddress=new Uri(onlineShopApiUrl));
builder.Services.AddHttpClient<OrderClient>(
    client=>client.BaseAddress=new Uri(onlineShopApiUrl));




// Configure Kestrel server to use specific ports
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5251); // HTTP port
    options.ListenAnyIP(7060, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS port
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
