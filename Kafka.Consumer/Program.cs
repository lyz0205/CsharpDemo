using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = "127.0.0.1:9092",
                    // Disable auto-committing of offsets.
                    EnableAutoCommit = false,
                    GroupId = "consumergroup1"
                };

                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    CancellationTokenSource cancellationToken = new CancellationTokenSource();

                    consumer.Subscribe("topic_messages");

                    bool cancelled = false;

                    Console.CancelKeyPress += (_, e) => {
                        e.Cancel = true;
                        cancelled = true;
                        cancellationToken.Cancel();
                    };

                    while (!cancelled)
                    {
                        var consumeResult = consumer.Consume(cancellationToken.Token);
                        Console.WriteLine($"Consumed message '{consumeResult.Value}' at: '{consumeResult.TopicPartitionOffset}'.");
                    }

                    consumer.Close();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
