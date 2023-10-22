using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.Repositories;
using UsedBookStore.Infrastructure.Interface;
using UsedBookStore.Infrastructure.Services;
using UsedBookStore.Infrastructure.Uow;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EfContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("EfContextConnectionStrings")));


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


// automapper config
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ICategoriesRepository, SQLCategoriesRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
