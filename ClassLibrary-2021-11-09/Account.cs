using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_2021_11_09
{
    public class Account
    {
        public double balance { get; set; }
        public int pinCode { get; set; }
        public int accountNr { get; set; }
        public double credit { get; set; }
        public bool swishConnection { get; set; }
        public int swishLimit { get; set; }
        public DateTime latestSwishWithdraw { get; set; }
        public double weeklySwishUsage { get; set; }
        public int warnings { get; set; }


        public Account(double balance, int pinCode, int accountNr, double credit, bool swishConnection, int swishLimit )
        {
            this.balance = balance;
            this.pinCode = pinCode;
            this.accountNr = accountNr;
            this.credit = credit;
            this.swishConnection = swishConnection;
            this.swishLimit = swishLimit;
        }
    }
}
