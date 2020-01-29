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
        async void OnInfSecondPageButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("INFORMACJE", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "OK").ConfigureAwait(false);
        }
    }
}