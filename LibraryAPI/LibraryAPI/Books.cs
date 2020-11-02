using System;
using System.Collections.Generic;

namespace LibraryAPI
{
    public partial class Books
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int? GenreId { get; set; }

        public virtual Genres Genre { get; set; }
    }
}
