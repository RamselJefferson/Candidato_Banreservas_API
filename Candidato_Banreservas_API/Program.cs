using Candidato.Infrastructure.Persistance;
using Candidato_Banreservas_API.Extensions;
using Candidato.Core.Application;
using Candidato.Infrastructure.Persistance.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistanceInfrastructure(builder.Configuration);

builder.Services.AddApplicationLayer();


builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy",
             builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ApiCorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseMiddleware<ApiRequestLoggingMiddleware>();
app.Run();
