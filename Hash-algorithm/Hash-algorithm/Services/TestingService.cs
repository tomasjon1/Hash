using Hash_algorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hash_algorithm.Services
{
    public class TestingService
    {

        HashingService _hashingService = new HashingService();
        HelperService _helperService = new HelperService();

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

        public void OutputEqualityTest()
        {
            int matches = 0;

            for (int i = 0; i < 100000; i++)
            {
                string s1 = i.ToString();
                string s2 = i.ToString();

                if(_hashingService.Hash(s1) == _hashingService.Hash(s2))
                    matches++;
                else
                {
                    Console.WriteLine($"The hashes of {i} ware not the same");
                }
            }

            Console.WriteLine($"there ware {matches} matches out of 100000 cases");
        }

        public void OutputCollisionTest()
        {
            int collisions = 0;

            for (int i = 0; i < 100000; i++)
            {
               
            }

        }
    }
}
