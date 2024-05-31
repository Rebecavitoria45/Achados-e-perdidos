using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication1.Database;
using WebApplication1.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});



// Add services to the container.
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ObjetoService>();
builder.Services.AddScoped<DocumentoService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Achados e Perdidos",
        Description = "API Rest para um sistema de Achados e Perdidos",
         Contact = new OpenApiContact
        {
            Name = "Rebeca vitória",
            Url = new Uri("https://github.com/Rebecavitoria45")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://example.com/license")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexao"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
