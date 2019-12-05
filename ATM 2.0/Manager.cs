using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM_2._0
{
    class Manager
    {
        public static uint UserNumb(User[] user, string pan, string pin)
        {
            for (uint i = 0; i < user.Length; i++)
            {
                if (user[i].CreditCard.PAN == pan && user[i].CreditCard.PIN == pin)
                {
                    return i;
                }
            }
            throw new NoUserFoundException();
        }

        public static void GetCash(User[] user, uint index, int amount)
        {

            if (amount > user[index].CreditCard.Balance)
            {
                throw new OutOfMoneyException();
            }
            else
            {
                DateTime Now = DateTime.Now;

                user[index].CreditCard.Balance -= amount;
                user[index].MoneyOperations[++user[index].OperationCount] = $"Withdraw operation(s)\n\nAmount : ${amount.ToString()}\nDate : {Now}\n=========================================\n";
            }

        }

        public static void TransferTo(User[] user, uint indexOfsender, uint indexOfreceiver, int amount)
        {


            if (indexOfreceiver < 0 || indexOfsender == indexOfreceiver)
            {
                throw new NoUserFoundException();
            }

            if (user[indexOfsender].CreditCard.Balance < amount)
            {
                throw new OutOfMoneyException();
            }
            else
            {
                DateTime TransferDate = DateTime.Now;

                user[indexOfsender].CreditCard.Balance -= amount;
                user[indexOfreceiver].CreditCard.Balance += amount; 
                user[indexOfreceiver].MoneyOperations[++user[indexOfreceiver].OperationCount] = $"\"Received money\" operation\n\nSender's name : {user[indexOfsender].Name}\nSender's surname : {user[indexOfsender].Surname}\nAmount : ${amount}\nDate : {TransferDate}\n=========================================\n";
                user[indexOfsender].MoneyOperations[++user[indexOfsender].OperationCount] = $"Transfer operation(s)\n\nReceiver's name : {user[indexOfreceiver].Name}\nReceiver's surname : {user[indexOfreceiver].Surname}\nTranfer amount : ${amount}\nDate : {TransferDate}\n=========================================\n";
                 
            }
        }

        public static void IncreaseBalance(User[] user, uint index, int amount)
        {
            if (amount <= 30000 && amount+user[index].CreditCard.Balance <= 30000)
            {
                DateTime IncreasingBalanceDate = DateTime.Now;

                user[index].CreditCard.Balance += amount;
                user[index].MoneyOperations[++user[index].OperationCount] = $"Increasing Balance Operation(s)\n\nIncreasement Date : {IncreasingBalanceDate}\nAmount : ${amount}\n=========================================\n";
            }
            else
            {
            throw new OutOfCardBalanceLimitException();
            }
        }
        public static void DisplayBalance(User[] user, uint index)
        {
            Console.WriteLine($"BALANCE : ${user[index].CreditCard.Balance}");
        }

    }
}




