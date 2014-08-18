using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    class BussinessCaseOne
    {
        public Char[] m_billAmountArrayRealPart;
        public Char[] m_billAmountArrayImgPart;
        public String toDisplay;
        public System.Collections.Hashtable m_unitDigits;
        public System.Collections.Hashtable m_tensDigits;
        public System.Collections.Hashtable m_spltensDigits;
        public String[] m_place= { "Thousand ", "Hundred " };

        public BussinessCaseOne()
        {
            m_unitDigits = new System.Collections.Hashtable();
            m_unitDigits.Add(1, "One ");
            m_unitDigits.Add(2, "Two ");
            m_unitDigits.Add(3, "Three ");
            m_unitDigits.Add(4, "Four ");
            m_unitDigits.Add(5, "Five ");
            m_unitDigits.Add(6, "Six ");
            m_unitDigits.Add(7, "Seven ");
            m_unitDigits.Add(8, "Eight ");
            m_unitDigits.Add(9, "Nine ");

            m_tensDigits = new System.Collections.Hashtable();
            m_tensDigits.Add(1, " ");
            m_tensDigits.Add(2, "Twenty ");
            m_tensDigits.Add(3, "Thirty ");
            m_tensDigits.Add(4, "Fourty ");
            m_tensDigits.Add(5, "Fifty ");
            m_tensDigits.Add(6, "Sixty ");
            m_tensDigits.Add(7, "Seventy ");
            m_tensDigits.Add(8, "Eighty ");
            m_tensDigits.Add(9, "Niney ");

            m_spltensDigits = new System.Collections.Hashtable();
            m_spltensDigits.Add(1, "Eleven");
            m_spltensDigits.Add(2, "Twelve");
            m_spltensDigits.Add(3, "Thirteen");
            m_spltensDigits.Add(4, "Fourteen");
            m_spltensDigits.Add(5, "Fifteen");
            m_spltensDigits.Add(6, "Sixteen");
            m_spltensDigits.Add(7, "Seventeen");
            m_spltensDigits.Add(8, "Eighteen");
            m_spltensDigits.Add(9, "Nineteen");
        }

        void AppendBillAmountString(Int16 noOfCharacters)
        {
            Int16 letter = 0;
            bool passedTens = false;
            while (noOfCharacters != 0)
            {
                if( noOfCharacters < 3)
                {
                    Int32 digit = Int16.Parse((m_billAmountArrayRealPart[letter]).ToString());
                    if (digit == 1 && passedTens == false)
                    {
                        letter++;
                        digit = Int16.Parse((m_billAmountArrayRealPart[letter]).ToString());
                        toDisplay += (String)m_spltensDigits[digit];
                        break;
                    }
                    else if (digit == 0)
                    {
                        passedTens = true;
                        letter++;
                        digit = Int16.Parse((m_billAmountArrayRealPart[letter]).ToString());
                        toDisplay += (String)m_unitDigits[digit];
                        break;
                    }
                    else if (digit != 0)
                    {
                        toDisplay += (String)m_tensDigits[digit];
                        letter++;
                    }
                }
                else
                {
                    Int32 digit = Int16.Parse((m_billAmountArrayRealPart[letter]).ToString());
                    if (digit != 0)
                    {
                        toDisplay += (String)m_unitDigits[digit];
                        toDisplay += m_place[letter];
                    }
                    letter++;
                }
                noOfCharacters--;
            }
        }

        static void Main()
        {
            BussinessCaseOne Obj = new BussinessCaseOne();

            Console.Write("please enter Bill Amount:");
            String billAmount = Console.ReadLine();
            billAmount.Trim();
            Int32 lengthOfString = billAmount.Length;
            Int16 i = 0;
            bool beginImgPart = false;
            Int16 noOfCharacters = 0;
            Obj.m_billAmountArrayRealPart = new Char[lengthOfString];
            Obj.m_billAmountArrayImgPart  = new Char[lengthOfString];

            while(lengthOfString > i )
            {
                if (billAmount[i] == '.')
                {
                    beginImgPart = true;
                    if(beginImgPart == true)
                    {
                        i++;
                        Obj.m_billAmountArrayImgPart[i] = billAmount[i];
                        noOfCharacters++;
                    }
                    continue;
                }
                Obj.m_billAmountArrayRealPart[i] = billAmount[i];
                noOfCharacters++;
                i++;
            }
            Obj.AppendBillAmountString(noOfCharacters);
            Console.WriteLine("{0}", Obj.toDisplay);
            Console.ReadKey(true);
        }
    }


}
