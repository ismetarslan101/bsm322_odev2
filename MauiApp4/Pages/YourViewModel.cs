using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiApp4.Pages
{
    public class YourViewModel : INotifyPropertyChanged
    {
        public ICommand OpenLinkCommand { get; }

        public YourViewModel()
        {
            OpenLinkCommand = new Command(async () => await Launcher.Default.OpenAsync("https://www.tlc.com/iletisim"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
