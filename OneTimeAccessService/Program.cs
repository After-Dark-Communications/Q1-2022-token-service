using OneTimeAccess.IServices;
using OneTimeAccess.Services;
using TokenParser;

var builder = WebApplication.CreateBuilder(args);

SetupServices(builder);

SetupApp(builder);


void SetupServices(WebApplicationBuilder builder)
{
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    AddTransient(builder);
}

static void SetupApp(WebApplicationBuilder builder)
{
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "OneTimeAccess V1");
        }
        
        );
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    Serializer.EnsureFileExists();

    app.Run();
}

static void AddTransient(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IOneTimeAccessService, OneTimeAccessService>();
}
