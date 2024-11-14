using MauiApp4.Pages;

namespace MauiApp4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnMenuClicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Bir sayfa secin", "Iptal", null, "Kredi Hesapla", "Vücut Kitle Endeksi", "Renk Seçici", "Not Ekle", "Sayfa 5");

            if (action == "Kredi Hesapla")
                await Navigation.PushAsync(new Page1());
            else if (action == "Vücut Kitle Endeksi")
                await Navigation.PushAsync(new Page2());
            else if (action == "Renk Seçici")
                await Navigation.PushAsync(new Page3());
            else if (action == "Not Ekle")
                await Navigation.PushAsync(new Page4());
            else if (action == "Sayfa 5")
                await Navigation.PushAsync(new Page5());
        }
    }
}
