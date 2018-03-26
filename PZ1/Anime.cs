using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ1
{
    public class Anime
    {
        private string title;
        private string character;
        private string image;
        private double imdb;
        private string restriction;
        private string text;

        public string Title { get => title; set => title = value; }
        public string Character { get => character; set => character = value; }
        public string Image { get => image; set => image = value; }
        public double Imdb { get => imdb; set => imdb = value; }
        public string Restriction { get => restriction; set => restriction = value; }
        public string Text { get => text; set => text = value; }
        

        public Anime()
        {

        }
        public Anime(string t, string ch, string im, double imdb, string rest,string text)
        {
            Title = t;
            Character = ch;
            Image = im;
            Imdb = imdb;
            Restriction = rest;
            Text = text;          
        }
    }
}
