using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI
{
    public class MockBooks
    {
        public static void Initialize(IServiceProvider service)
        {
            using(var context = new librarydbContext(service.GetRequiredService<DbContextOptions<librarydbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Books
                    {
                        BookName = "Lord of the Rings",
                        Author = "J.R.R. Tolkien",  
                        Id = 1,
                        GenreId = 2
                    },
                    new Books
                    {
                        BookName = "Alice's Adventures in Wonderland",
                        Author = "Lewis Carroll",
                        Id = 2,
                        GenreId = 1
                    },
                    new Books
                    {
                        BookName = "Harry Potter and the Sorcerer's Stone",
                        Author = "J.R.R. Tolkien",
                        Id = 3,
                        GenreId = 2
                    },
                    new Books
                    {
                        BookName = "And Then There Were None",
                        Author = "Agatha Christie",
                        Id = 4,
                        GenreId = 3
                    },
                    new Books
                    {
                        BookName = "Pinocchio",
                        Author = "Carlo Collodi",
                        Id = 5,
                        GenreId = 4
                    },
                    new Books
                    {
                        BookName = "Catcher in the Rye",
                        Author = "J.D. Salinger",
                        Id = 6,
                        GenreId = 5
                    }
                    );
                 context.SaveChanges();
            }
        }
    }
}
