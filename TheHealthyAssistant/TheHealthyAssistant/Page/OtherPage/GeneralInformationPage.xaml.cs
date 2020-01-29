using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TheHealthyAssistant.Models;
using System.IO;

namespace TheHealthyAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralInformationPage : ContentPage
    {
        public GeneralInformationPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetUsersAsync().ConfigureAwait(true);
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
            await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
            {
                BindingContext = new User();
            }
        }
    
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
                {
                    BindingContext = e.SelectedItem as User;
                }
            }
        }
    }
}