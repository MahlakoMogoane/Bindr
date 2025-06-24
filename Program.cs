using Microsoft.EntityFrameworkCore;
/*using RedirectFormsPlatform.API.Data;
using RedirectFormsPlatform.API.Services;
using RedirectFormsPlatform.API.Models;
using RedirectFormsPlatform.API.Data.EntityConfigurations;*/
///using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// ───────────────────────────────
// 1. Configure Supabase Client
// ───────────────────────────────
// Register builder with supabase
builder.Services.AddSingleton<Supabase.Client>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();

    var url = configuration["SUPABASE_URL"];
    var publicKey = configuration["SUPABASE_ANON_KEY"];
    var privateKey = configuration["SUPABASE_SECRET_KEY"];

    if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(publicKey) || string.IsNullOrEmpty(privateKey))
    {
        throw new InvalidOperationException("Supabase URL, public key, or private key missing");
    }

    var options = new Supabase.SupabaseOptions
    {
        AutoConnectRealtime = false
    };

    var supabaseClient = new Supabase.Client(url, publicKey, options);

    // Asynchronously initialize client but block startup until it's done
    supabaseClient.InitializeAsync().Wait();

    return supabaseClient;
});


// ───────────────────────────────
// 2. Configure Services
// ───────────────────────────────
// Register DbContext with Npgsql (PostgreSQL)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Register other services
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();


// Dependency Injection for Services
//builder.Services.AddScoped<IPdfService, PdfService>();
//builder.Services.AddScoped<IQrService, QrService>();
//builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();

// AutoMapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Authentication (JWT or Identity example here)
/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });*/

// Swagger (API docs)
/*builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "RedirectForms API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: `Bearer {token}`",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});*/

// ───────────────────────────────
// 3. Build App
// ───────────────────────────────
var app = builder.Build();

// ───────────────────────────────
// 4. Configure Middleware Pipeline
// ───────────────────────────────
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();
