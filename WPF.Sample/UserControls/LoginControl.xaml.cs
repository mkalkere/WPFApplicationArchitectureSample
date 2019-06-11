﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Sample.ViewModelLayer;

namespace WPF.Sample.UserControls
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        private LoginViewModel _viewModel = null;
        public LoginControl()
        {
            InitializeComponent();
            _viewModel = (LoginViewModel)this.Resources["viewModel"];
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Close();
        }
    }
}
