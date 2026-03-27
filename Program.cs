
using Assetmanagement.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// REGISTRAR SERVICIOS
builder.Services.AddControllers();
builder.Services.AddDbContext<AssetmanagementContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// PIPELINE CFG.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GLOBAL EXCEPTION HANDLER
app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapControllers();

// EXCEPTION HANDLER PATH
app.Map("/error", (HttpContext http) =>
{
    var error = http.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Results.Problem(error?.Message);
});

app.Run();