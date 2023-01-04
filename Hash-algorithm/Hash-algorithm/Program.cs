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

            //_testingService.OutputLenghtTest();
            //_testingService.OutputEqualityTest();
            //_testingService.OutputCollisionTest();
            //_testingService.OutputAvalancheTest();
            _testingService.SpeedTest();
        }
    }
}
