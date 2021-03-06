﻿using ATMDataAccess;
using ATMDataAccess.Repositories;
using ATMProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class Customer
    {
        CustomerInfo c;
        ICustomerRepository _customerRepository;
        ICardRepository _cardRepository;

        public Customer()
        {
            _cardRepository = new CardRepository();
            _customerRepository = new CustomerRepository();
        }
        public CustomerInfo GetCustomerDetails(int cardNumber)
        {
            try
            {
                var cardData = _cardRepository.ReadCardInfo(cardNumber);
                if (cardData != null)
                {
                    c = new CustomerInfo();
                    c.CustomerId = cardData.CustomerId;
                    var custData = _customerRepository.ReadCustomerInfo(c.CustomerId);
                    if (custData != null)
                    {
                        c.CustomerName = custData.CustomerName;
                        c.CustomerAddress = custData.CustomerAddress;
                    }
                }
                return c;
            }
            catch (Exception E)
            {
                throw E;
            }

        }
    }
}
