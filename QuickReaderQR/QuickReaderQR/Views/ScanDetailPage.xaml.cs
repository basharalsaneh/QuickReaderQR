using QuickReaderQR.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuickReaderQR
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScanDetailPage : ContentPage
	{
        public ScanDetailPage(ScanHistoryItem historyItem)
        {
            InitializeComponent();
            BindingContext = historyItem;
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