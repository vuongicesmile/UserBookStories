using Autofac.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using UsedBookStore.DataAccess.Contexts;
using UsedBookStore.DataAccess.Repositories;
using UsedBookStore.Infrastructure.Interface;
using UsedBookStore.Infrastructure.Mappings;
using UsedBookStore.Infrastructure.Services;
using UsedBookStore.Infrastructure.Uow;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EfContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("EfContextConnectionStrings")));

builder.Services.AddDbContext<EfAuthContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EfContextAuthConnectionStrings")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<ICategoriesRepository, SQLCategoriesRepository>();
builder.Services.AddScoped<IWalkRepositories, SQLWalkRepository>();



// automapper config
//inject auto mapper config
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
