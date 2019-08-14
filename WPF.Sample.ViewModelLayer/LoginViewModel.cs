using Common.Library;

namespace WPF.Sample.ViewModelLayer
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
	    {
            DisplayStatusMessage("Login to Application");
	    }

        public override void Close(bool wasCancelled = true)
        {

            if (wasCancelled)
            {
                //Display informational message
                MessageBroker.Instance.SendMessage(MessageBrokerMessages.DISPLAY_TIMEOUT_INFO_MESSAGE_TITLE, "User Not Logged In.");
            }

            base.Close(wasCancelled);
        }
    }
}
