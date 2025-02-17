using TWSInfo.Service.IService;
using TWSInfo.Service;
using TWSInfo.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using TWSInfo.Models.EFModels;
using TWSInfo.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        builder => { builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader(); });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TWSInfoDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("TWSInfoConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IChainService, ChainService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<ITypeService, TypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
