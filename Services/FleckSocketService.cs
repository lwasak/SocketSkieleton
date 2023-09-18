using Fleck;
using Microsoft.Extensions.Options;
using SocketSkeleton.Settings;

namespace SocketSkeleton.Services;

public class FleckSocketService : IHostedService
{
    private readonly WebSocketServer _server;
    
    public FleckSocketService(IOptions<AppOptions> options)
    {
        var location = $"ws://0.0.0.0:{options.Value.WebSocketPort}";
        
        Console.WriteLine($"Socket url: {location}");
        _server = new WebSocketServer(location);
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _server.Start(socket =>
        {
            socket.OnOpen = OnOpen;
            socket.OnClose = OnClose;
            socket.OnMessage = OnMessage;
        });
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _server.Dispose();
        
        return Task.CompletedTask;
    }

    private void OnOpen()
    {
        Console.WriteLine("Socket open");
    }
    
    private void OnClose()
    {
        Console.WriteLine("Socket closed");
    }
    
    private void OnMessage(string message)
    {
        Console.WriteLine(message);
    }
}