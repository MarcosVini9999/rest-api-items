using Microsoft.EntityFrameworkCore;
using rest_api_items.Domain.Repositories;
using rest_api_items.Domain.Repositories.IRepositories;
using rest_api_items.Persistence.Contexts;
using rest_api_items.Services;
using rest_api_items.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseInMemoryDatabase("groceries-api-in-memory");
});
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var scope = app.Services.CreateScope();

using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
