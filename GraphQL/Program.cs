using Castle.Components.DictionaryAdapter.Xml;
using GraphQL.Abstraction;
using GraphQL.Data;
using GraphQL.Models;
using GraphQL.Repository;
using Microsoft.EntityFrameworkCore;
using static HotChocolate.ErrorCodes;
using AutoMapper;
using GraphQL.Mapper;
using GraphQL.Graph.Query;
using GraphQL.Graph.Mutation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
var context = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<StorageContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.MapGraphQL();

app.Run();
