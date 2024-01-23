using Microsoft.EntityFrameworkCore;
using NTierApplication.DataAccess;
using NTierApplication.Repository;
using NTierApplication.Service;
using NTierApplication.Service.Common.Interface;
using NTierApplication.Service.Common.Service;
using NTierApplication.Service.Helpers;
using NTierApplication.Web.ActionHelpers;
using NTierApplication.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.ConfigureCORSPolice();

builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaginator, Paginator>();
builder.Services.AddTransient<MainContext>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddDbContext<MainContext>(options => {
    options.UseSqlServer("Data Source=localhost;User ID=sa;Password=3022;Initial Catalog=NTierApplication;TrustServerCertificate=True;");
});

builder.ConfigurationJwtAuth();
builder.ConfigureSwaggerAuth();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
