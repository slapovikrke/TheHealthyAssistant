using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHealthyAssistant.Models;
using TheHealthyAssistant.Page.OtherPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheHealthyAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportantDatesPage : ContentPage
    {
        public ImportantDatesPage()
        {
            InitializeComponent();
        }
        private async void OnAddImportantDatesPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddImportantDatesPage()).ConfigureAwait(true);
        }
        async void OnAlertImportantDatesPageButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("INFORMACJE", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "OK").ConfigureAwait(false);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView2.ItemsSource = await App.Database.GetUsersAsync().ConfigureAwait(true);
        }
        async void OnUserDeleteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
            //    if (e.SelectedItem != null)
            //    {
            //        await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
            //        {
            //            BindingContext = e.SelectedItem as User;
            //        }
            //    }
        }
        async void OnUserEditClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
            //{
            //    BindingContext = new Note();
            //}
        }

        async void OnListView2ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
                {
                    BindingContext = e.SelectedItem as Note;
                }
            }
        }
    }
}