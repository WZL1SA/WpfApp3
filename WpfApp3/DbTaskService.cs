using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WpfApp3
{
    public class DbTaskService : ITasksService
    {
        private readonly ShopWitDbContext context;

        public DbTaskService()
        {
            context = new ShopWitDbContext();
        }

        public void Add(Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public ICollection<Task> Get()
        {
            return context.Tasks.ToList();
           
        }

        public Task Get(int id)
        {
            var task = context.Tasks.Single(c => c.Id == id);

            return task;
        }

        public Task Get(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var task = Get(id);
            context.Tasks.Remove(task);
            context.SaveChanges();
        }
       

        public void Update(Task task, string taskName, string taskContent)
        {
            var selectedtask = task;

            selectedtask.TaskName = taskName;
            selectedtask.TaskContent = taskContent;                       

            context.SaveChanges();
        }

        public ICollection<Customer> GetCustomers()
        {
            return context.Customers.ToList();

        }
    }
}
