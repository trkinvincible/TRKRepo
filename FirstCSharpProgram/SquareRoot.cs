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
            public static Int32 m_startRange = 1;
            public static Int32 m_endRange = 1;

            public FindRandom()
            {
                m_startRange = 1;
                m_endRange = 1;
            }
            public static Int32 GetRandomNumber(Int32 start,Int32 End)
            {
                Int32 randG = m_range.Next((int)start, (int)End);
                return randG;               
            }
        }
        static void Main()
        {
            Int32 randG;
            Int32 tempRand;
            UInt16 iterations = 0;
            Console.WriteLine("Enter the Number to find Square root");
            Int32 inputN = Convert.ToInt32(Console.ReadLine());
            FindRandom.m_endRange = inputN;
            while (true)
            {
                iterations++;
                randG = FindRandom.GetRandomNumber((int)FindRandom.m_startRange, (int)FindRandom.m_endRange);
                tempRand = randG * randG;
                if (tempRand == inputN)
                {
                    Console.WriteLine("Square root of {0} is {1}", inputN, randG);
                    Console.WriteLine("Number of Iterations {0}", iterations);
                    break;
                }
                else if (tempRand > inputN)
                {
                    FindRandom.m_endRange = randG;
                }
                else
                {
                    FindRandom.m_startRange = randG;
                }
            }
            Console.ReadKey();
        }
    }
}
