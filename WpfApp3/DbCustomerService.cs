using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WpfApp3
{
    public class DbCustomerService : ICustomersService
    {
        private readonly ShopWitDbContext context;

        public DbCustomerService()
        {
            context = new ShopWitDbContext();
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public ICollection<Customer> Get()
        {
            return context.Customers.ToList();
           
        }

        public Customer Get(int id)
        {
            var customer = context.Customers.Single(c => c.Id == id);

            return customer;
        }

        public Customer Get(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var customer = Get(id);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
       

        public void Update(Customer customer, string name, string address, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
