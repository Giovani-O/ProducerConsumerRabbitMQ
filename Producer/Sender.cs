using RabbitMQ.Client;
using System.Text;

namespace Producer;

public class Sender
{
    public static void Main(string[] args)
    {
        // Cria factory de conexão
        var factory = new ConnectionFactory() { HostName = "localhost" };

        // Abre uma conexão
        using(var connection = factory.CreateConnection())
        // Abre um canal para a criação de filas
        using(var channel = connection.CreateModel())
        {
            // Declara uma fila
            channel.QueueDeclare("BasicTest", false, false, false, null);

            // Escreve e criptografa uma mensagem
            string message = "Primeiros passos com .NET Core RabbitMQ";
            var body = Encoding.UTF8.GetBytes(message);

            // Publica a mensagem na fila
            channel.BasicPublish("", "BasicTest", null, body);
            Console.WriteLine("Mensagem enviada: {0}...", message);
        }
        Console.WriteLine("Press enter to exit...");
        Console.ReadLine();
    }
}