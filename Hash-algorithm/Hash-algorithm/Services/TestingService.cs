using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_algorithm.Services
{
    public class TestingService
    {

        HashingService _hashingService = new HashingService();

        // lenght test     
        // similarity test
        // collision test
        // avalanche test
        // speed test

        public void OutputLenghtTest()
        {
            for (int i = 1; i < 10000; i *= 10)
            {
                string output = _hashingService.Hash(i.ToString());

                if (output.Length == 64)
                    continue;
                else
                {
                    Console.WriteLine("Output is not 256 bits");
                    return;
                }
            }
            Console.WriteLine("Every output was 256 bits");
        }
    }
}
