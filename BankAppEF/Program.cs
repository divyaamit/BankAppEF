using Microsoft.EntityFrameworkCore;
using BankAppEF.Data.Entities;
using BankAppEF.Datalayer.Models;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Datalayer.Implementation;
using BankAppEF.Repository.Implementation;
using BankAppEF.Repository.Interface;
using AutoMapper;
using BankAppEF.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapconfig = new MapperConfiguration(options => options.CreateMap<Customer, CustomerModel>());
AutoMapper.IMapper mapper = mapconfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<DbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

builder.Services.AddCors(cors=>cors.AddPolicy("MyPolicy", builder =>
{

    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<ICustomerDTO, CustomerDTO>();
builder.Services.AddScoped<ICustomeRepository, CustomerRepository>();
builder.Services.AddScoped<IExecutiveDTO, ExecutiveDTO>();
builder.Services.AddScoped<IAdminDTO, AdminDTO>();
builder.Services.AddScoped<ITransactionsDTO, TransactionsDTO>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
