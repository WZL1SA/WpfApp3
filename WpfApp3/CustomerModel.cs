﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp3
{
    using System;
    using System.Collections.Generic;

    public partial class CustomerModel : BaseModel
    {

        public CustomerModel(String customerName, String customerAddress, String customerEmail, String customerPassword)
        {
            Name = customerName;
            Address = customerAddress;
            Email = customerEmail;
            Password = customerPassword;
        }

        public CustomerModel()
        {

        }




        public int Id { get; set; }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        private string _Address;

        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                OnPropertyChanged();
            }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }







        //public string Name { get; set; }
        //public string Address { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
    }
}