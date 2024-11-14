using Microsoft.Maui.Controls;

namespace MauiApp4.Pages
{
    public partial class Page1 : ContentPage
    {
        private readonly double BSMV = 0.10;
        private readonly double KKDV = 0.15;

        public Page1()
        {
            InitializeComponent();
            BindingContext = new YourViewModel();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            vadeEntry.Text = e.NewValue.ToString("F0");
            buttonClick(sender,e);
        }

        private async void buttonClick(object sender, EventArgs e)
        {
            if (!double.TryParse(oranEntry.Text, out double oran) ||
                !double.TryParse(tutarEntry.Text, out double tutar) ||
                !double.TryParse(vadeEntry.Text, out double vade))
            {
                await DisplayAlert("Uyarı", "Yalnızca sayısal değerler girilmeli ve hiçbir değer boş bırakılmamalı!", "Tamam");
                return;
            }

            SetCreditResults(CreditType.Ihtiyac, oran, tutar, vade);
            SetCreditResults(CreditType.Konut, oran, tutar, vade);
            SetCreditResults(CreditType.Tasit, oran, tutar, vade);
            SetCreditResults(CreditType.Ticari, oran, tutar, vade);
        }

        private void SetCreditResults(CreditType creditType, double oran, double tutar, double vade)
        {
            (double brutFaiz, double taksit, double toplam) = CalculateCredit(creditType, oran, tutar, vade);
            double odenenFaiz = toplam - tutar;  // Calculate paid interest

            switch (creditType)
            {
                case CreditType.Ihtiyac:
                    ihtiyacBrutFaiz.Text = brutFaiz.ToString("F2");
                    ihtiyacTaksit.Text = taksit.ToString("F2");
                    ihtiyacToplam.Text = toplam.ToString("F2");
                    ihtiyacOdenenFaiz.Text = odenenFaiz.ToString("F2");  // Display paid interest
                    break;
                case CreditType.Konut:
                    konutBrutFaiz.Text = brutFaiz.ToString("F2");
                    konutTaksit.Text = taksit.ToString("F2");
                    konutToplam.Text = toplam.ToString("F2");
                    konutOdenenFaiz.Text = odenenFaiz.ToString("F2");  // Display paid interest
                    break;
                case CreditType.Tasit:
                    tasitBrutFaiz.Text = brutFaiz.ToString("F2");
                    tasitTaksit.Text = taksit.ToString("F2");
                    tasitToplam.Text = toplam.ToString("F2");
                    tasitOdenenFaiz.Text = odenenFaiz.ToString("F2");  // Display paid interest
                    break;
                case CreditType.Ticari:
                    ticariBrutFaiz.Text = brutFaiz.ToString("F2");
                    ticariTaksit.Text = taksit.ToString("F2");
                    ticariToplam.Text = toplam.ToString("F2");
                    ticariOdenenFaiz.Text = odenenFaiz.ToString("F2");  // Display paid interest
                    break;
            }
        }


        private (double brutFaiz, double taksit, double toplam) CalculateCredit(CreditType creditType, double oran, double tutar, double vade)
        {
            double brutFaiz = 0;

            switch (creditType)
            {
                case CreditType.Ihtiyac:
                    brutFaiz = ((oran + (oran * BSMV) + (oran * KKDV)) / 100);
                    break;
                case CreditType.Konut:
                    brutFaiz = (oran / 100);
                    break;
                case CreditType.Tasit:
                    brutFaiz = ((oran + (oran * (BSMV / 2)) + (oran * KKDV)) / 100);
                    break;
                case CreditType.Ticari:
                    brutFaiz = (oran / 100);
                    break;
            }

            double taksit = ((Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1)) * tutar;
            double toplam = taksit * vade;

            return (brutFaiz, taksit, toplam);
        }

        private enum CreditType
        {
            Ihtiyac,
            Konut,
            Tasit,
            Ticari
        }
    }
}
