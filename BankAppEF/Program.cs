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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var mapconfig = new MapperConfiguration(options => options.CreateMap<Customer, CustomerModel>());
//AutoMapper.IMapper mapper = mapconfig.CreateMapper();
//builder.Services.AddSingleton(mapper);                

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

builder.Services.AddCors(cors=>cors.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddTransient<ICustomerDTO, CustomerDTO>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IExecutiveDTO, ExecutiveDTO>();
builder.Services.AddTransient<IAdminDTO, AdminDTO>();
builder.Services.AddTransient<ITransactionsDTO, TransactionsDTO>();
builder.Services.AddTransient<IAccountDTO, AccountDTO>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
