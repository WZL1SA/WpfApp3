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

        public TaskViewModel(ITasksService _TasksService)
        {
            this._TasksService = _TasksService;

            //_Customer = new Customer("Witek");                     
            Load();

        }

        public TaskViewModel()
           // : this(new MocCustomersServices()) // gdy kożystamy z Moc używamy metod Moc
           : this(new DbCustomerService()) // gdy kożystamy z bazy danych kożystamy z metod klasy DbProductService
        {
           
        }


        private void Load()
        {
            Tasks = new ObservableCollection<Task>(_TasksService.Get());  //implementacja klasy informującej listę o konieczności zmiany
           //sdffsdfsdfsd
            this.TextValueName = "abc";
            
        }

        private string _TextValueName;

        public string TextValueName
        {
            get
            {                
                return _TextValueName;
            }
            set
            {
                _TextValueName = value;
                OnPropertyChanged();
            }
        }

        private string _TextValueAddress;

        public string TextValueAddress
        {
            get
            {
                return _TextValueAddress;
            }
            set
            {
                _TextValueAddress = value;
                OnPropertyChanged();
            }
        }

        private string _TextValueEmail;

        public string TextValueEmail
        {
            get
            {
                return _TextValueEmail;
            }
            set
            {
                _TextValueEmail = value;
                OnPropertyChanged();
            }
        }

        private string _TextValuePassword;

        public string TextValuePassword
        {
            get
            {
                return _TextValuePassword;
            }
            set
            {
                _TextValuePassword = value;
                OnPropertyChanged();
            }
        }




        public ICommand AddCustomerCommand
        {
            get
            {
                return new RelayCommand(c => AddCustomer(), c => CanAddCustomer());
            }
        }

        //public ICommand AddCustomerCommand => new RelayCommand(c => AddCustomer(), c => CanAddCustomer);

        // public ICommand StartCommand => new RelayCommand(() => Start(), () => CanStart);



        private bool CanAddCustomer()
        {
            return true;
        }

        private void AddCustomer()
        {
            //this.TextValueName = "zmiana";
            //this.TextValueName = this.Selectedtask.Name;
            var task = new Task();
            _TasksService.Add(task);
            this.Tasks.Add(task);           
        }


        public ICommand UpdateCustomerCommand
        {
            get
            {
                return new RelayCommand(u => UpdateCustomer());
            }
        }

        private void UpdateCustomer()
        {
            
            _TasksService.Update(SelectedCustomer, TextValueName, TextValueAddress, TextValueEmail, TextValuePassword);
          
            
        }

        public ICommand DeleteCustomerCommand
        {
            get
            {
                return new RelayCommand(u => DeleteCustomer());
            }
        }

        private void DeleteCustomer()
        {

            _TasksService.Remove(SelectedCustomer.Id);
            this.Customers.Remove(SelectedCustomer);

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



        private Customer _Customer;

        public Customer Customer
        {
            get { return _Customer; }
            set
            {
                _Customer = value;
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
       

        private bool _IsSelectedCustomer;

        public bool IsSelectedCustomer
        {
            get { return _IsSelectedCustomer; }
            set
            {
                _IsSelectedCustomer = value;                                
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
            this.TextValueName = SelectedCustomer.Name;
            this.TextValueAddress = SelectedCustomer.Address;
            this.TextValueEmail = SelectedCustomer.Email;
            this.TextValuePassword = SelectedCustomer.Password;
        }


        private bool CanSelectRow()
        {
            if (SelectedCustomer != null)
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
