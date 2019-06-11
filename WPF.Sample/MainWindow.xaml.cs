using System.Windows;
using WPF.Sample.ViewModelLayer;
using System.Windows.Threading;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Library;

namespace WPF.Sample
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel _viewModel = null;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (MainWindowViewModel)this.Resources["viewModel"];

            //Initialize the Message Broker Events
            MessageBroker.Instance.MessageReceived += Instance_MessageReceived;
        }
        #region Message Broker
        private void Instance_MessageReceived(object sender, MessageBrokerEventArgs e)
        {
            switch (e.MessageName)
            {
                case MessageBrokerMessages.CLOSE_USER_CONTROL:
                    CloseUserControl();
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = (MenuItem)sender;
            string cmd = string.Empty;

            if (mnu.Tag != null)
            {
                cmd = mnu.Tag.ToString();
                if (cmd.Contains("."))
                {
                    LoadUserControl(cmd);
                }
                else
                {
                    ProcessMenuCommands(cmd);
                }
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadApplication();
            _viewModel.ClearInfoMessages();
        }
        public async Task LoadApplication()
        {
            _viewModel.InfoMessage = "Loading State Codes...";
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                _viewModel.LoadStateCodes();
            }), DispatcherPriority.Background);

            _viewModel.InfoMessage = "Load Country Codes...";
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                _viewModel.LoadCountryCodes();
            }), DispatcherPriority.Background);

            _viewModel.InfoMessage = "Loading employee Types...";
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                _viewModel.LoadEmployeeTypes();
            }), DispatcherPriority.Background);
        }
        public void DisplayUserControl(UserControl uc)
        {
            contentArea.Children.Add(uc);
        }
        public void CloseUserControl()
        {
            contentArea.Children.Clear();
        }
        private void LoadUserControl(string controlName)
        {
            Type ucType = null;
            UserControl uc = null;
            if (ShouldLoadUserControl(controlName))
            {

                ucType = Type.GetType(controlName);
                if (ucType == null)
                {
                    MessageBox.Show("The Control: " + controlName + " does not exist.");
                }
                else
                {
                    CloseUserControl();
                }

                uc = (UserControl)Activator.CreateInstance(ucType);
                if (uc != null)
                {
                    DisplayUserControl(uc);
                }

            }

        }
        private void ProcessMenuCommands(string command)
        {
            switch (command.ToLower())
            {
                case "exit":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private bool ShouldLoadUserControl(string controlName)
        {
            bool ret = true;
            if (contentArea.Children.Count > 0)
            {
                if (((UserControl)contentArea.Children[0]).GetType().FullName == controlName)
                {
                    return false;
                }
            }

            return ret;
        }
    }
}
