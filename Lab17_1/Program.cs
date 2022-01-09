using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_1
{


    public interface IAccountType
    {
        string TypeName { get; }
    }

    public class BrokerAccount : IAccountType
    {
        public string TypeName { get => "Брокерский"; }
    }

    public class PersonalAccount : IAccountType
    {
        public string TypeName { get => "Расчётный"; }
    }

    public class CcyAccount : IAccountType
    {
        public string TypeName { get => "Валютный"; }
    }

         
    public class Account<T> where T : class, IAccountType, new()
    {

        public Account(string accountNumber, string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            AccountNumber = accountNumber;
        }
                
        T AccountType = new T();
                
        private string AccountNumber;
        private decimal Balance;
                
        private string FirstName;
        private string LastName;
        private string MiddleName;
                
        public void UpdateBalance(decimal Value) => Balance = Value;
        public decimal GetBalance() => Balance;

        public string ShowInfo() => $"{AccountType.TypeName} - {FirstName} {MiddleName} {LastName} Баланс: {Balance}";

    }

    class Program
    {
                                     
        static void Main(string[] args)
        {
            Account<BrokerAccount> bc = new Account<BrokerAccount>("401234", "Аргем", "Мухаматов", "Тагирович");
            Account<PersonalAccount> pc = new Account<PersonalAccount>("401234", "Аргем", "Мухаматов", "Тагирович");
            Account<CcyAccount> cc = new Account<CcyAccount>("401234", "Аргем", "Мухаматов", "Тагирович");

            bc.UpdateBalance(2000.10m);
            pc.UpdateBalance(3434.43m);
            cc.UpdateBalance(0.10m);

            Console.WriteLine(bc.ShowInfo());
            Console.WriteLine(pc.ShowInfo());
            Console.WriteLine(cc.ShowInfo());
            Console.ReadLine();
        }
    }
}
