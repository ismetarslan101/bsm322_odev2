using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp4.Pages
{
    public partial class Page4 : ContentPage
    {
        public ObservableCollection<NotItem> Notlar { get; set; }

        public Page4()
        {
            InitializeComponent();
            Notlar = new ObservableCollection<NotItem>();
            BindingContext = this;
        }

        // Yeni Not Ekleme
        private async void OnYeniNotEkleClicked(object sender, EventArgs e)
        {
            string yeniNot = await DisplayPromptAsync("Not Ekle", "Not:", "TAMAM", "İPTAL", placeholder: "Yeni not ekleyin");
            if (!string.IsNullOrWhiteSpace(yeniNot))
            {
                Notlar.Add(new NotItem { NotText = yeniNot, IsCompleted = false });
            }
        }

        // Not Düzenleme
        private async void OnNotDuzenleClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var not = button.CommandParameter as NotItem;
            if (not != null)
            {
                string duzenlenenNot = await DisplayPromptAsync("Not Düzenle", "Not:", "TAMAM", "ÝPTAL", initialValue: not.NotText);
                if (!string.IsNullOrWhiteSpace(duzenlenenNot))
                {
                    not.NotText = duzenlenenNot;
                }
            }
        }

        // Not Silme
        private void OnNotSilClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var not = button.CommandParameter as NotItem;
            if (not != null)
            {
                Notlar.Remove(not);
            }
        }

    }

    // Not Öðesi
    public class NotItem : INotifyPropertyChanged
    {
        private string _notText = "";
        private bool _isCompleted;

        public string NotText
        {
            get => _notText;
            set
            {
                if (_notText != value)
                {
                    _notText = value;
                    OnPropertyChanged(nameof(NotText));
                }
            }
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}