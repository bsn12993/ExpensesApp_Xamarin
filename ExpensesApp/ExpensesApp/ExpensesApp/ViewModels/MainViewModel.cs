﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
    }
}
