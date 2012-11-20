using System;
using System.IO;
using InfusionSoft;

namespace Generator
{
    class Program
    {
        private const string Output = @"..\..\..\InfusionSoft";

        [STAThread]
        static void Main()
        {
            var assembly = typeof (IInfusionSoftConfiguration).Assembly;

            var generator = new ServiceGenerator(assembly)
            {
                InterfaceDirectory = Path.Combine(Output, ".").Directory(),
                WrapperDirectory = Path.Combine(Output, "Wrappers").Directory()
            };
            
            Service[] services = generator.Generate();

            Console.Out.WriteLine("{0} services created", services.Length);

            Console.Out.WriteLine("done");
            Console.ReadKey();
        }
    }
}

