using QuickReaderQR.Views;
using System;
using System.Text;
using Xamarin.Forms;


namespace QuickReaderQR
{
    public partial class MainPage : ContentPage
    {
        private ScanHistoryDataService _dataService;


        public MainPage()
        {
            InitializeComponent();
            _dataService = new ScanHistoryDataService();
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() => {
                if (result != null && !string.IsNullOrEmpty(result.Text))
                {
                    StringBuilder resultText = new StringBuilder();
                    resultText.AppendLine("Text: " + result.Text);
                    resultText.AppendLine("Type: " + result.BarcodeFormat.ToString());
                    ResultLabel.Text = resultText.ToString();
                    ResultFrame.IsVisible = true;

                    // Save the scanned item to the history
                    _dataService.SaveToHistory(result.Text);
                }
                else
                {
                    ResultLabel.Text = "Barcode could not be recognized. Please try again.";
                    ResultFrame.IsVisible = true;
                }
            });
        }

        private async void ShowHistoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }


        private async void GenerateQrButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GenerateQrPage());

        }



    }
}
