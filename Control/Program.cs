using D_DLiquid.DataAccess.Interfaces;
using D_DLiquid.DataAccess.Reps;
using D_DStore.DataAccess.DB;
using Microsoft.EntityFrameworkCore;
using D_DStore.BusinessLogic.Mapping;
using D_DStore.Domain.Entities.Vape;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.Domain.Entities.Consumable;
using D_DStore.BusinessLogic.Services.BaseProduct;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.BusinessLogic.Services.Product;
using D_DStore.BusinessLogic.Interfaces.Product.Brand;
using D_DStore.BusinessLogic.Services.Product.Brand;
var builder = WebApplication.CreateBuilder(args);
var DBconnection = builder.Configuration.GetConnectionString("DBconnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(DBconnection));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await DataSeeder.SeedAsync(db);
}
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
