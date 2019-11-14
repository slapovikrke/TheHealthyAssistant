using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TheHealthyAssistant.Models
{
    public class MeetingsModel
    {
        public int id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
