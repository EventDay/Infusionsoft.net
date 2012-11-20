using System;
using InfusionSoft;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            const string application = "eventday";
            const string apiKey = "04cba82a06a1a004c39aee4da494e0ce";

            var customer = new Customer(application, apiKey);
            var client = customer.Connect();

            client.MethodListener = new DebugMethodListener();

            Console.Out.WriteLine(client.ContactService.Update(105, setter =>
            {
                setter.Set(c => c.FirstName, "Joe");
                setter.Set(c => c.LastName, "Bobertson");
            }));

            Console.Out.WriteLine("done");
            Console.ReadLine();
        }
    }
}
