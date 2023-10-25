using QuickReaderQR.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace QuickReaderQR
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
            LoadHistory();

        }
        private void LoadHistory()
        {
            var dataService = new ScanHistoryDataService();
            var historyItems = dataService.GetScanHistory();

            HistoryListView.ItemsSource = historyItems;
        }
        private async void HistoryListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null && e.SelectedItem is ScanHistoryItem selectedHistoryItem)
            {
                await Navigation.PushAsync(new ScanDetailPage(selectedHistoryItem));

                HistoryListView.SelectedItem = null;
            }
        }
        private void ClearHistoryButton_Clicked(object sender, EventArgs e)
        {
            var dataService = new ScanHistoryDataService();
            dataService.ClearScanHistory();

            LoadHistory();
        }

        private async void GenerateQrButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GenerateQrPage());

        }
    }
}