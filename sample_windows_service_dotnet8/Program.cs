using Microsoft.Extensions.Hosting.WindowsServices;
using sample_windows_service_dotnet8;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "sample-windows-service-dotnet8";
});

if (WindowsServiceHelpers.IsWindowsService())
{
    builder.Services.AddSingleton<IHostLifetime, SampleServiceLifetime>();
}

builder.Logging.AddDebug();

var host = builder.Build();
host.Run();
