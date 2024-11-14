using MauiApp4.Pages;
using Microsoft.Maui.Controls;

namespace MauiApp4.Pages
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent(); // XAML ile bağlandığında bu çalışır
            BindingContext = new YourViewModel();
        }

        string Boy = "";
        string Kilo = "";

        double boy;
        double kilo;

        double vki;


        private void boy_OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Slider değeri değiştikçe Entry'yi güncelliyoruz
            boyEntry.Text = e.NewValue.ToString("F0");
        }

        private void kilo_OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Slider değeri değiştikçe Entry'yi güncelliyoruz
            kiloEntry.Text = e.NewValue.ToString("F0");
        }

        private async void buttonClick(object sender, EventArgs e)
        {
            Boy = boyEntry.Text;
            Kilo = kiloEntry.Text;

            try
            {
                // Girişlerin sayıya dönüştürülmesi
                boy = double.Parse(Boy);
                kilo = double.Parse(Kilo);

                // Vücut Kitle Endeksi Hesaplaması
                vki = kilo / Math.Pow(boy / 100, 2);
                VKI.Text = Math.Round(vki, 2).ToString();

                VkiSonuc(vki);
            }
            catch
            {
                // Kullanıcı hatalı giriş yaparsa uyarı gösterme
                await DisplayAlert("Uyarı", "Lütfen yalnızca geçerli sayısal değerler giriniz ve boş bırakmayınız!", "Tamam");
            }
        }

        private void VkiSonuc(double vki)
        {
            // Vücut Kitle Endeksi'ne göre mesaj ve renkleri güncelleme
            if (vki < 18.5)
            {
                vkiKisaMesaj.Text = "Zayıf";
                vkiKisaMesaj.TextColor = Colors.Blue;
                vkiKisaMesaj.FontAttributes = FontAttributes.Bold;
                vkiUzunMesaj.Text = "Boyunuza göre kilonuz düşük. Dengeli beslenme ve düzenli egzersizle ideal kiloya ulaşmanız sağlığınız için faydalı olabilir.";
            }
            else if (vki < 25)
            {
                vkiKisaMesaj.Text = "Sağlıklı";
                vkiKisaMesaj.TextColor = Colors.Green;
                vkiKisaMesaj.FontAttributes = FontAttributes.Bold;
                vkiUzunMesaj.Text = "Boyunuza göre kilonuz ideal seviyede. Mevcut kilonuzu korumak için dengeli beslenmeye ve aktif kalmaya devam edin.";
            }
            else if (vki < 30)
            {
                vkiKisaMesaj.Text = "Şişman";
                vkiKisaMesaj.TextColor = Colors.DarkGoldenrod; // Koyu sarı tonu
                vkiKisaMesaj.FontAttributes = FontAttributes.Bold;
                vkiUzunMesaj.Text = "Boyunuza göre kilonuz normalin biraz üzerinde. Sağlıklı bir diyet ve düzenli fiziksel aktivite ile kilonuzu yönetmek uzun vadede fayda sağlayabilir.";
            }
            else if (vki < 40)
            {
                vkiKisaMesaj.Text = "Obez";
                vkiKisaMesaj.TextColor = Colors.Orange;
                vkiKisaMesaj.FontAttributes = FontAttributes.Bold;
                vkiUzunMesaj.Text = "Boyunuza göre kilonuz idealin oldukça üzerinde. Uzman bir diyetisyen ve doktorla görüşüp beslenme ve egzersiz alışkanlıklarınızı gözden geçirmeniz faydalı olabilir.";
            }
            else
            {
                vkiKisaMesaj.Text = "Ağır Yaşamlar";
                vkiKisaMesaj.TextColor = Colors.DarkRed;
                vkiKisaMesaj.FontAttributes = FontAttributes.Bold;

                // Dinamik olarak uzun mesajı ayarlıyoruz
                vkiUzunMesaj.FormattedText = new FormattedString
                {
                    Spans =
        {
            new Span { Text = "Boyunuza göre kilonuz ciddi bir seviyede yüksek. TLC başvuru/iletişim için " },
            new Span
            {
                Text = "tıklayınız.",
                TextColor = Colors.Blue,
                FontAttributes = FontAttributes.Italic,
                GestureRecognizers =
                {
                    new TapGestureRecognizer
                    {
                        Command = new Command(async () =>
                        {
                            var url = "https://www.tlctv.com.tr/iletisim";
                            await Launcher.Default.OpenAsync(url);
                        })
                    }
                }
            }
        }
                };
            }
        }
    }
}
