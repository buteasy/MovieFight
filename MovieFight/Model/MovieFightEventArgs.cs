using System;
using System.Collections.Generic;
using System.Text;

namespace MovieFight.Model
{
    public class MovieFightEventArgs : EventArgs
    {
        private string _winner;
        public string Winner { get { return _winner; } }

        public MovieFightEventArgs(string winner)
        {
            _winner = winner;
        }
    }
}
