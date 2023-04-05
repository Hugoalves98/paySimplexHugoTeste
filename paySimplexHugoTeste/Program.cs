using Infra.ConfigurationInjector;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer("workstation id=paySimplexTeste.mssql.somee.com;packet size=4096;user id=HugAlves_SQLLogin_1;pwd=xvxidoropo;data source=paySimplexTeste.mssql.somee.com;persist security info=False;initial catalog=paySimplexTeste").EnableSensitiveDataLogging());
builder.Services.RegisterService();
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = services.GetRequiredService<Context>();
	context.Database.Migrate();

}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
