using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Web.Data
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int? DirectorId { get; set; }

        public Person Director { get; set; }

        public List<ActorRole> Actors { get; set; }
    }
}
