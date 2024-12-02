using System.Text;
using System.Text.Json;

namespace _01._12._2024_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order()
            {
                OrderId = 1,
                CustomerName = "Ubaydullox Ibn Xattob",
                TotalAmount = 10000,
                orderItems = new List<OrderItem>()
                {
                    new()
                    {
                        ItemName = "RTX 4090",
                        Price = 1000,
                        Miqdori = 10,
                    },
                    new()
                    {
                        ItemName = "iPhone 16",
                        Price = 1600,
                        Miqdori = 5,
                    }
                },
            };
            var json1 = JsonSerializer.Serialize(order);
            
            Console.WriteLine("JSON - "+json1.ToString());
            
            json1 = json1.Replace("\"Price\":1000", "\"Price\":120");
            json1 = json1.Replace("\"Price\":1600", "\"Price\":180");
            
            Console.WriteLine("\n\n");
            var memorystream = new MemoryStream();
            var buffer = Encoding.UTF8.GetBytes( json1);
            
            memorystream.Write( buffer, 0, buffer.Length ); 
       

            memorystream.Position = 0;
            var birnarsa = new byte[memorystream.Length];
            memorystream.Read(birnarsa);
            var str = Encoding.UTF8.GetString(birnarsa);
            var birnima = JsonSerializer.Deserialize<Order>(str);
            
            
            Console.WriteLine($"orderID - {birnima.OrderId }\nCustomer Name - {birnima.CustomerName }\nOrder Amount - {birnima.TotalAmount}");
            foreach(var item in birnima.orderItems)
            {
                Console.WriteLine($"\nItem name - {item.ItemName }\nItem Price - {item.Price}\nOrder Quanity - {item.Miqdori}");
            }
        }
    }
}
