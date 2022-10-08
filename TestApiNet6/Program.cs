using DATA;
using DATA.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var SQL = new SqlConfiguration(builder.Configuration.GetConnectionString("SQLMS"));
builder.Services.AddSingleton(SQL);
builder.Services.AddScoped<IAutoRepositorio, AutoRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
// Test GIT
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
