using System;
using System.Collections.Generic;

namespace ClassLibrary_2021_11_09
{
    public class Bank
    {
        public List<Account> Accounts = new List<Account>
        {
            new Account(-200, 1, 1, 1000, true, 3000),
            new Account(200, 2, 2, 100, false, 0),
            new Account(300, 3, 3, 1000,  true, 3000)
        };
        public bool Withdraw(double money, int accountNr, int pinCode, bool useSwish)
        {
            try
            {
                if (money < 0)
                {
                    return false;
                } 
                var acc = Accounts.Find(x => x.accountNr == accountNr);
                if (acc.pinCode == pinCode)
                {
                    if (!useSwish)
                    {
                        if (money <= acc.balance + acc.credit)
                        {
                            var newBalance = acc.balance -= money;
                            if (newBalance < 0)
                            {
                                var newCredit = acc.balance + acc.credit;
                                if (newCredit < 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    acc.balance = 0;
                                    acc.credit = newCredit;
                                    return true;
                                }
                            }
                                acc.balance = newBalance;
                                return true;
                        }
                    }
                    else
                    {
                        if (acc.swishConnection)
                        {
                            if (money <= acc.balance + acc.credit)
                            {
                                if (acc.weeklySwishUsage>0)
                                {
                                    var dateCheck = DateTime.Now.AddDays(+7);
                                    if (acc.latestSwishWithdraw < dateCheck)
                                    {
                                        acc.weeklySwishUsage = 0;
                                    }
                                }
                                if (money + acc.weeklySwishUsage < acc.swishLimit )
                                {
                                    var newBalance = acc.balance -= money;
                                    var newWeeklySwishUsage = acc.weeklySwishUsage += money;
                                    if (newBalance < 0)
                                    {
                                        var newCredit = acc.balance + acc.credit;
                                        if (newCredit < 0)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            acc.balance = 0;
                                            acc.credit = newCredit;
                                            acc.weeklySwishUsage = newWeeklySwishUsage;
                                            acc.latestSwishWithdraw = DateTime.Now;
                                            return true;
                                        }
                                    }
                                    acc.balance = newBalance;
                                    acc.weeklySwishUsage = newWeeklySwishUsage;
                                    acc.latestSwishWithdraw = DateTime.Now;
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
        public bool Deposit(double money, int accountNr, int pinCode)
        {
            var acc = Accounts.Find(x => x.accountNr == accountNr);
            if (acc.pinCode == pinCode)
            {
                if(money > 100.000)
                {
                    return false;
                }
                if (money > 15000)
                {
                    if (acc.warnings > 1)
                    {
                        return false;
                    }
                    else
                    {
                        acc.warnings++;
                        acc.balance += money;
                        return true;
                    }
                }
            }
                return false;
        }
    }
}
