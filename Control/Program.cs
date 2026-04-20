using D_DLiquid.DataAccess.Interfaces;
using D_DLiquid.DataAccess.Reps;
using D_DStore.BusinessLogic.Interfaces;
using D_DStore.BusinessLogic.Services;
using D_DStore.DataAccess.DB;
using Microsoft.EntityFrameworkCore;
using D_DStore.BusinessLogic.Mapping;
using D_DStore.Domain.Entities.Vape;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.Domain.Entities.Consumable;
var builder = WebApplication.CreateBuilder(args);
var DBconnection = builder.Configuration.GetConnectionString("DBconnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(DBconnection));
builder.Services.AddScoped<IRepository<LiquidData>, Repository<LiquidData>>();
builder.Services.AddScoped<IRepository<VapeData>, Repository<VapeData>>();
builder.Services.AddScoped<IRepository<ConsumableData>, Repository<ConsumableData>>();
builder.Services.AddScoped<ILiquidService, LiquidServices>();
builder.Services.AddScoped<IVapeService, VapeServices>();
builder.Services.AddScoped<IConsumableService, ConsumableServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => { },typeof(MapperProfile));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
