using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    class SquareRoot
    {
        public class FindRandom
        {
            public static Random m_range = new Random();
            public static Double m_startRange = 1;
            public static Double m_endRange = 1;
            public static Double m_Input;

            public FindRandom()
            {
                m_startRange = 1;
                m_endRange = 1;
            }
            public static Int32 GetRandomNumber(Int32 start, Int32 End)
            {
                Int32 G = m_range.Next((int)start, (int)End);
                return G;               
            }
            public static Double GetRandomNumber(Double G)
            {
                Double rand = (G + (FindRandom.m_Input / G)) / 2;
                return rand;
            }
        }
        static void Main()
        {
            Double randG = 1.0;
            Double tempRand;
            UInt16 iterations = 0;
            Console.WriteLine("Enter the Number to find Square root");
            Double inputN = Convert.ToInt32(Console.ReadLine());
            FindRandom.m_Input = inputN;
            FindRandom.m_endRange = inputN;
            while (true)
            {
                iterations++;
                //randG = FindRandom.GetRandomNumber((int)FindRandom.m_startRange, (int)FindRandom.m_endRange);
                randG = FindRandom.GetRandomNumber(randG);
                tempRand = randG * randG;
                Console.WriteLine("approx obtained {0} ", tempRand);
                if (tempRand.Equals(inputN))
                {
                    Console.WriteLine("Square root of {0} is {1}", inputN, randG);
                    Console.WriteLine("Number of Iterations {0}", iterations);
                    break;
                }
                //else if (tempRand > inputN)
                //{
                //    FindRandom.m_endRange = randG;
                //}
                //else
                //{
                //    FindRandom.m_startRange = randG;
                //}
            }
            Console.ReadKey();
        }
    }
}
