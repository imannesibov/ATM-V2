using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM_2._0
{


    class Program
    {
        public static void ProgressBar()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (i == 0) Console.ForegroundColor = ConsoleColor.Red;
                if (i == 1) Console.ForegroundColor = ConsoleColor.Blue;
                if (i == 2) Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\tprocessing.");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\tprocessing..");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\tprocessing...");
                Thread.Sleep(500);
                Console.Clear();
            }
        }


        static void Main(string[] args)
        {
            #region All Users
            User[] users = new User[5]
            {
                /* User 1 */
              new User
              {Name = "Tammy", Surname = "Woods" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4532518225923473",
                     PIN = "9206",
                     CVC = "111",
                     ExpireDate = DateTime.Now.AddYears(3),
                     Balance = 9
                 }
              },

                      /* User 2 */
              new User
              {Name = "Kelly", Surname = "Bowman" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4350013977216317",
                     PIN = "4849",
                     CVC = "222",
                     ExpireDate = DateTime.Now.AddYears(5),
                     Balance = 1000
                 }
              },
                      

                    /* User 3 */ 
              new User
              {Name = "Alan", Surname = "Wallace" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4485440734429263",
                     PIN = "5392",
                     CVC = "333",
                     ExpireDate = DateTime.Now.AddYears(2),
                     Balance = 1000
                 }
              },
               
                         /* User 4 */ 
              new User
              {Name = "Deborah", Surname = "Duncan" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4929836831378309",
                     PIN = "3972",
                     CVC = "444",
                     ExpireDate = DateTime.Now.AddYears(7),
                     Balance = 1000
                 }
              },
                            /* User 5 */  
              new User
              {Name = "Stephanie", Surname = "Keller" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4716458409370860",
                     PIN = "5728",
                     CVC = "555",
                     ExpireDate = DateTime.Now.AddYears(5),
                     Balance = 10
                 }
              },
            };
            #endregion

            string pin = null;
            string pan = null;
            int Money_Amount = 0;




            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
              
                Console.Clear();
                Console.WriteLine("Enter PAN : ");
                pan = Console.ReadLine();

                Console.WriteLine("Enter PIN : ");
                pin = Console.ReadLine();



                uint numb = 10;
                ProgressBar();

                try
                {
                    numb = Manager.UserNumb(users, pan, pin);
                }
                catch (NoUserFoundException ex)
                {

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                    continue;
                }


                int MenuNumber = 0;

                if (numb >= 0)
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.ResetColor();
                        //   MENU 
                        Console.Clear();
                        Console.WriteLine("\tMenu");
                        Console.WriteLine("1.Balance");
                        Console.WriteLine("2.Withdraw money");
                        Console.WriteLine("3.List of operations");
                        Console.WriteLine("4.Transfer money");
                        Console.WriteLine("5.Get Full Information");
                        Console.WriteLine("6.Increase Balance");
                        Console.WriteLine("7.Back to main menu");

                        try
                        {
                            MenuNumber = int.Parse(Console.ReadLine());
                        }
                        catch (OverflowException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                            Console.ResetColor();

                        }
                        catch (FormatException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                            Console.ResetColor();

                        }

                        switch (MenuNumber)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Manager.DisplayBalance(users, numb);
                                    Console.ReadLine();
                                    break;
                                }
                            case 2:
                                {

                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("1.$10");
                                        Console.BackgroundColor = ConsoleColor.Green;
                                        Console.WriteLine("2.$20");
                                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("3.$50");
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("4.$100");
                                        Console.BackgroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("5.Other");
                                        Console.ResetColor();
                                        Console.WriteLine("Choose action");

                                        try
                                        {
                                            MenuNumber = int.Parse(Console.ReadLine());
                                        }
                                        catch (FormatException ex)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;

                                            Console.WriteLine(ex.Message);
                                            Console.ReadLine();
                                            Console.ResetColor();

                                            continue;
                                        }
                                        catch (OverflowException ex)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;

                                            Console.WriteLine(ex.Message);
                                            Console.ReadLine();
                                            Console.ResetColor();

                                            continue;

                                        }
                                        break;
                                    }

                                    switch (MenuNumber)
                                    {


                                        case 1:
                                            {
                                                try
                                                {
                                                    Manager.GetCash(users, numb, 10);
                                                }
                                                catch (OutOfMoneyException ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                                    Console.WriteLine(ex.Message);
                                                    Console.ReadLine();
                                                    Console.ResetColor();
                                                    continue;

                                                }
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Withdraw operation was succesfully ");
                                                Console.ReadLine();
                                                Console.ResetColor();

                                                break;
                                            }

                                        case 2:
                                            {

                                                try
                                                {
                                                    Manager.GetCash(users, numb, 20);

                                                }
                                                catch (OutOfMoneyException ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                                    Console.WriteLine(ex.Message);
                                                    Console.ReadLine();
                                                    Console.ResetColor();
                                                    continue;

                                                }
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Withdraw operation was succesfully ");
                                                Console.ReadLine();
                                                Console.ResetColor();


                                                break;
                                            }

                                        case 3:
                                            {
                                                try
                                                {
                                                    Manager.GetCash(users, numb, 50);

                                                }
                                                catch (OutOfMoneyException ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                                    Console.WriteLine(ex.Message);
                                                    Console.ReadLine();
                                                    Console.ResetColor();

                                                    continue;
                                                }
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Withdraw operation was succesfully ");
                                                Console.ReadLine();
                                                Console.ResetColor();
                                                break;
                                            }


                                        case 4:
                                            {

                                                try
                                                {
                                                    Manager.GetCash(users, numb, 100);
                                                }
                                                catch (OutOfMoneyException ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                                    Console.WriteLine(ex.Message);
                                                    Console.ReadLine();
                                                    Console.ResetColor();

                                                    continue;
                                                }
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Withdraw operation was succesfully ");
                                                Console.ReadLine();
                                                Console.ResetColor();

                                                break;
                                            }

                                        case 5:
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Amount : ");
                                                    Money_Amount = int.Parse(Console.ReadLine());
                                                }
                                                catch (OverflowException ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                                    Console.WriteLine(ex.Message);
                                                    Console.ReadLine();
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                                catch (FormatException ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                                    Console.WriteLine(ex.Message);
                                                    Console.ReadLine();
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                                try
                                                {
                                                    Manager.GetCash(users, numb, Money_Amount);
                                                }
                                                catch (OutOfMoneyException ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;

                                                    Console.WriteLine(ex.Message);
                                                    Console.ReadLine();
                                                    Console.ResetColor();
                                                    continue;

                                                }
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Withdraw operation was succesfully ");
                                                Console.ReadLine();
                                                Console.ResetColor();


                                                break;
                                            }


                                        default:
                                            break;

                                    }
                                    break;
                                }


                            case 3: // DisplayOperations
                                {
                                    Console.Clear();
                                    try
                                    {
                                        users[numb].DisplayOperations();
                                    }
                                    catch (NoOperationFoundException ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;

                                        Console.WriteLine(ex.Message);
                                        Console.ResetColor();

                                    }

                                    Console.ReadLine();
                                    break;
                                }

                            case 4: //Money Transfering
                                {
                                    Console.Clear();
                                    string receiverPAN = null;
                                    string receivePIN = null;
                                    uint receiverNUMB = 0;
                                    Console.ResetColor();
                                    Console.WriteLine("Enter PAN : ");
                                    receiverPAN = Console.ReadLine();

                                    Console.WriteLine("Enter PIN : ");
                                    receivePIN = Console.ReadLine();

                                    try
                                    {
                                        Console.WriteLine("Enter Amount : ");
                                        Money_Amount = int.Parse(Console.ReadLine());

                                    }
                                    catch (OverflowException ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;

                                        Console.WriteLine(ex.Message);
                                        Console.ReadLine();

                                        Console.ResetColor();

                                        continue;

                                    }
                                    catch (FormatException ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;

                                        Console.WriteLine(ex.Message);
                                        Console.ReadLine();
                                        Console.ResetColor();
                                        continue;

                                    }
                                    try
                                    {
                                        receiverNUMB = Manager.UserNumb(users, receiverPAN, receivePIN);
                                        Manager.TransferTo(users, numb, receiverNUMB, Money_Amount);
                                    }
                                    catch (NoUserFoundException ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;

                                        Console.WriteLine(ex.Message);
                                        Console.ReadLine();

                                        Console.ResetColor();
                                        continue;

                                    }

                                    catch (OutOfMoneyException ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;

                                        Console.WriteLine(ex.Message);
                                        Console.ReadLine();
                                        Console.ResetColor();
                                        continue;
                                    }
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Money Transfering operation was successfully");
                                    Console.ReadLine();
                                    Console.ResetColor();

                                    break;
                                }
                            case 5://Get Full Information
                                {
                                    Console.Clear();
                                    Console.WriteLine(users[numb].ToString());
                                    Console.ReadLine();
                                    break;
                                }
                            case 6: // Increase Balance
                                {
                                    Console.Clear();
                                    Console.WriteLine("amount : ");
                                    int.TryParse(Console.ReadLine(), out Money_Amount);
                                    try
                                    {
                                        Manager.IncreaseBalance(users, numb, Money_Amount);
                                    }
                                    catch (OutOfCardBalanceLimitException ex)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;

                                        Console.WriteLine(ex.Message);
                                        Console.ReadLine();
                                        Console.ResetColor();

                                    }
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Balance increased successfully");
                                    Console.ReadLine();
                                    Console.ResetColor();
                                    break;
                                }


                        }
                        if (MenuNumber == 7) break;
                    }
                    Console.Clear();
                }
                else
                {
                    try
                    {
                        throw new InvalidDetailException();
                    }
                    catch (InvalidDetailException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                        Console.ResetColor();

                    }
                    Console.ResetColor();
                }


                Console.Clear();
                Console.ResetColor();

            }


        }
    }
}
