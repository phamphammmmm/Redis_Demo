using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// K?t n?i ??n Redis server
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
builder.Services.AddScoped(options => redis.GetDatabase());

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
