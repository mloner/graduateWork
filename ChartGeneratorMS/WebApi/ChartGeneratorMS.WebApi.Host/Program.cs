
using ChartGenerator.Host;

var builder = WebApplication.CreateBuilder(args);


builder.AddSerilog();

builder.Services.AddControllers(options => options.EnableEndpointRouting = false);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication();
builder.Services.AddRouting();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .RegisterServices()
    //.AddCustomCors()
    ;


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.UseMvc();
app.MapControllers();

app.Run();