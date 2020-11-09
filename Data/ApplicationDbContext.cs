using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MovieLab24.Data;

namespace MovieLab24.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<CheckedOutMovies> CheckedOutMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             builder.Entity<CheckedOutMovies>(c =>
             {
                  c.HasKey(k => k.Id);
             });

            builder.Entity<Movies>(a =>
            {
                a.HasKey(k => k.Id);
            });
            builder.Entity<Movies>().Property(a =>

                a.Title).HasMaxLength(50);
            builder.Entity<Movies>().Property(a =>

               a.Genre).HasMaxLength(20);


            builder.Entity<Movies>().HasData(
               new Movies { Id = 1, Title = "Borat", Genre = "Comedy", Year = "2006", Actors = "Sacha Baron Cohen", Directors = "Larry Charles", Runtime = 84 },
               new Movies { Id = 3, Title = "Monty Python and the Holy Grail", Genre = "Comedy", Year = "1975", Actors = "John Cleese", Directors = "Terry Gilliam, Terry Jones", Runtime = 92 },
               new Movies { Id = 4, Title = "Legally Blonde", Genre = "Comedy", Year = "2001", Actors = "Reese Witherspoon", Directors = "Robert Luketic", Runtime = 96 },
               new Movies { Id = 6, Title = "Baby Driver", Genre = "Action", Year = "2017", Actors = "Ansel Elgort, Kevin Spacey", Directors = "Edgar Wright", Runtime = 113 },
               new Movies { Id = 7, Title = "The Avengers", Genre = "Action", Year = "2012", Actors = "Robert Downey Jr, Chris Evans", Directors = "Joss Whedon", Runtime = 143 },
               new Movies { Id = 8, Title = "Pulp Fiction", Genre = "Action", Year = "1994", Actors = "John Travolta, Samuel Jackson, Uma Thurman", Directors = "Quentin Tarantino", Runtime = 154 },
               new Movies { Id = 9, Title = "Night of the Living Dead", Genre = "Horror", Year = "1968", Actors = "Judith O'Dea, Duane Jones", Directors = "George Romero", Runtime = 96 },
               new Movies { Id = 10, Title = "Silence of the Lambs", Genre = "Horror", Year = "1991", Actors = "Jodie Foster, Anthony Hopkins", Directors = "Jonathan Demme", Runtime = 118 },
               new Movies { Id = 11, Title = "The Babadook", Genre = "Horror", Year = "2014", Actors = "Essie Davis, Noah Wiseman", Directors = "Jennifer Kent", Runtime = 94 },
               new Movies { Id = 12, Title = "American Beauty", Genre = "Drama", Year = "1996", Actors = "Kevin Spacey, Annette Bening", Directors = "Sam Mendes", Runtime = 122 },
               new Movies { Id = 13, Title = "Forrest Gump", Genre = "Drama", Year = "1994", Actors = "Tom Hanks", Directors = "Robert Zemeckis", Runtime = 142 },
               new Movies { Id = 14, Title = "Slumdog Millionaire", Genre = "Drama", Year = "2008", Actors = "Dev Patel, Freida Pinto", Directors = "Danny Boyle", Runtime = 120 },
               new Movies { Id = 15, Title = "Snowpiercer", Genre = "SciFi", Year = "2013", Actors = "Chris Evans, Song Kang-ho", Directors = "Bong Joon-ho", Runtime = 126 },
               new Movies { Id = 2, Title = "V for Vendetta", Genre = "SciFi", Year = "2006", Actors = "Natalie Portman, Hugo Weaving", Directors = "James McTeigue", Runtime = 133 },
               new Movies { Id = 5, Title = "Soylent Green", Genre = "SciFi", Year = "1973", Actors = "Charlton Heston", Directors = "Richard Fleischer", Runtime = 97 }
               );

            base.OnModelCreating(builder);
        }
    }


    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Server=127.0.0.1;Database=MovieStore;User=sa;Password=Cornflake7!");
            return new ApplicationDbContext(builder.Options);
        }
    }
}
