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
            this.BindingContext = new Note();
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //    var user = User;
            //    User user = new User()
            //    {
            //    Date = DateTime.UtcNow;
            //    Text = text;
            //    ID = id;
            //};
            //user.Date = DateTime.UtcNow;
            //var user = (User)BindingContext;
            //user.Date = DateTime.UtcNow;
            //await App.Database.SaveUserAsync(user).ConfigureAwait(true);
            //await Navigation.PopAsync().ConfigureAwait(true);
            var note = (Note)BindingContext;

            if (note == null || string.IsNullOrEmpty(note.Filename))
            //{
                //if (string.IsNullOrWhiteSpace(note.Filename))
                {
                    // Save
                    var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                    File.WriteAllText(filename, note.Text);
                }
                else
                {
                    // Update 
                    File.WriteAllText(note.Filename, note.Text);
                }
            //}

            await Navigation.PopAsync().ConfigureAwait(true);
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            //var note = (User)BindingContext;
            //await App.Database.DeleteUserAsync(note).ConfigureAwait(true);
            //await Navigation.PopAsync().ConfigureAwait(true);
            var note = (Note)BindingContext;

            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }

            await Navigation.PopAsync().ConfigureAwait(true);
        }
    }

}
    
