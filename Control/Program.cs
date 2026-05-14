using D_DLiquid.DataAccess.Interfaces;
using D_DLiquid.DataAccess.Reps;
using D_DStore.DataAccess.DB;
using Microsoft.EntityFrameworkCore;
using D_DStore.BusinessLogic.Mapping;
using D_DStore.BusinessLogic.Services.BaseProduct;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.BusinessLogic.Services.Product;
using D_DStore.BusinessLogic.Interfaces.Product.Brand;
using D_DStore.BusinessLogic.Services.Product.Brand;
using D_DStore.Domain.Entities.Product;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using D_DStore.BusinessLogic.Helpers;
using D_DStore.BusinessLogic.Services.Auth;
using D_DStore.BusinessLogic.Interfaces.Auth;
using D_DStore.DataAccess.Reps;

var builder = WebApplication.CreateBuilder(args);
var dbConnection = builder.Configuration.GetConnectionString("D_DLiquidDB");

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseNpgsql(dbConnection));
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(dbConnection));
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseNpgsql(dbConnection));

// Auth services
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();

// Authentication
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
builder.Services.AddControllers();

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
