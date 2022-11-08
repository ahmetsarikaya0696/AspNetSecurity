var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - Cross Origin Resource Sharing
builder.Services.AddCors(options =>
{
    //options.AddDefaultPolicy(policy =>
    //{
    //    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    //});
    options.AddPolicy("AllowedSites", policy =>
    {
        // https://localhost:7071 MVC uygulaması
        policy.WithOrigins("https://localhost:7071").AllowAnyHeader().AllowAnyMethod();
    });

    options.AddPolicy("AllowedSites2", policy =>
    {
        policy.WithOrigins("https://localhost:7071").WithMethods("POST","GET").AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS - Cross Origin Resource Sharing
//app.UseCors("AllowedSites");
// Uygulama bazında Cors uyguladığımızda string ifade belirtmemize gerek yok
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
