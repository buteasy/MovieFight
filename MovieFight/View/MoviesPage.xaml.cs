using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieFight.Model;

namespace MovieFight.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            girlCollectionView.ItemsSource = await App.Database.GetGirlMoviesAsync();
            boyCollectionView.ItemsSource = await App.Database.GetBoyMoviesAsync();
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.Database.SaveMovieAsync(new Movie
                {
                    Title = nameEntry.Text,
                    Date = int.Parse(ageEntry.Text),
                    Column = int.Parse(columnEntry.Text)
                });

                nameEntry.Text = ageEntry.Text = columnEntry.Text = string.Empty;
                girlCollectionView.ItemsSource = await App.Database.GetGirlMoviesAsync();
                boyCollectionView.ItemsSource = await App.Database.GetBoyMoviesAsync();
            }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                var movie = await App.Database.GetItemAsync(nameEntry.Text);
                await App.Database.DeleteItemAsync(movie);

                nameEntry.Text = ageEntry.Text = columnEntry.Text =string.Empty;
                girlCollectionView.ItemsSource = await App.Database.GetGirlMoviesAsync();
                boyCollectionView.ItemsSource = await App.Database.GetBoyMoviesAsync();
            }
        }

    }
}