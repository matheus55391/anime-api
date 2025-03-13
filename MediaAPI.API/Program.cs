using Microsoft.OpenApi.Models;
using MediaAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MediaAPI.Infrastructure.Repositories;
using MediaAPI.Domain.Interfaces;
using MediaAPI.Application.Services;
using MediaAPI.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<MediaService>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();

builder.Services.AddDbContext<MediaDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Media API",
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
    var context = scope.ServiceProvider.GetRequiredService<MediaDbContext>();
    context.Database.Migrate();

    if (!context.Medias.Any())
    {
        context.Medias.AddRange(
            new Media("Naruto", "Masashi Kishimoto", "Naruto Uzumaki, um jovem ninja, busca reconhecimento e sonha em se tornar Hokage."),
            new Media("Dragon Ball Z", "Akira Toriyama", "Goku e seus amigos protegem a Terra contra poderosos inimigos, incluindo alienígenas e deuses."),
            new Media("One Piece", "Eiichiro Oda", "Monkey D. Luffy e sua tripulação navegam pelos mares em busca do lendário tesouro One Piece."),
            new Media("Bleach", "Tite Kubo", "Ichigo Kurosaki, um adolescente com poderes espirituais, luta contra espíritos malignos chamados Hollows."),
            new Media("Fullmetal Alchemist", "Hiromu Arakawa", "Os irmãos Elric usam alquimia para recuperar seus corpos após um experimento fracassado.")
        );

        context.SaveChanges();
    }
}

app.MapControllers();

app.Run();
