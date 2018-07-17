using Xamarin.Forms;

namespace Xamarin.Presentation.Social.Messaging {
    public class MessageDataTemplateSelector : DataTemplateSelector {

        public DataTemplate OutgoingMessageTemplate { get; set; }
        public DataTemplate IncomingMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            var mess = (PrivateMessageViewState)item;
            switch (mess.Type) {
                case PrivateMessageTypes.Incoming:
                    return IncomingMessageTemplate;
                case PrivateMessageTypes.Outgoing:
                    return OutgoingMessageTemplate;
            }
            return null;
        }
    }
}
