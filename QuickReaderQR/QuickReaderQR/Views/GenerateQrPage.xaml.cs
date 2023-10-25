using Android.Graphics;
using Java.Nio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QuickReaderQR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerateQrPage : ContentPage
    {
        public GenerateQrPage()
        {
            InitializeComponent();
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedType = qrTypePicker.SelectedItem.ToString();

            // Visa och dölj relevanta inmatningsfält baserat på valt alternativ
            wifiNameEntry.IsVisible = selectedType == "WiFi Network";
            wifiPasswordEntry.IsVisible = selectedType == "WiFi Network";

            vcardNameEntry.IsVisible = selectedType == "VCard";
            vcardPhoneEntry.IsVisible = selectedType == "VCard";
            vcardEmailEntry.IsVisible = selectedType == "VCard";
            vcardTitleEntry.IsVisible = selectedType == "VCard";

            urlEntry.IsVisible = selectedType == "URL";
            UpdateBarcodeImageView();
        }

        private void OnGenerateClicked(object sender, EventArgs e)
        {
            UpdateBarcodeImageView();
        }

        private void UpdateBarcodeImageView()
        {
            string barcodeValue = string.Empty;
            ZXing.BarcodeFormat barcodeFormat = ZXing.BarcodeFormat.QR_CODE;

            switch (qrTypePicker.SelectedItem.ToString())
            {
                case "URL":
                    barcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                    barcodeValue = urlEntry.Text;
                    break;
                case "WiFi Network":
                    barcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                    string wifiName = wifiNameEntry.Text;
                    string wifiPassword = wifiPasswordEntry.Text;
                    barcodeValue = $"WIFI: {wifiName}\nPassword: {wifiPassword}";
                    break;
                case "VCard":
                    barcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                    string vcardName = vcardNameEntry.Text;
                    string vcardPhone = vcardPhoneEntry.Text;
                    string vcardEmail = vcardEmailEntry.Text;
                    string vcardTitle = vcardTitleEntry.Text;
                    barcodeValue = $"BEGIN:VCARD\nVERSION:3.0\nFN: {vcardName}\nTEL: {vcardPhone}\nEMAIL: {vcardEmail}\nTITLE: {vcardTitle}\nEND:VCARD";
                    break;
            }

            // Uppdatera ZXingBarcodeImageView med de nya värdena
            zxingBarcodeImageView.BarcodeFormat = barcodeFormat;
            zxingBarcodeImageView.BarcodeValue = barcodeValue;

        }

        private async void ShowHistoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());

        }
    }
}