using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Data
{
    public static class MovieDbInitialiser
    {
        public static async Task SeedTestData(MovieDbContext context)
        {
            if (context.People.Any())
            {
                //db seems to be seeded
                return;
            }

            // Seed database with test data -- wouldn't normally do this for production code

            var nationalities = new List<Nationality>
            {
                new Nationality { Id = 1, Title = "British" },
                new Nationality { Id = 2, Title = "French" },
                new Nationality { Id = 3, Title = "American" }
            };
            nationalities.ForEach(n => context.Nationalities.Add(n));
            await context.SaveChangesAsync();

            var people = new List<Person>
            {
                new Person { Id = 1, NationalityId = 1, Birthday = DateTime.Now, FirstName = "Larry", LastName = "Losser" },
                new Person { Id = 2, NationalityId = 1, Birthday = new DateTime(1970, 2, 14), FirstName = "Simon", LastName = "Pegg" },
                new Person { Id = 3, NationalityId = 1, Birthday = new DateTime(1976, 7, 19), FirstName = "Benedict", LastName = "Cumberbatch" },
                new Person { Id = 4, NationalityId = 2, Birthday = new DateTime(1948, 7, 30), FirstName = "Jean", LastName = "Reno" },
                new Person { Id = 5, NationalityId = 3, Birthday = new DateTime(1980, 8, 26), FirstName = "Chris", LastName = "Pine" },
                new Person { Id = 6, NationalityId = 3, Birthday = new DateTime(1966, 6, 27), FirstName = "JJ", LastName = "Abrams" }
            };
            people.ForEach(p => context.People.Add(p));
            await context.SaveChangesAsync();

            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Star Wars: The Force Awakens", ReleaseDate = new DateTime(2015, 12, 18), DirectorId = 6 },
                new Movie { Id = 2, Title = "Star Trek", ReleaseDate = new DateTime(2009, 5, 8), DirectorId = null }
            };
            movies.ForEach(m => context.Movies.Add(m));
            await context.SaveChangesAsync();

            var actorRoles = new List<ActorRole>
            {
                new ActorRole { MovieId = 1, PersonId = 2 },
                new ActorRole { MovieId = 2, PersonId = 5 }
            };
            actorRoles.ForEach(ar => context.ActorRoles.Add(ar));
            await context.SaveChangesAsync();
        }
    }
}
