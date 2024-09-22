using Apollo.Abstractions;

namespace DasMonitor.Abstractions;

public class DasMonitorEndpoint : IHandle<AddSignalCommand>
{
    private readonly DasSignalClient dasClient;

    public DasMonitorEndpoint(DasSignalClient dasClient)
    {
        this.dasClient = dasClient;
    }

    public async Task Handle(AddSignalCommand command, CancellationToken cancellationToken)
    {
        var result = await dasClient.SendSignalAsync(command, cancellationToken);
        Console.WriteLine($"Success: {result.Success}");
        if (!result.Success)
            Console.WriteLine($"Error: {result.ErrorMessage}");
    }
}