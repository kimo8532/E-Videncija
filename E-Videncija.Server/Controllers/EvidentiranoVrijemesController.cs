using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Videncija.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.Server.Controllers
{
    [Route("api/evidentiranovrijeme")]
    [ApiController]
    public class EvidentiranoVrijemesController : Controller
    {
        private readonly EVidencijaDbContext _context;

        public EvidentiranoVrijemesController(EVidencijaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var eVidencijaDbContext = _context.EvidentiranoVrijemes.Include(e => e.EvidentiranMjesec);
            return Ok(await eVidencijaDbContext.ToListAsync());
        }

        // GET: EvidentiranoVrijemes/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidentiranoVrijeme = await _context.EvidentiranoVrijemes
                .Include(e => e.EvidentiranMjesec)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evidentiranoVrijeme == null)
            {
                return NotFound();
            }

            return Ok(evidentiranoVrijeme);
        }

        
    }
}
