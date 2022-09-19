using IncredibleBackend.Messaging.Extentions;
using IncredibleBackendContracts.Constants;
using MassTransit;
using SmsSender;
using SmsSender.MassTransit;
using SmsSenderApi;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "SmsSender";
    })
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.AddHostedService<Worker>();
        services.AddScoped<ISenderService, SenderService>();
        services.RegisterConsumersAndProducers((config) =>
        {
            config.AddConsumer<SmsConsumer>();
        }, (cfg, ctx) =>
        {
            cfg.ReceiveEndpoint("TEEEEEST", c =>
            {
                c.ConfigureConsumer<SmsConsumer>(ctx);
            });
        }, null
        );
    })
    .Build();


await host.RunAsync();
