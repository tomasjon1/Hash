using Hash_algorithm.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hash_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            HashingService _hashingService = new HashingService();
            TestingService _testingService = new TestingService();

            Console.WriteLine(_hashingService.Hash("ABCD"));
            Console.WriteLine(_hashingService.Hash("abcd"));
            Console.WriteLine(_hashingService.Hash("abcd"));

            _testingService.OutputLenghtTest();
            _testingService.OutputEqualityTest();
            _testingService.OutputCollisionTest();
        }
    }
}
