using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    class DereckWorkShop4
    {
        static String[] Amount = {"Savings","Current","OverDraft"};
        public class Customer
        {
            private String m_CustomerName;
            private String m_CustomerAddress;
            private String m_CustomerPassportNo;
            private DateTime m_DateOfBirth;
            private UInt32[] m_leapYear = { 1980, 1984, 1988, 1992, 1996, 2000, 2004, 2008, 2012, 2016 };

            public UInt32 GetAge(UInt32 year)
            {
                UInt32 noOfDays = 0;
                UInt32 CurrentYear = (UInt32)DateTime.Now.Year;
                UInt32 birthYear = (UInt32)year;
                UInt32 numberOfLeapYears = 0;
                UInt32 years;
                while (UInt32.Equals(birthYear, CurrentYear))
                {
                    if (Array.BinarySearch(m_leapYear, m_DateOfBirth.Year) > 0)
                    {
                        numberOfLeapYears++;
                    }
                    noOfDays += 365;
                    birthYear++;
                }
                years = (noOfDays + (numberOfLeapYears * 366)) - numberOfLeapYears / 365;
                return years;
            }
        }
        enum Action 
        {
            Deposit = 0,
            WithDraw = 1,
            Tarnsfer = 2,
            CalculateInterest = 3,
            CreditInterest = 4,
            Max = -1
        };
        enum AccountType
        {
            Savings = 0,
            Current = 1,
            OverDraft = 2,
            Max = -1
        };
        public class BankAccount
        {
            protected UInt16 m_accountNumber;
            protected Customer m_accountHolderName;
            protected UInt32 m_balance;
            protected Int32 m_accountType;
            public BankAccount()
            {
                m_accountType = -1;
            }
            public BankAccount(UInt32 accounttype)
            {
                m_accountType = (Int32)accounttype;
            }
            public void DoDeposit()
            {
                Console.WriteLine("Deposited in {0}",Amount[m_accountType]);
            }
            public void DoWithDraw()
            {
                Console.WriteLine("WithDrawn");
            }
            public void DoTransfer()
            {
                Console.WriteLine("Transfered");
            }
            virtual public void DoAction(Int16 action)
            {
                if (action == (Int16)Action.Deposit)
                {
                    DoDeposit();
                }
                else if (action == (Int16)Action.CalculateInterest)
                {
                    //Base class Do Nothing;
                }
            }
        }

        public class SavingsAccount : BankAccount
        {
            public SavingsAccount() : base((UInt32)AccountType.Savings)
            {

            }
            public override void DoAction(Int16 action)
            {
                if (action == (Int16)Action.Deposit)
                {
                    DoDeposit();
                }
                if (action == (Int16)Action.CalculateInterest)
                {
                    CalculateInterest();
                }
                if (action == (Int16)Action.CreditInterest)
                {
                    CreditInterest();
                }
            }
            public void CalculateInterest()
            {
                Console.WriteLine("Calculated Interest for {0} Account\n",Amount[m_accountType]);
            }
            public void CreditInterest()
            {
                Console.WriteLine("Credited Interest for Savings Account\n");
            }
        }
        public class CurrentAccount : BankAccount
        {
            public CurrentAccount(): base((UInt32)AccountType.Current)
            {

            }
            public override void DoAction(Int16 action)
            {
                if (action == (Int16)Action.Deposit)
                {
                    DoDeposit();
                }
                else if (action == (Int16)Action.CalculateInterest)
                {
                    CalculateInterest();
                }
                //if (action == (Int16)Action.CreditInterest)
                //{
                //    CreditInterest();
                //}
            }
            public void CalculateInterest()
            {
                Console.WriteLine("Calculated Interest for {0} Account\n",Amount[m_accountType]);
            }
        }
        public class OverDraftAccount : BankAccount
        {
            public OverDraftAccount(): base((UInt32)AccountType.OverDraft)
            {

            }
            public override void DoAction(Int16 action)
            {
                if (action == (Int16)Action.Deposit)
                {
                    DoDeposit();
                }
                if (action == (Int16)Action.CalculateInterest)
                {
                    CalculateInterest();
                }
                //if (action == (Int16)Action.CreditInterest)
                //{
                //    CreditInterest();
                //}
            }
            public void CalculateInterest()
            {
                Console.WriteLine("Calculated Interest for {0} Account",Amount[m_accountType]);
            }
        }
        
        static void Main()
        {
            Customer customerObj = new Customer();
            SavingsAccount savingsAccount = new SavingsAccount();
            CurrentAccount currentAccount = new CurrentAccount();
            OverDraftAccount OverdraftAccount = new OverDraftAccount();
            Console.Write("Deposit 1000 dollars in Savings Account\n");
            System.Collections.ArrayList accountTypes = new System.Collections.ArrayList();
            accountTypes.Add(savingsAccount);
            accountTypes.Add(currentAccount);
            accountTypes.Add(OverdraftAccount);
            foreach(Object typ in accountTypes)
            {
                BankAccount baseObject = (BankAccount)typ;
                baseObject.DoAction((Int16)Action.Deposit);
                baseObject.DoAction((Int16)Action.CalculateInterest);
                //baseObject.DoAction((Int16)Action.CreditInterest);
            }
            
            Console.ReadKey();
            
        }
    }
}
