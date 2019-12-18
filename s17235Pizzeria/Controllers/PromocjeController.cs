using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using s17235Pizzeria.Models;

namespace s17235Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocjeController : ControllerBase
    {
        private s17235Context _context;
        public PromocjeController(s17235Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Metoda zwraca dane na temat wszytskich promocji
        /// </summary>
        /// <returns>
        /// Lista obiektów reprezentujących promocje
        /// </returns>
        [HttpGet]
        public IActionResult GetPromocja()
        {
            return Ok(_context.Promocja.ToList());
        }

        /// <summary>
        /// Metoda zwraca dane na temat konkretnej promocji
        /// </summary>
        /// <param name="IdPromocja">Numer identyfikacyjny promocji</param>
        /// <returns>
        /// Obiekt reprezentujący promocję
        /// </returns>
        [HttpGet("{IdPromocja:int}")]
        public IActionResult GetPromocja(int IdPromocja)
        {
            var promocja = _context.Promocja.FirstOrDefault(e => e.IdPromocja == IdPromocja);
            if (promocja == null)
                return NotFound();

            return Ok(promocja);
        }

        /// <summary>
        /// Metoda dodaje obiekt promocji
        /// </summary>
        /// <param name="promocja">Obiekt promocji</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Promocja promocja)
        {
            _context.Promocja.Add(promocja);
            _context.SaveChanges();

            return StatusCode(201, promocja);
        }

        /// <summary>
        /// Metoda modyfikuje konkretny obiekt promocji
        /// </summary>
        /// <param name="IdPromocja">Numer identyfikacyjny promocji</param>
        /// <param name="promocja">Obiekt promocji</param>
        /// <returns></returns>
        [HttpPut("{IdPromocja:int}")]
        public IActionResult Update(int IdPromocja, Promocja promocja)
        {
            var istnieje = _context.Promocja.FirstOrDefault(e => e.IdPromocja == IdPromocja);
            if (istnieje == null)
                return NotFound();

            _context.Promocja.Attach(promocja);
            _context.Entry(promocja).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(promocja);
        }

        /// <summary>
        /// Metoda usuwa konkretny obiekt promocji
        /// </summary>
        /// <param name="IdPromocja">Numer identyfikacyjny promocji</param>
        /// <param name="promocja">Obiekt promocji</param>
        /// <returns></returns>
        [HttpDelete("{IdPromocja:int}")]
        public IActionResult Delete(int IdPromocja, Promocja promocja)
        {
            var istnieje = _context.Promocja.FirstOrDefault(e => e.IdPromocja == IdPromocja);
            if (istnieje == null)
                return NotFound();

            _context.Promocja.Remove(promocja);
            _context.SaveChanges();

            return Ok(promocja);
        }
    }
}