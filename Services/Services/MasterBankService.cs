﻿using Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Services.Services
{
    public class MasterBankService
    {
        public static List<Bank> Banks { get; set; }

        static MasterBankService()
        {
            Banks = new List<Bank>();
        }

        public static Bank CreateBank(Bank bank)
        {
            bank.Id = bank.Name.Substring(0, 3) + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
            bank.Admin.UserId = bank.Admin.Name.Substring(0, 3) + bank.Id;
            Banks.Add(bank);
            return bank;
        }

        public static Bank GetBank(string id)
        {
            Bank bank = Banks.FirstOrDefault(a => a.Id == id);
            return bank;
        }
    }
}
