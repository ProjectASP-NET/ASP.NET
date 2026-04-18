using D_DStore.DataAccess.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var DBconnection = builder.Configuration.GetConnectionString("DBconnetion");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(DBconnection));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
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
