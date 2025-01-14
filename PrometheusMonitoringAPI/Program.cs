using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseMetricServer();  // Exposes metrics on /metrics
app.UseHttpMetrics();   // Automatically captures HTTP-related metrics

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMetricServer();  // Exposes metrics on /metrics
app.UseHttpMetrics();   // Automatically captures HTTP-related metrics

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
