using Microsoft.Maui.Controls;

namespace MauiApp4.Pages
{
    public partial class Page5 : ContentPage
    {
        public Page5()
        {
            InitializeComponent();
        }

        // Giriş yap butonuna tıklama işlemi
        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            // Giriş alanlarını göster
            welcomeLabel.IsVisible = false;
            startButton.IsVisible = false;
            usernameEntry.IsVisible = true;
            passwordEntry.IsVisible = true;
            loginButton.IsVisible = true;
            // Hata mesajlarını gizle
            errorMessage.IsVisible = false;
            kullaniciFrame.IsVisible = true;
            sifreFrame.IsVisible = true;
        }

        // Anasayfaya dön butonuna tıklama işlemi
        private async void OnBackToMainPageClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        // Kullanıcı adı ve şifre kontrolü
        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string correctUsername = "admin";
            string correctPassword = "password123";

            // Kullanıcı adı ve şifre doğruysa giriş başarılı
            if (usernameEntry.Text == correctUsername && passwordEntry.Text == correctPassword)
            {
                successMessage.Text = "Giriş Başarılı!";
                successMessage.IsVisible = true;
                backToMainButton.IsVisible = true;
                errorMessage.IsVisible = false;
            }
            // Hatalıysa uyarı göster
            else
            {
                errorMessage.Text = "Kullanıcı adı veya şifre hatalı!";
                errorMessage.IsVisible = true;
                successMessage.IsVisible = false;
            }
        }
    }
}
