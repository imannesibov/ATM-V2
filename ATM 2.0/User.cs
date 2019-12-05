using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM_2._0
{
    class User
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public Card CreditCard { get; set; }

        public string[] MoneyOperations = new string[100];
        public int OperationCount = -1;

        public void DisplayOperations()
        {
            if (OperationCount < 0)
            {
                throw new NoOperationFoundException();
            }
            else
            {

                for (int i = 1; i <= OperationCount + 1; i++)
                {
                    if (MoneyOperations[0] == "R") Console.ForegroundColor = ConsoleColor.DarkCyan;
                    if (MoneyOperations[0] == "I") Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (MoneyOperations[0] == "W") Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (MoneyOperations[0] == "T") Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Operation " + i + "\n");
                    Console.WriteLine(MoneyOperations[i - 1]);
                }
            }
            //Console.Read();/////EXXXCEPPPTIIIOONNNSSSSSS HEERRREE !!! 
        }

        public override string ToString()
        {
            return $"Name : {Name}\nSurname : {Surname}\nPAN : {CreditCard.PAN}\nPIN : {CreditCard.PIN}\nCVC : {CreditCard.CVC}\nExpire Date : {CreditCard.ExpireDate.ToString("dd.MM.yyyy")}\nBalance : ${CreditCard.Balance} ";
        }

        public void DisplayUser()
        {
            Console.WriteLine(Name.ToString());
            Console.WriteLine(Surname.ToString());

        }

    }


}
