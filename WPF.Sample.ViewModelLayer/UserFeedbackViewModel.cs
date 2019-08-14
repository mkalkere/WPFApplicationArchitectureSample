using Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Sample.ViewModelLayer
{
    public class UserFeedbackViewModel : ViewModelBase
    {
        public UserFeedbackViewModel() : base()
        {
            DisplayStatusMessage("Submit User Feedback");
        }
    }
}
