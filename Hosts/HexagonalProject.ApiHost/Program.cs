using HexagonalProject.ApiHost.Middleware;
using HexagonalSample.Application.DependencyResolvers;
using HexagonalSample.Persistence.DependencyResolvers;
using HexagonalSample.Persistence.EFData;
using HexagonalSample.WebApi.Controllers;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositoryService();
builder.Services.AddDbContextService();
builder.Services.AddUseCaseService();
builder.Services.AddDtoMapperService();

builder.Services.AddControllers().AddApplicationPart(typeof(CategoryController).Assembly); //burası cok önemli.Cünkü Controller'larin bulundugu assembly'i tanıtıyoruz ki API cagrılarında Controller'lar nerede bulunabilsin...Burada Asp .Net Core'a sunu demiş oluyoruz : "HexagonalSample.WebApi icindeki Controllerları da kullan"
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
