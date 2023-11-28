using TriumphSupportUtility.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Service_Agent>();
    })
    .Build();
host.Run();