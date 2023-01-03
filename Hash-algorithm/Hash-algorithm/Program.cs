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

            Console.WriteLine(_hashingService.Hash("2222"));
            Console.WriteLine(_hashingService.Hash("2222"));
        }
    }
}
