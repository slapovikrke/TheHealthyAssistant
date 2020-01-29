
using Xamarin.Plugin.Calendar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;

namespace TheHealthyAssistant.Page.OtherPage

{
    public class MeetingsPageViewModel : INotifyPropertyChanged
    {
        private CultureInfo _culture = CultureInfo.InvariantCulture;

        public MeetingsPageViewModel()
        {
        }

        private IEnumerable<EventModel> GenerateEvents(int count, string name)
        {
            return Enumerable.Range(1, count).Select(x => new EventModel
            {
                Name = $"{name} event{x}",
                Description = $"This is {name} event{x}'s description!"
            });
        }

        public EventCollection Events { get; }
        public int Month { get; set; } = DateTime.Now.Month;
        public int Year { get; set; } = DateTime.Now.Year;

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        public CultureInfo Culture
        {
            get => _culture;
            set => SetProperty(ref _culture, value);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<TData>(ref TData storage, TData value, [CallerMemberName] string propertyName = "")
        {
            if (storage.Equals(value))
                return;

            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
