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
            public static Int32 m_startRange;
            public static Int32 m_endRange;

            public FindRandom()
            {
                m_startRange = 1;
                m_endRange = 1;
            }
            public static Int32 GetRandomNumber(Int32 start,Int32 End)
            {
                Random Range = new Random();
                Int32 randG = Range.Next((int)start, (int)End);
                return randG;            
            }
        }
        static void Main()
        {
            Int32 inputN = Convert.ToInt32(Console.ReadLine());
            Random Range = new Random();
            Int32 randG = Range.Next((int)FindRandom.m_startRange, (int)inputN);
            Int32 tempRand = randG * randG;
            if (tempRand == inputN)
            {
                Console.WriteLine("Square root of {0} is {1}", inputN, randG);
            }
            else if (tempRand > inputN)
            {
                FindRandom.m_endRange = randG;
                randG = Range.Next((int)FindRandom.m_startRange, (int)FindRandom.m_endRange);
            }
        }
    }
}
