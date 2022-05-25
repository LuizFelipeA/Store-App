using System.Text.Json;
using Confluent.Kafka;
using SharedContext.Events;

namespace SharedContext.ExternalServices;

public class KafkaEventService : IEventService
{
    public void QueueAsync(IDomainEvent evt)
    {
        var config = LoadConfig();
        var value = JsonSerializer.Serialize(evt);
        Produce(
            topic: "payments",
            key: evt.Id.ToString(),
            value: value,
            config: config);
    }

    private static ClientConfig LoadConfig()
    {
        var cloudConfig = new Dictionary<string, string>{ };

        var clientConfig = new ClientConfig(cloudConfig);

        return clientConfig;
    }

    // Produce event
    private static void Produce(
        string topic, string key, string value, ClientConfig config)
    {
        using var producer = new ProducerBuilder<string, string>(config).Build();
        producer.Produce(topic, new Message<string, string> { Key = key, Value = value },
            (deliveryReport) =>
            {
                if(deliveryReport.Error.Code != ErrorCode.NoError)
                    throw new Exception(deliveryReport.Error.Reason);
            });
        producer.Flush(TimeSpan.FromSeconds(10));
    }
}
