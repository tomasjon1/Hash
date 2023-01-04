using Hash_algorithm.Services;
using System;
using System.Collections.Generic;
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

            List<string> arguments = args.ToList();
            string inputParam = "", outputParam = "", settingsParam = "";

            //if (arguments.First().Contains("-in"))
            //{
            //    inputParam = arguments.First();
            //    arguments.Remove(inputParam);
            //}

            //if (arguments.First().Contains("-out"))
            //{
            //    outputParam = arguments.First();
            //    arguments.Remove(outputParam);
            //}

            //if (arguments.First().Contains("-t"))
            //{
            //    Console.WriteLine("Running tests..");
            //    //_testingService.OutputLenghtTest();
            //    //_testingService.OutputEqualityTest();
            //    //_testingService.OutputCollisionTest();
            //    //_testingService.OutputAvalancheTest();
            //    //_testingService.SpeedTest();
            //}

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
                //_testingService.OutputLenghtTest();
                //_testingService.OutputEqualityTest();
                //_testingService.OutputCollisionTest();
                //_testingService.OutputAvalancheTest();
                //_testingService.SpeedTest();
            }


        }
    }
}
