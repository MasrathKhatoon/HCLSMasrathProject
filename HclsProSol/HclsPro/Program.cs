using HclsPro.DataAccess.IRepositories;
using HclsPro.DataAccess.Repositories;
using HclsPro.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HCLSDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStrLocal")));
builder.Services.AddTransient<IAdminTypesRepository, AdminTypesRepository>();
builder.Services.AddTransient<IAdminRepository, AdminRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization(); 

app.MapControllers();

app.Run();
