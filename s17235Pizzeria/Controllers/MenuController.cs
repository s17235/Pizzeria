﻿using System;
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
    public class MenuController : ControllerBase
    {
        private s17235Context _context;
        public MenuController(s17235Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Metoda zwraca dane na temat wszytskich menu
        /// </summary>
        /// <returns>
        /// Lista obiektów reprezentujących menu
        /// </returns>
        [HttpGet]
        public IActionResult GetMenu()
        {
            return Ok(_context.Menu.ToList());
        }

        /// <summary>
        /// Metoda zwraca dane na temat danego menu
        /// </summary>
        /// <param name="IdMenu">Numer identyfikacyjny menu</param>
        /// <returns>
        /// Obiekt reprezentujący menu
        /// </returns>
        [HttpGet("{IdMenu:int}")]
        public IActionResult GetMenu(int IdMenu)
        {
            var menu = _context.Menu.FirstOrDefault(e => e.IdMenu == IdMenu);
            if (menu == null)
                return NotFound();

            return Ok(menu);
        }

        /// <summary>
        /// Metoda tworzy obiekt menu
        /// </summary>
        /// <param name="menu">Obiekt menu</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            _context.Menu.Add(menu);
            _context.SaveChanges();

            return StatusCode(201, menu);
        }

        /// <summary>
        /// Metoda modyfikuje konkretny obiekt menu
        /// </summary>
        /// <param name="IdMenu">Numer identyfikacyjny menu</param>
        /// <param name="menu">Obiekt menu</param>
        /// <returns></returns>
        [HttpPut("{IdMenu:int}")]
        public IActionResult Update(int IdMenu, Menu menu)
        {
            var istnieje = _context.Menu.FirstOrDefault(e => e.IdMenu == IdMenu);
            if (istnieje == null)
                return NotFound();

            _context.Menu.Attach(menu);
            _context.Entry(menu).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(menu);
        }

        /// <summary>
        /// Metoda usuwa konkretny obiekt menu
        /// </summary>
        /// <param name="IdMenu">Numer identyfikacyjny menu</param>
        /// <param name="menu">Obiekt menu</param>
        /// <returns></returns>
        [HttpDelete("{IdMenu:int}")]
        public IActionResult Delete(int IdMenu, Menu menu)
        {

            var istnieje = _context.Menu.FirstOrDefault(e => e.IdMenu == IdMenu);
            if (istnieje == null)
                return NotFound();

            _context.Menu.Remove(menu);
            _context.SaveChanges();

            return Ok(menu);
        }
    }
}