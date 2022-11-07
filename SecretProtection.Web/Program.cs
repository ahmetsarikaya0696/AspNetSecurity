using System.Data.Common;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ConnectionString
var connectionString = builder.Configuration.GetConnectionString("AspNetSecurityDb");

// SqlConnectionStringBuilder ile Password'ü Con Stringe eklemek
//SqlConnectionStringBuilder sqlConnectionStringBuilder = new(connectionString);
//sqlConnectionStringBuilder.Password = builder.Configuration["Passwords:SqlPassword"];
//string newConStr = sqlConnectionStringBuilder.ConnectionString;


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
