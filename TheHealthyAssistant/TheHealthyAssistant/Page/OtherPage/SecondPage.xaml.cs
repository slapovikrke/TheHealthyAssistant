using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheHealthyAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }
        private async void OnImportantDatesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImportantDatesPage()).ConfigureAwait(true);
        }
        private async void OnMedicinesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MedicinesPage()).ConfigureAwait(true);
        }
        private async void OnMeetingsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeetingsPage()).ConfigureAwait(true);
        }
        private async void OnGeneralInformationButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GeneralInformationPage()).ConfigureAwait(true);
        }
        private async void OnWatchButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WatchPage()).ConfigureAwait(true);
        }
    }
}