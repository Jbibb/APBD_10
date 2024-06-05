using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using solution.Contexts;
using Microsoft.EntityFrameworkCore;
using solution.Exceptions;
using solution.ResponseModels;
using solution.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IService, Service>();
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/accounts/{accountId:int}", async (IConfiguration configuration, DatabaseContext databaseContext, IService service, int accountId)=>
{
    try
    {
        return Results.Ok(await service.GetAccount(accountId));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});

app.MapPost("/api/products", async (IConfiguration configurationBinder, DatabaseContext databaseContext, IService service, AddProductRequestModel request) =>
{
    try
    {
        await service.AddProductApplyCategories(request);
        return Results.Created();
    }
    catch (CategoryValidationException e)
    {
        return Results.ValidationProblem(e.Errors);
    }
});

app.Run();

