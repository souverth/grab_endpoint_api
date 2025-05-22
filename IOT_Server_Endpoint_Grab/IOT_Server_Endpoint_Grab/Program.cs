using System.Reflection;
using IOT_Server_Endpoint_Grab.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//tự động đăng kí service ở thư mục 
builder.Services.AddServicesFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Cho phép Swagger UI cả ở Production (nếu cần)
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "EOrder Grab API Docs";
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Grab Integration API v1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
