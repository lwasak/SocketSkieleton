using SocketSkeleton.Services;
using SocketSkeleton.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddOptions<AppOptions>()
    .BindConfiguration(AppOptions.SectionName)
    .ValidateOnStart();

builder.Services.AddHostedService<FleckSocketService>();

var app = builder.Build();

app.MapControllers();

app.Run();