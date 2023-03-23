using Microsoft.EntityFrameworkCore;
using BankAppEF.Data.Entities;
using BankAppEF.Datalayer.Models;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Implementation;
using BankAppEF.Repository.Implementation;
using BankAppEF.Repository.Interface;
using BankApp.Repository.Interface;
using BankApp.Repository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using BankApp.Datalayer.Interface;
using BankApp.Datalayer.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();              

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

builder.Services.AddCors(cors=>cors.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddTransient<ICustomerDTO, CustomerDTO>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IExecutiveDTO, ExecutiveDTO>();
builder.Services.AddTransient<IAdminDTO, AdminDTO>();
builder.Services.AddTransient<ITransactionsDTO, TransactionsDTO>();
builder.Services.AddTransient<IAccountDTO, AccountDTO>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAuthentication();

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

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
