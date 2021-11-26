using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Web.Data
{
    public class Nationality
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
