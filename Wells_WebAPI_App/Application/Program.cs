using Microsoft.EntityFrameworkCore;
using Wells_WebAPI.Data.Repository;
using Wells_WebAPI.Data.Repository.Interfaces;
using Wells_WebAPI.Data.Services;
using Wells_WebAPI.Data.Services.Interfaces;
using Wells_WebAPI.Persistence.Database;
using Wells_WebAPI.Persistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDrillBlockService, DrillBlockService>();
builder.Services.AddScoped<IHoleService, HoleService>();
builder.Services.AddScoped<IDrillBlockPointsService, DrillBlockPointsService>();
builder.Services.AddScoped<IHolePointsService, HolePointsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
