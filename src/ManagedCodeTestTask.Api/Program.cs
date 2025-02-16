using ManagedCodeTestTask.Application;
using ManagedCodeTestTask.Infrastructure;
using ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterApplication();
builder.Services.RegisterInfrastructure();
builder.Services.RegisterManagedCodeTestTaskDbContext(builder.Configuration);

var app = builder.Build();


// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ManagedCodeTestTaskDbContext>();
    context.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
