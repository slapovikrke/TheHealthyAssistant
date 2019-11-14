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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            listView.ItemsSource = notes
                .OrderBy(d => d.Date)
                .ToList();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
            {
                BindingContext = new Note();
            }
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
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
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    listView.ItemsSource = await App.Database.GetUsersAsync().ConfigureAwait(true);
        //}
        //async void OnUserAddedClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
        //    {
        //        BindingContext = new User();
        //    }
        //}

        //async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem != null)
        //    {
        //        await Navigation.PushAsync(new ActionSheetPage()).ConfigureAwait(true);
        //        {
        //            BindingContext = e.SelectedItem as User;
        //        }
        //    }
        //}

        //async void OnOKButtonClicked(object sender, EventArgs e)
        //{

        //}

        //void OnDiabetesBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        //{
        //    if (e.Value)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        //void OnHypertensionBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        //{
        //    if (e.Value)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}
