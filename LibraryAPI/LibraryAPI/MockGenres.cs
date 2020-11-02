using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI
{
    public class MockGenres
    {
         public static void Initialize(IServiceProvider service)
        {
            using (var context = new librarydbContext(service.GetRequiredService<DbContextOptions<librarydbContext>>()))
            {
                if (context.Genres.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genres
                    {
                        Id = 1,
                        Genre = "Unknown"
                    },
                    new Genres
                    {
                        Id = 2,
                        Genre = "Fantasy"
                    },
                    new Genres
                    {
                        Id = 3,
                        Genre = "Detective & Mystery"
                    },
                    new Genres
                    {
                        Id = 4,
                        Genre = "Fairy Tails"
                    },
                    new Genres
                    {
                        Id = 5,
                        Genre = "Novels"
                    }
                    );
                 context.SaveChanges();
            }
        }
    }
}
