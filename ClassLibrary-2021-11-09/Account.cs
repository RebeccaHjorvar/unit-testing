using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_2021_11_09
{
    public class Account
    {
        public double Balance { get; set; }
        public int PinCode { get; set; }
        public int AccountNr { get; set; }
        public double Credit { get; set; }
        public bool SwishConnection { get; set; }
        public int SwishLimit { get; set; }
        public DateTime LatestSwishWithdraw { get; set; }
        public double WeeklySwishUsage { get; set; }
        public int Warnings { get; set; }


        public Account(double balance, int pinCode, int accountNr, double credit, bool swishConnection, int swishLimit )
        {
            Balance = balance;
            PinCode = pinCode;
            AccountNr = accountNr;
            Credit = credit;
            SwishConnection = swishConnection;
            SwishLimit = swishLimit;
        }
    }
}
