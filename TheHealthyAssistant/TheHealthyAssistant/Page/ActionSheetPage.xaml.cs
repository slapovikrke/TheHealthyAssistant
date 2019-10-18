using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheHealthyAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionSheetPage : ContentPage
    {
        public ActionSheetPage()
        {
            InitializeComponent();
        }
         void OnOKButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
    
