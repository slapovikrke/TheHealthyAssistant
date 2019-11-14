using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugin.Calendar.Models;
using System.ComponentModel;
using TheHealthyAssistant.Page.OtherPage;

namespace TheHealthyAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class MeetingsPage : ContentPage
    {
        public MeetingsPage()
        {
            InitializeComponent();
        }
        private async void OnAddMeetingsPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMeetingsPage()).ConfigureAwait(true);
        }
        async void OnAlertMeetingsPageButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("i", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "OK").ConfigureAwait(false);
        }
    }
}