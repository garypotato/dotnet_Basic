// using System.Text.Json;
// using AutoMapper;
// using HelloWorld.Data;
// using HelloWorld.Models;
// using Microsoft.Extensions.Configuration;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Serialization;

// namespace HelloWorld
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             IConfiguration config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

//             // -----------------------------------------Dapper-----------------------------------------
//             // Console.WriteLine("Below is from Dapper");
//               DataContextDapper dapper = new(config);
//             // string sqlSelect = "SELECT * FROM TutorialAppSchema.Computer";
            
//             // IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

//             // foreach (var computer in computers)
//             // {
//             //     Console.WriteLine(computer.Motherboard);
//             // }

//             // -----------------------------------------EF-----------------------------------------
//             //  DataContextEF entityFramework = new(config);
//             // Console.WriteLine("Below is from EF");
//             // IEnumerable<Computer>? computersEF = entityFramework.Computer?.ToList<Computer>();   
//             // if(computersEF != null)
//             // {
//             //     foreach (var computer in computersEF)
//             //     {   
//             //         Console.WriteLine(computer.ComputerId);
//             //         Console.WriteLine(computer.Motherboard);
//             //         Console.WriteLine(computer.CPUCores);
//             //         Console.WriteLine(computer.HasWifi);
//             //         Console.WriteLine(computer.HasLTE);
//             //         Console.WriteLine(computer.ReleaseDate);
//             //         Console.WriteLine(computer.Price);
//             //         Console.WriteLine(computer.VideoCard);
//             //     }
//             // }

//             // -----------------------------------------Red and Write File-----------------------------------------
//             // Computer myComputer = new()
//             // {
//             //     Motherboard = "ASUS ROG Strix Z490-E Gaming",
//             //     CPUCores = 8,
//             //     HasWifi = true,
//             //     HasLTE = false,
//             //     ReleaseDate = new DateTime(),
//             //     Price = 3000.00M,
//             //     VideoCard = "NVIDIA GeForce RTX 3080"
//             // };
//             // string sql =  @"INSERT INTO TutorialAppSchema.Computer (
//             //         Motherboard, 
//             //         CPUCores, 
//             //         HasWifi, 
//             //         HasLTE, 
//             //         ReleaseDate, 
//             //         Price, 
//             //         VideoCard
//             //     ) VALUES ('"+ myComputer.Motherboard + "', " + myComputer.CPUCores + ", " + myComputer.HasWifi + ", " + myComputer.HasLTE + ", '" + myComputer.ReleaseDate + "', " + myComputer.Price + ", '" + myComputer.VideoCard + "')";
            
//             // File.WriteAllText("log.txt", "\n" + sql + "\n");

//             // using StreamWriter openFile = new("log.txt", append: true);
//             // openFile.WriteLine("\n" + sql + "\n");
//             // openFile.Close();

//             // string fileText = File.ReadAllText("log.txt");
//             // Console.WriteLine(fileText);

//             // -----------------------------------------JSon-----------------------------------------
//             // string computersJson = File.ReadAllText("Computers.json");
//             // serialise 
//             //// dotnet default json serializer
//             // JsonSerializerOptions options = new()
//             // {
//             //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//             // };
//             // IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);
//             // //// Newtonsoft json serializer
//             // JsonSerializerSettings settings = new()
//             // {
//             //     ContractResolver = new CamelCasePropertyNamesContractResolver()
//             // };
//             // IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

//             // deserialise
//             // string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);
//             // File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);
//             // string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
//             // File.WriteAllText("computersCopySystem.txt", computersCopySystem);

//             // if(computersNewtonSoft != null)
//             // {
//             //     foreach(Computer computer in computersNewtonSoft)
//             //     {
//             //         string sql =  @"INSERT INTO TutorialAppSchema.Computer (
//             //             Motherboard, 
//             //             HasWifi, 
//             //             HasLTE, 
//             //             ReleaseDate, 
//             //             Price, 
//             //             VideoCard
//             //         ) VALUES ('"+ EscapeSingleQuote(computer.Motherboard) 
//             //         + "', '" + computer.HasWifi
//             //         + "', '" + computer.HasLTE 
//             //         + "', '" + computer.ReleaseDate?.ToString("yyyy-MM-dd")
//             //         + "', '" + computer.Price 
//             //         + "', '" + EscapeSingleQuote(computer.VideoCard) 
//             //         + "')";

//             //         dapper.ExecuteSql(sql);
//             //     }
//             // }

//             // auto mapper method 1
//             // string computersJson = File.ReadAllText("ComputersSnake.json");
//             // Mapper mapper = new(new MapperConfiguration(cfg => {
//             //     cfg.CreateMap<ComputerSnake, Computer>()
//             //         .ForMember(dest => dest.ComputerId, opt => opt.MapFrom(src => src.computer_id))
//             //         .ForMember(dest => dest.CPUCores, opt => opt.MapFrom(src => src.cpu_cores))
//             //         .ForMember(dest => dest.HasLTE, opt => opt.MapFrom(src => src.has_lte))
//             //         .ForMember(dest => dest.HasWifi, opt => opt.MapFrom(src => src.has_wifi))
//             //         .ForMember(dest => dest.Motherboard, opt => opt.MapFrom(src => src.motherboard))
//             //         .ForMember(dest => dest.VideoCard, opt => opt.MapFrom(src => src.video_card))
//             //         .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.release_date))
//             //         .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price));
//             // }));
//             // IEnumerable<ComputerSnake>? computersSnake = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);
//             // if(computersSnake != null)
//             // {
//             //     IEnumerable<Computer>? computerResult = mapper.Map<IEnumerable<Computer>>(computersSnake);

//             //     foreach (Computer computer in computerResult)
//             //     {
//             //         Console.WriteLine(computer.Motherboard);
//             //     }
//             // }
//             // auto mapper method 2: use json property attribute 'JsonPropertyName' in the model
//             string computersSnakeSystemJsonPropertyMapping = File.ReadAllText("ComputersSnake.json");
//             IEnumerable<Computer>? ComputerSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersSnakeSystemJsonPropertyMapping);
//              if(ComputerSystem != null)
//             {
//                 foreach (Computer computer in ComputerSystem)
//                 {
//                     Console.WriteLine(computer.Motherboard);
//                 }
//             }
//         }

//         static string EscapeSingleQuote(string input)
//         {
//             string output = input.Replace("'", "''");
//             return output;
//         }
//     }
// } 


// ------------------------------------
// * async/await
// ------------------------------------
namespace HelloWorld
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task firstTask = new Task(() => {
                Thread.Sleep(100);
                Console.WriteLine("Task 1");
            });
            firstTask.Start();

            Task secondTask = ConsoleAfterDelayAsync("Task2 ", 150);

            ConsoleAfterDelay("Delay", 75);

            Task thirdTask = ConsoleAfterDelayAsync("Task3 ", 50);

            await secondTask;
            await firstTask;
            Console.WriteLine("After the Task was created");

            await thirdTask;
        } 

        static void ConsoleAfterDelay(string text, int delayTime)
        {
            Thread.Sleep(delayTime);
            Console.WriteLine(text);
        }

        static async Task ConsoleAfterDelayAsync(string text, int delayTime)
        {
            await Task.Delay(delayTime);
            Console.WriteLine(text);
        }
    }
}