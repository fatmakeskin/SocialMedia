using Business.Base.IServices;
using Business.Base.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Burada farklı bir kullanım şekli olarak yazılabilir Context sınıfında onModelConfigurin olmadığı durumlarda kullanılır.
////builder.Services.AddDbContext<MasterContext>(x => x.UseMySQL("Server=localhost;Database=newDb;Uid=root;Pwd=root;"));
//builder.Services.AutoMapper(AppDomain.CurrentDomain.GetAssemblies);
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IPostService, PostService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
