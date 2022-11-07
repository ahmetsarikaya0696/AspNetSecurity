using WhiteBlackList.Web.Filters;
using WhiteBlackList.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// IPList Configuration
var config = builder.Configuration;
builder.Services.Configure<IPList>(config.GetSection("IPList")); // appsettingteki key ve valueları IPList sınıfı içine doldurur.

// CheckWhiteListFilter
builder.Services.AddScoped<CheckWhiteListFilter>();
// ServiceFilter üzerinden kullanılabilir.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// IPSafeMiddleware
//app.UseMiddleware<IPSafeMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
