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
            // Get scan history data from the database
            var dataService = new ScanHistoryDataService();
            var historyItems = dataService.GetScanHistory();

            // Bind the history data to the ListView
            HistoryListView.ItemsSource = historyItems;
        }
        private async void HistoryListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null && e.SelectedItem is ScanHistoryItem selectedHistoryItem)
            {
                // Navigate to a new page to display details of the selected history item
                await Navigation.PushAsync(new ScanDetailPage(selectedHistoryItem));

                // Deselect the selected item
                HistoryListView.SelectedItem = null;
            }
        }
        private void ClearHistoryButton_Clicked(object sender, EventArgs e)
        {
            // Clear the scan history list from the database
            var dataService = new ScanHistoryDataService();
            dataService.ClearScanHistory();

            // Reload the history list
            LoadHistory();
        }
    }
}