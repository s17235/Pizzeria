using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetEmps()
        {
            return Ok(_context.Emp.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmp(int id)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == id);
            if (zamowienie == null)
                return NotFound();

            return Ok(zamowienie);
        }
    }
}