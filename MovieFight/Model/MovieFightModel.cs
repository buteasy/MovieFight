using System;
using System.Collections.Generic;
using System.Text;

namespace MovieFight.Model
{
    public class MovieFightModel
    {
        private int _winner;
        private Random _rnd;
        public int Winner { get { return _winner; } }
        public event EventHandler<MovieFightEventArgs> FightStarted;

        public MovieFightModel()
        {
            _rnd = new Random();
        }

        public void Fight(List<String> movies)
        {
            FightStarted?.Invoke(this, new MovieFightEventArgs(movies[_rnd.Next(0, 5)]));
        }
    }
}
