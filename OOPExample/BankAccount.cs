using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExample
{
    internal class BankAccount
    {
        public string Number { get; }
        public string Owner { get; }
       public decimal Balance { get; set; }

        public BankAccount(string name, decimal initialBalance)
        {
                
            Owner = name;
            Balance = initialBalance;

        }
    }
}
