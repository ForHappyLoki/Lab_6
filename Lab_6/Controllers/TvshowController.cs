using Lab_6.Data;
using Lab_6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_6_1.Controllers
{
    [Route("api/[controller]")]
    public class TvshowController : Controller
    {
        private DatabaseContext _db;
        public TvshowController(DatabaseContext dataBase)
        {
            _db = dataBase;
        }
        //Invoke-RestMethod https://localhost:7242/api/Tvshow -Method GET
        [HttpGet]
        public IEnumerable<Tvshow> Get()
        {
            return _db.Tvshows.ToList();
        }

        //Invoke-RestMethod http://localhost:5247/api/Tvshow/2 -Method GET
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Tvshow show = _db.Tvshows.FirstOrDefault(x => x.ShowId == id);
            if (show == null)
                return NotFound();
            return new ObjectResult(show);
        }
        // Invoke-RestMethod http://localhost:5247/api/Tvshow -Method POST -Body (@{GenreId = 1; Title = "Название"; Description = "Описание"; Duration = 30; Rating = 5} | ConvertTo-Json) -ContentType "application/json"
        [HttpPost]
        public IActionResult Post([FromBody] Tvshow show)
        {
            if (show == null)
            {
                return BadRequest();
            }

            _db.Tvshows.Add(show);
            _db.SaveChanges();
            return Ok(show);
        }
        // Invoke-RestMethod http://localhost:5247/api/Tvshow -Method PUT -Body (@{ShowId = 101; GenreId = "1"; Title = "Новое название"; Description = "Описание"; Duration = "30"; Rating = "5"} | ConvertTo-Json) -ContentType "application/json"
        [HttpPut]
        public IActionResult Put([FromBody] Tvshow user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!_db.Tvshows.Any(x => x.ShowId == user.ShowId))
            {
                return NotFound();
            }

            _db.Update(user);
            _db.SaveChanges();
            return Ok(user);
        }
        // Invoke-RestMethod http://localhost:5247/api/Tvshow/101 -Method DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Tvshow user = _db.Tvshows.FirstOrDefault(x => x.ShowId == id);
            if (user == null)
            {
                return NotFound();
            }
            _db.Tvshows.Remove(user);
            _db.SaveChanges();
            return Ok(user);
        }

    }
}
