using Apollo.Extensions.Microsoft.Hosting;
using DasMonitor;
using DasMonitor.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

// keyboard client
builder.Services.AddHttpClient<DasSignalClient>(
    // only necessary if you need to override the base address
    // this is the default base address if you don't specify one
    //client => client.BaseAddress = new Uri(DasMonitorConstants.BaseSignalUrl)
);

// apollo plumbing
builder.Services.AddApollo(ab =>
    ab.AddEndpoint<DasMonitorEndpoint>(DasMonitorConstants.EndpointConfig)
);

// listening
builder.Services.AddSingleton<DasMonitorEndpoint>();

// publishing (HostDemo)
builder.Services.AddSingleton<DasPublisher>();

var host = builder.Build();
//host.Run();  // this won't do anything yet, it's in-memory only
await DasDemo.HostDemo(host);