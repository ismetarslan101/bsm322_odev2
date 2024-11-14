using Microsoft.Maui.Controls;
using System;

namespace MauiApp4.Pages
{
    public partial class Page3 : ContentPage
    {
        public Color CurrentColor { get; set; }
        private readonly Random random = new();

        public Page3()
        {
            InitializeComponent(); // XAML ile bağlandığında bu çalışır
            CurrentColor = Color.FromRgb(60, 60, 60); // Initial color
            BindingContext = this;
            renkButton.BackgroundColor = CurrentColor; // Butonun başlangıç rengini ayarla
        }

        private void kirmizi_OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            CurrentColor = Color.FromRgb((int)kirmiziSlider.Value, (int)yesilSlider.Value, (int)maviSlider.Value);
            hexKod.Text = ColorToHex(CurrentColor);
            renkButton.BackgroundColor = CurrentColor; // Buton rengini güncelle
        }

        private void yesil_OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            CurrentColor = Color.FromRgb((int)kirmiziSlider.Value, (int)yesilSlider.Value, (int)maviSlider.Value);
            hexKod.Text = ColorToHex(CurrentColor);
            renkButton.BackgroundColor = CurrentColor; // Buton rengini güncelle
        }

        private void mavi_OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            CurrentColor = Color.FromRgb((int)kirmiziSlider.Value, (int)yesilSlider.Value, (int)maviSlider.Value);
            hexKod.Text = ColorToHex(CurrentColor);
            renkButton.BackgroundColor = CurrentColor; // Buton rengini güncelle
        }

        private string ColorToHex(Color color)
        {
            int red = (int)(color.Red * 255);
            int green = (int)(color.Green * 255);
            int blue = (int)(color.Blue * 255);
            return $"#{red:X2}{green:X2}{blue:X2}";
        }

        public void HexKoduBul(object sender, EventArgs e)
        {
            // Hex kodunu bir Color'a dönüştür
            if (Color.TryParse(hexKod.Text, out Color color))
            {
                CurrentColor = color; // Color'ı CurrentColor'a ata
                renkButton.BackgroundColor = CurrentColor; // Buton rengini güncelle
            }
            else
            {
                // Eğer geçersiz bir hex kodu girildiyse uyarı ver
                DisplayAlert("Uyarı", "Geçersiz HEX kodu!", "Tamam");
            }
        }

        public async void RenkKopyala(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hexKod.Text))
            {
                await Clipboard.SetTextAsync(hexKod.Text);
                await DisplayAlert("Başarılı", "Hex kodu panoya kopyalandı.", "Tamam");
            }
            else
            {
                await DisplayAlert("Uyarı", "Kopyalanacak bir hex kodu yok.", "Tamam");
            }
        }

        public void RandomRenk(object sender, EventArgs e)
        {
            // Random renk oluştur ve renkleri güncelle
            kirmiziSlider.Value = random.Next(0, 256);
            yesilSlider.Value = random.Next(0, 256);
            maviSlider.Value = random.Next(0, 256);

            // CurrentColor'u güncelle ve buton rengini değiştir
            CurrentColor = Color.FromRgb((int)kirmiziSlider.Value, (int)yesilSlider.Value, (int)maviSlider.Value);
            hexKod.Text = ColorToHex(CurrentColor);
            renkButton.BackgroundColor = CurrentColor; // Buton rengini güncelle
        }
    }
}

