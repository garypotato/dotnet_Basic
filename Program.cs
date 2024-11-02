using HelloWorld.Data;
using HelloWorld.Models;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContextDapper dapper = new();

            string sqlSelect = "SELECT * FROM TutorialAppSchema.Computer";
            
            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            foreach (var computer in computers)
            {
                Console.WriteLine(computer.Motherboard);
            }            
        }
    }
} 