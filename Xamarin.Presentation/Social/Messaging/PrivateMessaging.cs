using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Presentation.Social.Messaging {
    public enum PrivateMessageTypes {
        Incoming,
        Outgoing
    }

    public interface IPrivateMessagingViewState {
        
    }
    public class PrivateMessageViewState {
        public PrivateMessageTypes Type { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
    }

    public interface IPrivateMessagingPresenter<TViewState> where TViewState : IAccountShortInfoViewState {

    }

    class PrivateMessaging
    {
        public PrivateMessaging() {
            
        }
    }
}
