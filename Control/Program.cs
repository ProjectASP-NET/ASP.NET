using DDLiquid.DataAccess.Interfaces;
using DDLiquid.DataAccess.Reps;
using DDLiquid.DataAccess.DB;
using Microsoft.EntityFrameworkCore;
using DDLiquid.BusinessLogic.Mapping;
using DDLiquid.BusinessLogic.Services.BaseProduct;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.BusinessLogic.Services.Product;
using DDLiquid.BusinessLogic.Interfaces.Product.Brand;
using DDLiquid.BusinessLogic.Services.Product.Brand;
using DDLiquid.Domain.Entities.Product;
using DDLiquid.Domain.Entities.BaseProduct.Brand;
using DDLiquid.Domain.Entities.Liquid;
using DDLiquid.Domain.Entities.Vape;
using DDLiquid.Domain.Entities.Consumable;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DDLiquid.BusinessLogic.Helpers;
using DDLiquid.BusinessLogic.Services.Auth;
using DDLiquid.BusinessLogic.Interfaces.Auth;
using DDLiquid.DataAccess.Reps;

var builder = WebApplication.CreateBuilder(args);
var dbConnection = builder.Configuration.GetConnectionString("DDLiquidDB");

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseNpgsql(dbConnection));
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(dbConnection));
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseNpgsql(dbConnection));

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();

var jwtSection = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSection["Key"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidateAudience = true,
            ValidAudience = jwtSection["Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJs", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(ProductContextRepository<>));
builder.Services.AddScoped<IRepository<ProductData>, ProductRepository>();
builder.Services.AddScoped<IRepository<LiquidData>, LiquidRepository>();
builder.Services.AddScoped<IRepository<VapeData>, VapeRepository>();
builder.Services.AddScoped<IRepository<ConsumableData>, ConsumableRepository>();
builder.Services.AddScoped<IRepository<BrandData>, BrandRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ILiquidService, LiquidServices>();
builder.Services.AddScoped<IVapeService, VapeServices>();
builder.Services.AddScoped<IConsumableService, ConsumableServices>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IFlavorService, FlavorService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo { Title = "D&DLiquid API", Version = "v1.0" });
    c.UseInlineDefinitionsForEnums();
    c.UseAllOfToExtendReferenceSchemas();

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.ParameterLocation.Header,
        Description = "Enter your JWT token"
    });

    c.AddSecurityRequirement(document => new Microsoft.OpenApi.OpenApiSecurityRequirement
    {
        [new Microsoft.OpenApi.OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
    });
});

builder.Services.AddAutoMapper(cfg => { }, typeof(ProductMapperProfile).Assembly);

var app = builder.Build();

app.UseCors("AllowNextJs");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var productDb = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    var userDb = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    var orderDb = scope.ServiceProvider.GetRequiredService<OrderDbContext>();

    await DataSeeder.SeedAsync(productDb, userDb, orderDb);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

