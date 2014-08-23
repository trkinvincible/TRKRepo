using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    class BussinessUseCase3
    {
        class Encryption
        {
            public String Encrypt(String s)
            {
                UInt32 i = 0, charactercode = 0;
                char[] Input = s.ToCharArray();
                foreach (var ch in s)
                {
                    charactercode = Convert.ToUInt32(ch) + 1;
                    Input[i] = (char)charactercode;
                    i++;
                }
                Array.Reverse(Input);
                s = new String(Input);
                return s;
            }
        }
        static void Main()
        {
            Encryption Obj = new Encryption();
            String input = Console.ReadLine();
            Console.WriteLine(Obj.Encrypt(input));
            Console.ReadKey();
        }
    }
}
