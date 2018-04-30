using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;


namespace WpfApp3
{
    public class TaskViewModel : BaseViewModel
    {
        private readonly ITasksService _TasksService;

        //private readonly ICustomersService _CustomersService;

        public TaskViewModel(ITasksService _TasksService)
        {
            this._TasksService = _TasksService;

            //_Customer = new Customer("Witek");                     
            Load();

        }

        public TaskViewModel()
           // : this(new MocCustomersServices()) // gdy kożystamy z Moc używamy metod Moc
           : this(new DbTaskService()) // gdy kożystamy z bazy danych kożystamy z metod klasy DbTaskService          
        {
           
        }


        private void Load()
        {
            Tasks = new ObservableCollection<Task>(_TasksService.Get());  //implementacja klasy informującej listę o konieczności zmiany

            Customers = new ObservableCollection<Customer>(_TasksService.GetCustomers());  //implementacja klasy informującej listę o konieczności zmiany      

            this.TextValueTaskName = "abc";
            
        }

        private string _TextValueTaskName;
      
        public string TextValueTaskName
        {
            get
            {                
                return _TextValueTaskName;
            }
            set
            {
                _TextValueTaskName = value;
                OnPropertyChanged();
            }
        }

        private string _TextValueTaskContent;

        public string TextValueTaskContent
        {
            get
            {
                return _TextValueTaskContent;
            }
            set
            {
                _TextValueTaskContent = value;
                OnPropertyChanged();
            }
        }



        public ICommand AddTaskCommand
        {
            get
            {
                return new RelayCommand(t => AddTask(), t => CanAddTask());
            }
        }

        
        private bool CanAddTask()
        {
            return true;
        }

        private void AddTask()
        {
            
            var task = new Task(this.TextValueTaskName, this.TextValueTaskContent);
            _TasksService.Add(task);
            this.Tasks.Add(task);           
        }


        public ICommand UpdateTaskCommand
        {
            get
            {
                return new RelayCommand(t => UpdateTask());
            }
        }

        private void UpdateTask()
        {
            
            _TasksService.Update(SelectedTask, TextValueTaskName, TextValueTaskContent);
          
            
        }

        public ICommand DeleteTaskCommand
        {
            get
            {
                return new RelayCommand(t => DeleteTask());
            }
        }

        private void DeleteTask()
        {

            _TasksService.Remove(SelectedTask.Id);
            this.Tasks.Remove(SelectedTask);

        }

        private ICollection<Task> _Tasks;

        public ICollection<Task> Tasks
        {
            get { return _Tasks; }
            set
            {
                _Tasks = value;
                OnPropertyChanged();
            }
        }





        private ICollection<Customer> _Customers;

        public ICollection<Customer> Customers
        {
            get { return _Customers; }
            set
            {
                _Customers = value;
                OnPropertyChanged();
            }
        }

        private Task _SelectedTask;

        public Task SelectedTask
        {
            get { return _SelectedTask; }
            set
            {
                _SelectedTask = value;                
                OnPropertyChanged();
            }
        }

        private Customer _SelectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set
            {
                _SelectedCustomer = value;
                OnPropertyChanged();
            }
        }



        private bool _IsSelectedTask;

        public bool IsSelectedTask
        {
            get { return _IsSelectedTask; }
            set
            {
                _IsSelectedTask = value;                                
                OnPropertyChanged();                
            }
        }

        private bool _ButtonEnabled;

        public bool ButtonEnabled
        {
            get
            {
                //if(this.IsSelectedCustomer == false)
                //{
                //    _ButtonEnabled = false;
                //}
                //else
                //{
                //    _ButtonEnabled = true;
                //}
                
                return _ButtonEnabled;
            }
            set
            {                
                 _ButtonEnabled = value;
                OnPropertyChanged();
            }
        }


        // private bool IsSelectedCustomer => SelectedCustomer != null;

        private ICommand _SelectCommand;
        public ICommand SelectCommand
        {
            get
            {
                if (_SelectCommand == null)
                {
                    _SelectCommand = new RelayCommand(p => Select());
                }

                return _SelectCommand;
            }
        }


        private void Select()
        {
            this.ButtonEnabled = true;
          
        }

        private ICommand _SelectRowCommand;

        public ICommand SelectRowCommand
        {
            get
            {
                if (_SelectRowCommand == null)
                {
                    _SelectRowCommand = new RelayCommand(p => SelectRow(), p => CanSelectRow());
                }

                return _SelectRowCommand;
            }
        }

        private void SelectRow()
        {
            this.TextValueTaskName = SelectedTask.TaskName;
            this.TextValueTaskContent = SelectedTask.TaskContent;            
        }


        private bool CanSelectRow()
        {
            if (SelectedTask != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        


    }
 }
