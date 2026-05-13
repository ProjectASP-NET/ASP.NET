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
using D_DStore.DataAccess.Reps;
using D_DStore.Domain.Entities.Product;
using D_DStore.Domain.Entities.BaseProduct.Brand;
var builder = WebApplication.CreateBuilder(args);
var DbConnection = builder.Configuration.GetConnectionString("D_DLiquidDB");
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseNpgsql(DbConnection));
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(DbConnection));
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseNpgsql(DbConnection));
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
builder.Services.AddScoped<IRepository<ProductData>,ProductRepository>();
builder.Services.AddScoped<IRepository<BrandData>, BrandRepository>();
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
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => { },typeof(ProductMapperProfile).Assembly);
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
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
