using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    public class Test
    {
        public Test()
        {
        }
        public Int32 m_billAmount;
        public Int32 Multiply()
        {
            return (5*m_billAmount);
        }
    }
    class BusCaseOne
    {
        static void Main(string[] args)
        {
            Test testObj = new Test {m_billAmount = 10};
            Console.WriteLine("Bill Amount is : {0}",testObj.Multiply());
            Console.ReadKey(true);
        }
    }
}
