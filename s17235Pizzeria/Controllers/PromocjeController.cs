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
    public class PromocjeController : ControllerBase
    {
        private s17235Context _context;
        public PromocjeController(s17235Context context)
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
            var promocja = _context.Promocja.FirstOrDefault(e => e.IdPromocja == id);
            if (promocja == null)
                return NotFound();

            return Ok(promocja);
        }
    }
}