using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    class BussinessCaseTwo
    {
        public static class Address
        {
            public static Int32  m_blockNo;
            public static Int32  m_code;
            public static String m_address;
        }
        static void Main()
        {
            Console.WriteLine("Address database");
            Console.WriteLine("Enter Block : ");
            UInt32 block = UInt32.Parse(Console.Read().ToString());
            Console.WriteLine("Enter Code : ");
            String code = Console.Read().ToString();
            String[] codearray = code.Split(' ');
            //if (code[1] != null)
            //{
            //    Address.m_code = Int32.Parse(code[1].ToString());
            //}

            ;//Address.m_code += String." ";

        }
    }
}
