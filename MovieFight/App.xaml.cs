using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieFight.Model;
using MovieFight.ViewModel;
using MovieFight.Data;
using System.IO;

namespace MovieFight
{
    public partial class App : Application
    {
        static MovieDB database;

        public static MovieDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new MovieDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "movies.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MovieFightModel model = new MovieFightModel();
            MovieFightViewModel viewmodel = new MovieFightViewModel(model);
            //var fightview = new MainPage();
            //fightview.BindingContext = viewmodel;
            //MainPage = new MainPage();
            //MainPage.BindingContext = viewmodel;
            MainPage = new AppShell();
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
