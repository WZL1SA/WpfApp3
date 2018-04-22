using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp3
{
    public interface ICustomersService
    {
        
            void Add(Customer customer);

            void Update(Customer customer, string name, string address, string email, string password);

            void Remove(int id);

            ICollection<Customer> Get();

            Customer Get(int id);

            Customer Get(string name);
        
    }
}
