using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class ActionSheetPage : ContentPage
    { 
        public ActionSheetPage()
        {
            this.BindingContext = new User();
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            DateTime dateTime = user.Date = DateTime.UtcNow;
            await App.Database.SaveUserAsync(user).ConfigureAwait(true);
            await Navigation.PopAsync().ConfigureAwait(true);
            await Navigation.PushAsync(new GeneralInformationPage()).ConfigureAwait(true);
        }

        async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            await App.Database.SaveUserAsync(user).ConfigureAwait(true);
            await Navigation.PopAsync().ConfigureAwait(true);
            await Navigation.PushAsync(new GeneralInformationPage()).ConfigureAwait(true);
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
           // .Remove(user);
            await App.Database.DeleteUserAsync(user).ConfigureAwait(true);
 
        }

        void OnDiabetesBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {

            }
            else
            {

            }
        }

        void OnHypertensionBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {

            }
            else
            {

            }
        }
    }
}