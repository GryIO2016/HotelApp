using System.Windows.Input;

namespace HotelApp.UI
{
    public abstract class UIButton
    {
        public ICommand Command { get; protected set; }
        public string ButtonName { get; set; }
    }
}
