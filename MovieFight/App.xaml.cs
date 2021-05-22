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
            viewmodel.ErrorOccured += new EventHandler(ErrorHandler);
        }

        private async void ErrorHandler(object sender, EventArgs e)
        {
            await MainPage.DisplayAlert("Error", "Please fill all the movie fields", "Correct");
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
