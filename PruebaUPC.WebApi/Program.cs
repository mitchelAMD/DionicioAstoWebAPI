using PruebaUPC.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Application Services
builder.Services.AddApplicationServices();
// Add Cache
builder.Services.AddMemoryCache();

// Add Logging
builder.Logging.AddFile(o => {
    o.RootPath = AppContext.BaseDirectory;
    o.PathPlaceholderResolver = (placeholderName, inlineFormat, context) => placeholderName switch
    {
        "appname" => "PruebaUPC",
        "date" => DateTime.Today.ToString("yyyyMMdd"),
        _ => null,
    };
});

// Add Cache

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
