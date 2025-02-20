using Microsoft.OpenApi.Models;
using AnimeAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AnimeAPI.Infrastructure.Repositories;
using AnimeAPI.Domain.Interfaces;
using AnimeAPI.Application.Services;
using AnimeAPI.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<AnimeService>();
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();

builder.Services.AddDbContext<AnimeDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Anime API",
        Version = "v1"
    });

    // Configuração para JWT no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {seu_token}",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.EnableAnnotations();
    // c.OperationFilter<AuthorizeCheckOperationFilter>();
});

// Configuração de autenticação e autorização com JWT
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.RequireHttpsMetadata = false; // Defina como true em produção
//         options.SaveToken = true;
//         options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sua-chave-secreta-aqui")), // Trocar por um valor seguro
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AnimeDbContext>();
    context.Database.Migrate();

    if (!context.Animes.Any())
    {
        context.Animes.AddRange(
            new Anime("Naruto", "Masashi Kishimoto", "Naruto Uzumaki, um jovem ninja, busca reconhecimento e sonha em se tornar Hokage."),
            new Anime("Dragon Ball Z", "Akira Toriyama", "Goku e seus amigos protegem a Terra contra poderosos inimigos, incluindo alienígenas e deuses."),
            new Anime("One Piece", "Eiichiro Oda", "Monkey D. Luffy e sua tripulação navegam pelos mares em busca do lendário tesouro One Piece."),
            new Anime("Bleach", "Tite Kubo", "Ichigo Kurosaki, um adolescente com poderes espirituais, luta contra espíritos malignos chamados Hollows."),
            new Anime("Fullmetal Alchemist", "Hiromu Arakawa", "Os irmãos Elric usam alquimia para recuperar seus corpos após um experimento fracassado.")
        );

        context.SaveChanges();
    }
}

app.MapControllers();

app.Run();
