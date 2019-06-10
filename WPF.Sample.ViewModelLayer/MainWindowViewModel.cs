using Common.Library;
using System.Threading;

namespace WPF.Sample.ViewModelLayer
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Variables
        private const int SECONDS = 1500;
        #endregion

        #region Properties

        private string _LoginMenuHeader = "Login";
        public string LoginMenuHeader
        {
            get { return _LoginMenuHeader; }
            set
            {
                _LoginMenuHeader = value;
                RaisePropertyChanged("LoginMenuHeader");
            }
        }

        private string _StatusMessage;
        public string StatusMessage
        {
            get { return _StatusMessage; }
            set
            {
                _StatusMessage = value;
                RaisePropertyChanged("StatusMessage");
            }
        }

        private bool _isInfoMessageVisible = true;
        public bool IsInfoMessageVisible
        {
            get { return _isInfoMessageVisible; }
            set
            {
                _isInfoMessageVisible = value;
                RaisePropertyChanged(nameof(IsInfoMessageVisible));
            }
        }

        private string _infoMessageTitle;
        public string InfoMessageTitle
        {
            get { return _infoMessageTitle; }
            set
            {
                _infoMessageTitle = value;
                RaisePropertyChanged(nameof(InfoMessageTitle));
            }
        }

        private string _infoMessage;
        public string InfoMessage
        {
            get { return _infoMessage; }
            set
            {
                _infoMessage = value;
                RaisePropertyChanged(nameof(InfoMessage));
            }
        }
        #endregion

        #region Methods
        public void LoadStateCodes()
        {
            //TO DO ::
            Thread.Sleep(SECONDS);
        }
        public void LoadCountryCodes()
        {
            //TO DO ::
            Thread.Sleep(SECONDS);
        }
        public void LoadEmployeeTypes()
        {
            //TO DO ::
            Thread.Sleep(SECONDS);
        }
        public void ClearInfoMessages()
        {
            InfoMessage = string.Empty;
            InfoMessageTitle = string.Empty;
            IsInfoMessageVisible = false;
        }
        #endregion

    }
}
