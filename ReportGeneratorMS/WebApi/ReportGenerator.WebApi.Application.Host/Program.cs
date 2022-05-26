using ReportGenerator.Host;

var builder = WebApplication.CreateBuilder(args);


builder.AddSerilog();

builder.Services.AddControllers(options => options.EnableEndpointRouting = false);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication();
builder.Services.AddRouting();
//builder.Services.AddErrorHandling();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .RegisterDatabases(builder.Configuration)
    .RegisterRepositories()
    .RegisterServices()
    .RegisterApplicationControllers()
    .AddCustomCors(builder.Configuration);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
//app.UseErrorHandling();
app.UseMvc();
app.MapControllers();

app.Run();