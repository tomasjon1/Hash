using Hash_algorithm.Models;
using Hash_algorithm.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Hash_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            TestingService _testingService = new TestingService();
            HashingService _hashingService = new HashingService();

            List<Data> results = new List<Data>();

            Stopwatch timer = new Stopwatch();

            List<string> arguments = args.ToList();
            string inputParam = "", outputParam = "", settingsParam = "";

            if (arguments.First().Contains("-in"))
            {
                inputParam = arguments.First();
                arguments.Remove(inputParam);
                Console.WriteLine($"INPUT {inputParam}");
            }
            

            if (arguments.First().Contains("-out"))
            {
                outputParam = arguments.First();
                arguments.Remove(outputParam);
                Console.WriteLine($"OUTPUT {outputParam}");
            }
          

            if (arguments.First().Contains("-"))
            {
                settingsParam = arguments.First();
                arguments.Remove(settingsParam);
                Console.WriteLine($"SETTING {settingsParam}");
            }

            if (settingsParam == "-t")
            {
                Console.WriteLine("Running tests..");
                _testingService.OutputLenghtTest();
                _testingService.OutputEqualityTest();
                _testingService.OutputCollisionTest();
                _testingService.OutputAvalancheTest();
                _testingService.SpeedTest();
            }
            else
            {
                Console.WriteLine("dfas");

                if (inputParam == "-in")
                    foreach (string arg in arguments)
                    {
                        timer.Start();
                        string hash = _hashingService.Hash(arg);
                        timer.Stop();
                        results.Add(new Data() { Input = arg, Output = hash, Time = timer.Elapsed });
                        timer.Restart();
                    }

                if (inputParam == "-inf")
                    foreach (string arg in arguments)
                    {
                        string readedData = File.ReadAllText(arg);
                        if (readedData.Length > 0)
                        {
                            timer.Start();
                            string hash = _hashingService.Hash(readedData);
                            timer.Stop();
                            results.Add(new Data() { Input = readedData, Output = hash, Time = timer.Elapsed });
                            timer.Restart();
                        }
                    }

                if (outputParam == "-out")
                    if (results.Count > 0)
                        foreach (Data r in results)
                            Console.WriteLine("Input: {0} Output: {1}, Time: {2}", r.Input, r.Output, r.Time);
                    else
                        Console.WriteLine("No results");

                if (outputParam == "-outf")
                {
                    if (!Directory.Exists(AppContext.BaseDirectory + @"Results\"))
                        Directory.CreateDirectory(AppContext.BaseDirectory + @"Results\");

                    if (File.Exists(AppContext.BaseDirectory + @"Results\Results.txt"))
                        File.Delete(AppContext.BaseDirectory + @"Results\Results.txt");

                    foreach (Data r in results)
                        File.AppendAllText(AppContext.BaseDirectory + @"Results\Results.txt", String.Format("Input: {0} \n Output: {1} \n Time{2} \n\n", r.Input, r.Output, r.Time));
                    
                    Console.WriteLine("Results have been saved to files");
                }
            }
        }
    }
}
