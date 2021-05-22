using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieFight.Model;
using MovieFight.ViewModel;

namespace MovieFight
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MovieFightModel model = new MovieFightModel();
            MovieFightViewModel viewmodel = new MovieFightViewModel(model);
            MainPage = new MainPage();
            MainPage.BindingContext = viewmodel;
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
