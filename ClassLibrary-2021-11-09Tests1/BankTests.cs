using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary_2021_11_09;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_2021_11_09.Tests
{
    [TestClass()]
    public class BankTests
    {
        [TestMethod]
        [DataRow(500, 1, 1)]
        public void WithdrawTest(double money, int accountNr, int pinCode, bool useSwish = false)
        {
            var bank = new Bank();
            Assert.IsTrue(bank.Withdraw(money: money, accountNr: accountNr, pinCode: pinCode, useSwish));
        }

        [TestMethod]
        [DataRow(1000, 3, 3, true)]
        public void WithdrawTest_hasSwish_shouldReturnTrue(double money, int accountNr, int pinCode, bool useSwish)
        {
            var bank = new Bank();
            Assert.IsTrue(bank.Withdraw(money: money, accountNr: accountNr, pinCode: pinCode, useSwish: useSwish));
        }

        [TestMethod]
        [DataRow(-800000, 3, 3, true)]
        public void WithdrawTest_negativeAmount_shouldReturnFalse(double money, int accountNr, int pinCode, bool useSwish)
        {
            var bank = new Bank();
            Assert.IsFalse(bank.Withdraw(money: money, accountNr: accountNr, pinCode: pinCode, useSwish: useSwish));
        }


        [TestMethod]
        [DataRow(169000, 1, 1)]
        public void DepositTest_shouldReturnTrue(double money, int accountNr, int pinCode)
        {
            var bank = new Bank();
            Assert.IsTrue(bank.Deposit(money, accountNr, pinCode));
        }

    }
}