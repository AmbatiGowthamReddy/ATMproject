namespace ATMDataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class ATMDataModel : DbContext,IDisposable
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ATMDataAccess.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public ATMDataModel()
            : base("name=ATMConnectionString")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual AccountType AccountTypes { get; set; }
    }

    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
    }

    public class Card
    {

        public int CustomerId { get; set; }
        [Key]
        public int CardNumber { get; set; }
        public int CardPin { get; set; }
        public string CardStatus { get; set; }
    }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }

    public enum AccountType {

        Savings=1,
        Loan=2
    }
}