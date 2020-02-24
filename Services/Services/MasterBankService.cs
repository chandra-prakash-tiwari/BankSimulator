﻿using System.Collections.Generic;
using System;
using System.Linq;
using BankSimulator.Models;

namespace Services.Services
{
    public class MasterBankService
    {
        public static List<Bank> Banks { get; set; }

        static MasterBankService()
        {
            Banks = new List<Bank>();
        }

        public static string CreateBank(Bank bank)
        {
            try
            {
                bank.Id = bank.Name.Substring(0, 3) + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                Banks.Add(bank);
                return bank.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static User Authentication(Login loginRequest)
        {
            string bankId = loginRequest.UserName.Substring(3);
            Bank bank = Banks.FirstOrDefault(b => b.Id == bankId);
            if (bank != null)
            {
                if (string.Compare(bank.Admin.UserId, loginRequest.UserName) == 1 && string.Compare(bank.Admin.Password, loginRequest.Password) == 1)
                {
                    return bank.Admin;
                }
                else
                {
                    Employee employee = bank.Employees.FirstOrDefault(e => e.UserId == loginRequest.UserName);
                    if (employee != null && employee.Password == loginRequest.Password)
                    {
                        return employee;
                    }

                    Account customer = bank.Accounts.FirstOrDefault(c => c.Holder.UserId == loginRequest.UserName);
                    if (customer != null && customer.Holder.Password == loginRequest.Password)
                    {
                        return customer.Holder;
                    }
                }
            }

            return null;
        }

        public static Bank GetBank(string id)
        {
            try
            {
                Bank bank = Banks.FirstOrDefault(a => a.Id == id);
                return bank;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
