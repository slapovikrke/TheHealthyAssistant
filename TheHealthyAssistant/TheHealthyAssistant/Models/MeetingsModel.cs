using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Plugin.Calendar.Models;

namespace TheHealthyAssistant.Models
{
    public class MeetingsModel
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
