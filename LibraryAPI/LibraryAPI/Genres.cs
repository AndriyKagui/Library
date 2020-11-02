using System;
using System.Collections.Generic;

namespace LibraryAPI
{
    public partial class Genres
    {
        public Genres()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
