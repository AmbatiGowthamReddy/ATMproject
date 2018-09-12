using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ATMDataModel dataModel;

        public CustomerRepository()
        {
            dataModel = new ATMDataModel();
        }
        public void CreateCustomer(Customer Cus)
        {
            throw new NotImplementedException();
        }

        public Customer ReadCustomerInfo(int Id)
        {
            return dataModel.Customers.SingleOrDefault(p => p.CustomerId == Id);

        }
        public void UpdateCustomerData(Customer Cus)
        {
            throw new NotImplementedException();
        }
    }
}
