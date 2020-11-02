using gitGithub.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gitGithub
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NaheView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
