using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    class DereckWorkShop3
    {
        public class Customer
        {
            private String m_CustomerName;
            private String m_CustomerAddress;
            private String m_CustomerPassportNo;
            private DateTime m_DateOfBirth;
            private UInt32 [] m_leapYear = {1980,1984,1988,1992,1996,2000,2004,2008,2012,2016};
            //public DateTime Date 
            //{
            //    get 
            //    {
            //        return m_DateOfBirth;
            //    }
            //    set
            //    {
            //        if (value.Year > 1900 && value.Year <= DateTime.Today.Year)
            //        {
            //            m_DateOfBirth = value;
            //        }
            //    }
            //}

            public UInt32 GetAge(UInt32 year)
            {
                UInt32 noOfDays = 0;
                UInt32 CurrentYear = (UInt32)DateTime.Now.Year;
                UInt32 birthYear = (UInt32)year;
                UInt32 numberOfLeapYears = 0;
                UInt32 years;
                while (UInt32.Equals(birthYear,CurrentYear))
                {
                    if(Array.BinarySearch(m_leapYear,m_DateOfBirth.Year) > 0)
                    {
                        numberOfLeapYears++;
                    }
                    noOfDays += 365;
                    birthYear ++ ;
                }
                years = (noOfDays + (numberOfLeapYears * 366)) - numberOfLeapYears / 365;
                return years;
            }

        }
        class BankAccount
        {
            private UInt32 m_AccountNumber;
            private Customer m_CustomerInformation;
        }
        static void Main()
        {
            Console.Write("Enter Date of Birth");
            String dateOfBirth = (String)Console.ReadLine();
            String[] datesplit = dateOfBirth.Split('/');
            UInt32 year = UInt32.Parse(datesplit[2]);
            Customer customerObj = new Customer();
            Console.Write("Age : {0}", customerObj.GetAge(year));
            Console.ReadKey();
        }
    }
}
