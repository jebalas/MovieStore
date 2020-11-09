using System;
namespace MovieLab24.Data
{
    public class Movies
    {
        public Movies()
        {
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string Actors { get; set; }
        public string Directors { get; set; }
        public double Runtime { get; set; }
    }
}
