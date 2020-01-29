using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheHealthyAssistant.Page.OtherPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddImportantDatesPage : ContentPage
    {
        public AddImportantDatesPage()
        {
            InitializeComponent();
        }
        private async void OnAddImportantDateButtonClicked(object sender, EventArgs e)
        {

        }
        async void OnAlertAddImportantDatesPageButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("INFORMACJE", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "OK").ConfigureAwait(false);
        }
    }
}