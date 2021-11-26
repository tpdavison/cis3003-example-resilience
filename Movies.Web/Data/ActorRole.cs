using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Web.Data
{
    public class ActorRole
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
