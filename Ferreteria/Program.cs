using Ferreteria.Models;
using Ferreteria.Repositories;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services;
using Ferreteria.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// aca cambien el nombre de la variable por el nombre de la coneccion del appseting de cada uno
string connectionName = "FabrizioConnection";

builder.Services.AddDbContext<FerreteriaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(connectionName)
    )
);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Ingresá tu token JWT sin escribir Bearer."
    });

    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecuritySchemeReference(
                    "Bearer",
                    document
                ),
                new List<string>()
            }
        });
});
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

var jwtKey = builder.Configuration["Jwt:Key"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            ),

            RoleClaimType = System.Security.Claims.ClaimTypes.Role,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5500",
                "http://127.0.0.1:5500"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
   
}




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Frontend");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();