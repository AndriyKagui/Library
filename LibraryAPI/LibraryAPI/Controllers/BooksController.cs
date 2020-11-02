using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        IRepository<Books> db;
        
        public BooksController(IRepository<Books> db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Books> Get()
        {
            return db.GetAll().OrderBy(b => b.BookName);
        }

        [HttpGet("id")]
        public Books Get(int id)
        {
            return db.Get(id);
        }

        [HttpGet("genre/{id?}")]
        public IEnumerable<Books> GetByGenre(int? id)
        {
            if (id != null)
            {
                return db.GetAll().Where(x => x.GenreId == id);
            }
            else
            {
                return db.GetAll();
            }
        }

        [HttpPost]
        public IActionResult AddBook(Books book)
        {
            if (ModelState.IsValid)
            {
                db.Add(book);
                return Ok(book);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Books book)
        {
            if (ModelState.IsValid)
            {
                db.Update(book);
                return Ok(book);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Books book = db.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Delete(id);
            return Ok(book);
        }
    }
}
