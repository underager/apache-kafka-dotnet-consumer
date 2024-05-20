// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;

var config = new ConsumerConfig
{
    GroupId = "gid-consumer",
    BootstrapServers = "localhost:9002"
};

using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
{
    consumer.Subscribe("rider-update");

    while(true)
    {
        var bookingDetails = consumer.Consume();
        Console.WriteLine(bookingDetails.Message.Value);
    }
}
// Console.WriteLine("Hello, World!");
