using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APIwithXamarin2.Services;
using APIwithXamarin2.Views;

namespace APIwithXamarin2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
