using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MovieFight.Model
{
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Date { get; set; }
        public int Column { get; set; }
    }
}
