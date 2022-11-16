using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

    public interface ICustomerRepo :IGenericRepo<Customer>
    {
        public Customer GetCustomerByUserId(string Id);
    }

