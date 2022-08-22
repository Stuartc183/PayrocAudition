using ShortUrlApi.BusinessLogic;
using ShortUrlApi.Data.Contexts;
using ShortUrlApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShortUrlDbContext>();
builder.Services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
builder.Services.AddScoped<IDatabaseAccess, DatabaseAccess>();
builder.Services.AddScoped<IUniqueCodeGenerator, UniqueCodeGenerator>();
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
