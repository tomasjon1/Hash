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
            char[] hexChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            UInt64 sum = 0;

            char prev = input[0];

            foreach (char c in input)
            {
                UInt64 Cint64 = Convert.ToUInt32(c);
                Cint64 = BitOperations.RotateLeft(Cint64, 98464629 * Convert.ToInt32(c));

                sum += Cint64 - BitOperations.RotateRight((UInt64)prev, 4056840 * Convert.ToInt32(c));
                sum = BitOperations.RotateLeft(sum, 5788480 * Convert.ToInt32(prev));
            }

            char[] sumInChars = sum.ToString().ToCharArray();


            for (int i = 0; i < 64; i++)
            {
                int hexCharIndex;

                if (sumInChars.Length > i)
                    hexCharIndex = sumInChars[i] + i * 98464629;
                else hexCharIndex = sumInChars[i % sumInChars.Length] + i * 4056840;

                if (hexCharIndex >= hexChars.Length)
                    hexCharIndex = hexCharIndex % hexChars.Length;

                hash += hexChars[hexCharIndex];
            }

            return hash;
        }
    }
}
