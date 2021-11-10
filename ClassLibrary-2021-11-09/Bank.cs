using System;
using System.Collections.Generic;

namespace ClassLibrary_2021_11_09
{
    public static class Bank
    {
        public static List<Account> Accounts = new List<Account>
        {
            new Account(-200, 1, 1, 1000, true, 3000),
            new Account(200, 2, 2, 100, false, 0),
            new Account(300, 3, 3, 1000,  true, 3000)
        };
        public static bool Withdraw(double money, int accountNr, int pinCode, bool useSwish)
        {
            try
            {
                if (money < 0)
                {
                    return false;
                } 
                var acc = Accounts.Find(x => x.AccountNr == accountNr);
                if (acc.PinCode == pinCode)
                {
                    if (!useSwish)
                    {
                        if (money <= acc.Balance + acc.Credit)
                        {
                            var newBalance = acc.Balance -= money;
                            if (newBalance < 0)
                            {
                                var newCredit = acc.Balance + acc.Credit;
                                if (newCredit < 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    acc.Balance = 0;
                                    acc.Credit = newCredit;
                                    return true;
                                }
                            }
                                acc.Balance = newBalance;
                                return true;
                        }
                    }
                    else
                    {
                        if (acc.SwishConnection)
                        {
                            if (money <= acc.Balance + acc.Credit)
                            {
                                if (acc.WeeklySwishUsage>0)
                                {
                                    var dateCheck = DateTime.Now.AddDays(+7);
                                    if (acc.LatestSwishWithdraw < dateCheck)
                                    {
                                        acc.WeeklySwishUsage = 0;
                                    }
                                }
                                if (money + acc.WeeklySwishUsage < acc.SwishLimit )
                                {
                                    var newBalance = acc.Balance -= money;
                                    var newWeeklySwishUsage = acc.WeeklySwishUsage += money;
                                    if (newBalance < 0)
                                    {
                                        var newCredit = acc.Balance + acc.Credit;
                                        if (newCredit < 0)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            acc.Balance = 0;
                                            acc.Credit = newCredit;
                                            acc.WeeklySwishUsage = newWeeklySwishUsage;
                                            acc.LatestSwishWithdraw = DateTime.Now;
                                            return true;
                                        }
                                    }
                                    acc.Balance = newBalance;
                                    acc.WeeklySwishUsage = newWeeklySwishUsage;
                                    acc.LatestSwishWithdraw = DateTime.Now;
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;    
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static bool Deposit(double money, int accountNr, int pinCode)
        {
            var acc = Accounts.Find(x => x.AccountNr == accountNr);
            if (acc.PinCode == pinCode)
            {
                if(money > 100.000)
                {
                    return false;
                }
                if (money > 15000)
                {
                    if (acc.Warnings > 1)
                    {
                        return false;
                    }
                    else
                    {
                        acc.Warnings++;
                        acc.Balance += money;
                        return true;
                    }
                }
            }
                return false;
        }
    }
}
