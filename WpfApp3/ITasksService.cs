using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp3
{
    public interface ITasksService
    {
        
            void Add(Task customer);

            void Update(Task task, string taskName, string taskContent, int customerId);

            void Remove(int id);

            ICollection<Task> Get();

            Task Get(int id);

            Task Get(string taskName);
        
    }
}
