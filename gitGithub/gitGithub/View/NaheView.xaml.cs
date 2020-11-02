using gitGithub.srevice;
using gitGithub.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gitGithub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NaheView : ContentPage
    {
        public NaheView()
        {
            InitializeComponent();
            BindingContext = new NameVM();
            Task.Run(InitDB);
        }
        async Task InitDB()
        {
            MainThread.BeginInvokeOnMainThread(() => IsBusy = true);
            Datebase.InitDb();
            MainThread.BeginInvokeOnMainThread(() => IsBusy = false);
        }
    }
   
}