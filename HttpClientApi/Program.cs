using HttpClientApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddControllers();
//es muy importante el AddScopped ya que es un error comun inyectar la interface en el controlador pero no instancear el servicio
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddTransient<IBeerService,BeerService>();
builder.Services.AddHttpClient("Books", b => {
    b.BaseAddress = new Uri(configuration.GetValue<string>("Endpoint:UrlBooks"));
});
builder.Services.AddHttpClient("Beers", b => {
    b.BaseAddress = new Uri(configuration.GetValue<string>("Endpoint:UrlBeers"));
});
builder.Services.AddHttpClient<IBirdsService, BirdsService>(client =>
{
    client.BaseAddress = new Uri(configuration.GetValue<string>("Endpoint:UrlBirds"));
    client.Timeout = TimeSpan.FromSeconds(20);
    client.DefaultRequestHeaders.Add("HEADER_API_KEY", "claveficticia");
    
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HttpClient API", Description = "APIs de tipo get que consumen otras apis, hechas con inyeccion de dependencias, httpClient y httpClientFactory" })

    );

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