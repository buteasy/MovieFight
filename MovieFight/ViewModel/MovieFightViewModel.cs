﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MovieFight.Model;

namespace MovieFight.ViewModel
{
    public class MovieFightViewModel : INotifyPropertyChanged
    {
        private MovieFightModel _model;
        private string _winnerValue;
        private string _ffMovieValue;
        private string _fsMovieValue;
        private string _mfMovieValue;
        private string _msMovieValue;
        public string WinnerValue
        {
            get { return _winnerValue; }
            set
            {
                if (_winnerValue != value)
                    _winnerValue = value;
                    OnPropertyChanged();
            }
        }
        public string FFMovieValue
        {
            get { return _ffMovieValue; }
            set
            {
                if (_ffMovieValue != value)
                    _ffMovieValue = value;
                    OnPropertyChanged();
            }
        }
        public string FSMovieValue
        {
            get { return _fsMovieValue; }
            set
            {
                if (_fsMovieValue != value)
                    _fsMovieValue = value;
                OnPropertyChanged();
            }
        }
        public string MFMovieValue
        {
            get { return _mfMovieValue; }
            set
            {
                if (_mfMovieValue != value)
                    _mfMovieValue = value;
                OnPropertyChanged();
            }
        }
        public string MSMovieValue
        {
            get { return _msMovieValue; }
            set
            {
                if (_msMovieValue != value)
                    _msMovieValue = value;
                OnPropertyChanged();
            }
        }
        public DelegateCommand FightCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MovieFightViewModel(MovieFightModel model)
        {
            FightCommand = new DelegateCommand(param => Fight());
            _model = model;
            _model.FightStarted += new EventHandler<MovieFightEventArgs>(FightResult);
        }

        private void FightResult(object sender, MovieFightEventArgs e)
        {
            WinnerValue = e.Winner;
        }

        private void Fight()
        {
            List<String> movies = new List<string>();
            movies.Add(_ffMovieValue);
            movies.Add(_fsMovieValue);
            movies.Add(_mfMovieValue);
            movies.Add(_msMovieValue);
            _model.Fight(movies);
        }

        private void OnPropertyChanged([CallerMemberName] String property = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}