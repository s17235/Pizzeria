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
    public class ZamowienieController : ControllerBase
    {
        private s17235Context _context;
        public ZamowienieController(s17235Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Metoda zwraca dane na temat wszytskich zamówień
        /// </summary>
        /// <returns>
        /// Lista obiektów reprezentujących zamówienia
        /// </returns>
        [HttpGet]
        public IActionResult GetZamowienie()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        /// <summary>
        /// Metoda zwraca dane na temat konkretnego zamówienia
        /// </summary>
        /// <param name="IdZamowienie">Numer identyfikacyjny zamówienia</param>
        /// <returns>Obiekt reprezentujący zamówienie</returns>
        [HttpGet("{IdZamowienie:int}")]
        public IActionResult GetZamowienie(int IdZamowienie)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == IdZamowienie);
            if (zamowienie == null)
                return NotFound();

            return Ok(zamowienie);
        }

        /// <summary>
        /// Metoda tworzy obiekt zamówienia
        /// </summary>
        /// <param name="zamowienie">Obiekt zamowienia</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Zamowienie zamowienie)
        {
            _context.Zamowienie.Add(zamowienie);
            _context.SaveChanges();

            return StatusCode(201, zamowienie);
        }

        /// <summary>
        /// Metoda modyfikuje obiekt zamówienia
        /// </summary>
        /// <param name="IdZamowienie">Numer identyfikacyjny zamówienia</param>
        /// <param name="zamowienie">Obiekt zamowienia</param>
        /// <returns></returns>
        [HttpPut("{IdZamowienie:int}")]
        public IActionResult Update(int IdZamowienie, Zamowienie zamowienie)
        {
            var istnieje = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == IdZamowienie);
            if (istnieje == null)
                return NotFound();

            _context.Zamowienie.Attach(zamowienie);
            _context.Entry(zamowienie).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(zamowienie);
        }

        /// <summary>
        /// Metoda usuwa obiekt zamówienia
        /// </summary>
        /// <param name="IdZamowienie">Numer identyfikacyjny zamówienia</param>
        /// <param name="zamowienie">Obiekt zamowienia</param>
        /// <returns></returns>
        [HttpDelete("{IdZamowienie:int}")]
        public IActionResult Delete(int IdZamowienie, Zamowienie zamowienie)
        {
            var istnieje = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == IdZamowienie);
            if (istnieje == null)
                return NotFound();

            _context.Zamowienie.Remove(zamowienie);
            _context.SaveChanges();

            return Ok(zamowienie);
        }

    }
}