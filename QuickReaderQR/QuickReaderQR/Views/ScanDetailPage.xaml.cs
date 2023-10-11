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
	public partial class ScanDetailPage : ContentPage
	{
        public ScanDetailPage(ScanHistoryItem historyItem)
        {
            InitializeComponent();
            BindingContext = historyItem;
        }
    }
}