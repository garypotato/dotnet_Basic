using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            DataContextDapper dapper = new(config);
            DataContextEF entityFramework = new(config);

            Console.WriteLine("Below is from Dapper");
            string sqlSelect = "SELECT * FROM TutorialAppSchema.Computer";
            
            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            foreach (var computer in computers)
            {
                Console.WriteLine(computer.Motherboard);
            }

            Console.WriteLine("Below is from EF");
            IEnumerable<Computer>? computersEF = entityFramework.Computer?.ToList<Computer>();   
            if(computersEF != null)
            {
                foreach (var computer in computersEF)
                {   
                    Console.WriteLine(computer.ComputerId);
                    Console.WriteLine(computer.Motherboard);
                    Console.WriteLine(computer.CPUCores);
                    Console.WriteLine(computer.HasWifi);
                    Console.WriteLine(computer.HasLTE);
                    Console.WriteLine(computer.ReleaseDate);
                    Console.WriteLine(computer.Price);
                    Console.WriteLine(computer.VideoCard);
                }
            }
        }
    }
} 