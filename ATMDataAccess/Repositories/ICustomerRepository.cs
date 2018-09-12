using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDataAccess.Repositories
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer Cus);
        Customer ReadCustomerInfo(int Id);
        void UpdateCustomerData(Customer Cus);
    }
}
