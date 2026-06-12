using ApiUsuarios.Data;
using ApiUsuarios.Models;
using ApiUsuarios.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ApiUsuarios", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Ingrese el token JWT así: Bearer {token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UsuariosDB"));

var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Usuarios.Any())
    {
        db.Usuarios.Add(new Usuario
        {
            Nombre = "Enmanuel",
            Correo = "enmanuelacevedoarias@gmail.com",
            Username = "Popeye",
            PasswordHash = PasswordService.HashPassword("Enmanuel123"),
            FechaDeNacimiento = new DateTime(2004, 11, 10)
        });
        db.SaveChanges();
    }
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Usuarios.Any())
    {
        db.Usuarios.Add(new Usuario
        {
            Nombre = "Admin",
            Correo = "admin@example.com",
            Username = "admin",
            PasswordHash = PasswordService.HashPassword("Admin123!"),
            FechaDeNacimiento = new DateTime(1990, 1, 1)
        });
    }

    if (!db.Categorias.Any())
    {
        db.Categorias.AddRange(
            new Categoria { Nombre = "Electrónica" },
            new Categoria { Nombre = "Ropa" },
            new Categoria { Nombre = "Hogar" }
        );
    }

    if (!db.Proveedores.Any())
    {
        db.Proveedores.AddRange(
            new Proveedor { Nombre = "Proveedor A", Contacto = "contacto@proveedora.com" },
            new Proveedor { Nombre = "Proveedor B", Contacto = "contacto@proveedorb.com" }
        );
    }

    db.SaveChanges();

    if (!db.Productos.Any())
    {
        var catElectronica = db.Categorias.First(c => c.Nombre == "Electrónica");
        var catRopa = db.Categorias.First(c => c.Nombre == "Ropa");
        var provA = db.Proveedores.First(p => p.Nombre == "Proveedor A");
        var provB = db.Proveedores.First(p => p.Nombre == "Proveedor B");

        db.Productos.AddRange(
            new Producto { Nombre = "Laptop", Precio = 1200, Stock = 10, IdProveedor = provA.Id, IdCategoria = catElectronica.Id },
            new Producto { Nombre = "Smartphone", Precio = 800, Stock = 25, IdProveedor = provA.Id, IdCategoria = catElectronica.Id },
            new Producto { Nombre = "Camiseta", Precio = 25, Stock = 50, IdProveedor = provB.Id, IdCategoria = catRopa.Id },
            new Producto { Nombre = "Auriculares", Precio = 150, Stock = 30, IdProveedor = provA.Id, IdCategoria = catElectronica.Id }
        );
    }

    db.SaveChanges();
}
app.Run();