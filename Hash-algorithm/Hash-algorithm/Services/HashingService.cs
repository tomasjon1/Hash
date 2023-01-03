using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hash_algorithm.Services
{
    public class HashingService
    {
        public string Hash(string input)
        {
            string hash = "";

            UInt64 sum = 0;

            char prev = input[0];

            foreach (char c in input)
            {
                UInt64 Cint64 = Convert.ToUInt32(c);
                Cint64 = BitOperations.RotateLeft(Cint64, 98464629 * Convert.ToInt32(c));
            }

            return hash;
        }
    }
}
