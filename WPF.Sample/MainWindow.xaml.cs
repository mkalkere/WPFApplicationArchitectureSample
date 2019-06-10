using System.Windows;
using WPF.Sample.ViewModelLayer;
using System.Windows.Threading;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WPF.Sample
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel _viewModel = null;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (MainWindowViewModel)this.Resources["viewModel"];
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
