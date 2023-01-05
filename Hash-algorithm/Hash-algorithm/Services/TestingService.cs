using Hash_algorithm.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public void OutputLenghtTest()
        {
            Console.WriteLine("Starting lenght test");

            for (int i = 1; i < 1000; i++)
            {
                string output = _hashingService.Hash(_helperService.RandomStringGenerator(i));

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
            Console.WriteLine("Starting equality test");

            int matches = 0;

            for (int i = 1; i <= 1000; i++)
            {
                string s = _helperService.RandomStringGenerator(i);
          
                if(_hashingService.Hash(s) == _hashingService.Hash(s))
                    matches++;
                else
                    Console.WriteLine($"The hashes of {i} ware not the same");
            }
            Console.WriteLine($"there ware {matches} matches out of 1000 cases");
        }
        public void OutputCollisionTest()
        {
            Console.WriteLine("Starting collision test");

            int collisions = 0;

            for (int i = 1; i <= 100000; i++)
            {
                if(i <= 25000)
                    if (_hashingService.Hash(_helperService.RandomStringGenerator(10)) == _hashingService.Hash(_helperService.RandomStringGenerator(10)))
                        collisions++;
                else if(i <= 50000)
                    if (_hashingService.Hash(_helperService.RandomStringGenerator(100)) == _hashingService.Hash(_helperService.RandomStringGenerator(100)))
                        collisions++;
                else if (i <= 75000)
                    if (_hashingService.Hash(_helperService.RandomStringGenerator(500)) == _hashingService.Hash(_helperService.RandomStringGenerator(500)))
                        collisions++;
                else
                    if (_hashingService.Hash(_helperService.RandomStringGenerator(1000)) == _hashingService.Hash(_helperService.RandomStringGenerator(1000)))
                        collisions++;
            }

            if (collisions == 0)
                Console.WriteLine("No collisions");
            else
                Console.WriteLine($"{collisions} collisions happened");
        }
        public void OutputAvalancheTest()
        {
            Console.WriteLine("Starting avalanche test");

            List<float> percentage = new List<float>();

            float min = 100, max = 0, avg = 0;

            for (int i = 0; i < 100000; i++)
            {
                string s1;

                if (i <= 25000)
                    s1 = _helperService.RandomStringGenerator(10);
                else if (i <= 50000)
                    s1 = _helperService.RandomStringGenerator(100);
                else if (i <= 75000)
                    s1 = _helperService.RandomStringGenerator(500);
                else
                    s1 = _helperService.RandomStringGenerator(1000);

                string s2 = _helperService.RandomStringGenerator(1) + s1.Remove(0, 1);

                percentage.Add(SimilarityCalculation(_hashingService.Hash(s1), _hashingService.Hash(s2)));
            }

            foreach (float p in percentage)
            {
                if (p < min)
                    min = p;
                if (p > max)
                    max = p;

                avg += p;
            }

            Console.WriteLine("Min HEX difference: {0:F2}%", min);
            Console.WriteLine("Max HEX difference: {0:F2}%", max);
            Console.WriteLine("Avg HEX difference: {0:F2}%", avg);

            for (int i = 0; i < 100000; i++)
            {
                string s1 = _helperService.RandomStringGenerator(6);
                string s2 = _helperService.RandomStringGenerator(1) + s1.Remove(0, 1);

                BitArray bitArray1 = new BitArray(Encoding.UTF8.GetBytes(_hashingService.Hash(s1)));
                BitArray bitArray2 = new BitArray(Encoding.UTF8.GetBytes(_hashingService.Hash(s2)));

                bitArray1.Xor(bitArray2);

                float bits = 0;
                foreach (bool bit in bitArray1)
                    if (bit) bits++;

                float diff = 100 * (bits / 512);

                if (diff < min)
                    min = diff;

                if (diff > max)
                    max = diff;

                avg += diff;

            }

            Console.WriteLine("Min binary difference: {0:F2}%", min);
            Console.WriteLine("Max binary difference: {0:F2}%", max);
            Console.WriteLine("Avg binary difference: {0:F2}%", avg);
        }
        public void SpeedTest()
        {
            List<string> lines = File.ReadAllLines("konstitucija.txt").ToList();
            List<Data> results = new List<Data>();

            if (!Directory.Exists(AppContext.BaseDirectory + @"Results\"))
                Directory.CreateDirectory(AppContext.BaseDirectory + @"Results\");

            if (File.Exists(AppContext.BaseDirectory + @"Results\Results.txt"))
                File.Delete(AppContext.BaseDirectory + @"Results\Results.txt");

            for (int l = 1; l < lines.Count; l++)
            {
                double lineCount = Math.Pow(l, 2);

                if (lineCount >= lines.Count)
                {
                    lineCount = lines.Count;
                    l = lines.Count;
                }

                StringBuilder sb = new StringBuilder();

                for (int y = 1; y <= lineCount; y++)
                    sb.Append(lines[y-1]);

                Stopwatch timer = new Stopwatch();
                timer.Start();
                results.Add(new Data() { Input = sb.ToString(), Output = _hashingService.Hash(sb.ToString()), Time = timer.Elapsed });
            }

            foreach (Data r in results)
                File.AppendAllText(AppContext.BaseDirectory + @"Results\Results.txt", String.Format("Input: {0}\n Output: {1}\n Time: {2} \n \n", r.Input, r.Output, r.Time));
        }
        private float SimilarityCalculation(string s1, string s2)
        {
            if ((s1 == null) || (s2 == null)) return 0;
            if ((s1.Length == 0) || (s2.Length == 0)) return 0;
            if (s1 == s2) return 100;
            int similarity = LevenshteinDistance(s1, s2);
            return 100 - ((float)Math.Max(s1.Length, s2.Length) - (float)similarity) / (float)Math.Max(s1.Length, s2.Length) * 100;
        }
        private int LevenshteinDistance(string source1, string source2)
        {
            var source1Length = source1.Length;
            var source2Length = source2.Length;

            var matrix = new int[source1Length + 1, source2Length + 1];;

            for (var i = 0; i <= source1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= source2Length; matrix[0, j] = j++) { }

            for (var i = 1; i <= source1Length; i++)
            {
                for (var j = 1; j <= source2Length; j++)
                {
                    var cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            return matrix[source1Length, source2Length];
        }
    }
}
