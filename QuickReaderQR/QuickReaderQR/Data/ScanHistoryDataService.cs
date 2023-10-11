using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuickReaderQR
{
    class ScanHistoryDataService
    {
        private SQLiteConnection _database;

        public ScanHistoryDataService()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "scanhistory.db");
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<ScanHistoryItem>();
        }

        public void SaveToHistory(string scannedText)
        {
            var existingItem = _database.Table<ScanHistoryItem>().FirstOrDefault(item => item.Text == scannedText);
            if (existingItem != null)
            {
                // If the item already exists, update its ScanDateTime
                existingItem.ScanDateTime = DateTime.Now;
                _database.Update(existingItem);
            }
            else
            {
                // If the item does not exist, create a new entry
                var historyItem = new ScanHistoryItem
                {
                    Text = scannedText,
                    ScanDateTime = DateTime.Now
                };
                _database.Insert(historyItem);
            }
        }

        public void ClearScanHistory()
        {
            _database.DeleteAll<ScanHistoryItem>();
        }

        public List<ScanHistoryItem> GetScanHistory()
        {
            return _database.Table<ScanHistoryItem>().OrderByDescending(item => item.ScanDateTime).ToList();
        }
    }
}
