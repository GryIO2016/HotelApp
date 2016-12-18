using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace HotelApp.UI
{
    public class NavigationButton : UIButton
    {
        public int ViewNumber { get; set; }

        public NavigationButton()
        {
            Command = new RelayCommand(NavigateCommand);
        }

        private void NavigateCommand()
        {
            NavigateMessage msg = new NavigateMessage() { ViewNumber = ViewNumber };
            Messenger.Default.Send(msg);
        }
    }
}
