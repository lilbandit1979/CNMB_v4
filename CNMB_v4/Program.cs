using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CNMBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CNMBContext") ?? throw new InvalidOperationException("Connection string 'CNMBContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<IRepository, RealDB>();//Added Repo pattern //changed from MockDB
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
