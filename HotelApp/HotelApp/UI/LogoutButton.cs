using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace HotelApp.UI
{
    public class LogoutButton : UIButton
    {
        public LogoutButton()
        {
            Command = new RelayCommand(LogoutCommand);
            ButtonName = "Wyloguj";
        }

        private void LogoutCommand()
        {
            UserMessage msg = new UserMessage { NewUser = null };
            Messenger.Default.Send(msg);
        }
    }
}
