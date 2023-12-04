using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HernandezJorge_API_Ej2.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HernandezJorge_API_Ej2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HernandezJorge_API_Ej2Context") ?? throw new InvalidOperationException("Connection string 'HernandezJorge_API_Ej2Context' not found.")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Agregar el contexto que vamos a usar.
builder.Services.AddDbContext<HernandezJorge_API_Ej2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HernandezJorge_API_Ej2Context") ?? throw new InvalidOperationException("Connection string 'Games_Keliam_IdentityContext' not found.")));
//Agregar al archivo de contexto de los usuarios.
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbContext") ?? throw new InvalidOperationException("Connection string  'UsersDbContext' not found.")));
//Ignorar los ciclos.
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//Agregar los roles para los usuarios.
builder.Services.AddIdentityCore<IdentityUser>(options =>
 options.SignIn.RequireConfirmedEmail = false)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<UserDbContext>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = "GameStoreApp",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api de Jorge Hernández Toledo", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Autorización",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] { }
        }
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

//Va esto primero
app.UseAuthentication();
//-----------------------
app.UseAuthorization();

app.MapControllers();

app.Run();
