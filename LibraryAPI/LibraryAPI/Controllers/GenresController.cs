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
    public class GenresController : Controller
    {
        IRepository<Genres> db;

        public GenresController(IRepository<Genres> db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Genres> Get()
        {
            return db.GetAll().OrderBy(g => g.Genre);
        }

        [HttpGet("id")]
        public Genres Get(int id)
        {
            return db.Get(id);
        }

        [HttpPost]
        public IActionResult Post(Genres genre)
        {
            if (ModelState.IsValid)
            {
                db.Add(genre);
                return Ok(genre);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Genres genre)
        {
            if (ModelState.IsValid)
            {
                db.Update(genre);
                return Ok(genre);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Genres genre = db.Get(id);
            if (genre == null)
            {
                return NotFound();
            }
            db.Delete(id);
            return Ok(genre);
        }
    }
}
