using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuickReaderQR
{
    public class ScanHistoryItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime ScanDateTime { get; set; }
    }

}
