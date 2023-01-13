using DbUp;
using System.Reflection;
namespace Checkout.Migrations
{
    class Program

    {

        static int Main(string[] args)

        {

            var connectionString = args.FirstOrDefault() ?? "Server=DESKTOP-LHSQMU9\\SQLEXPRESS01; Database=MyApp; Trusted_connection=true";



            EnsureDatabase.For.SqlDatabase(connectionString);



            var upgrader =

                DeployChanges.To

                    .SqlDatabase(connectionString)

                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())

                    .LogToConsole()

                    .Build();



            var result = upgrader.PerformUpgrade();



            if (!result.Successful)

            {

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(result.Error);

                Console.ResetColor();



                Console.ReadLine();



                return -1;

            }



            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Success!");

            Console.ResetColor();

            return 0;

        }

    }
}