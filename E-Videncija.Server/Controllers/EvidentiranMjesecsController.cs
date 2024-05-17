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
    [Route("api/evidentiranmjesec")]
    [ApiController]
    public class EvidentiranMjesecsController : Controller
    {
        private readonly EVidencijaDbContext _context;

        public EvidentiranMjesecsController(EVidencijaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.EvidentiranMjesecs.ToListAsync());
        }

        // GET: EvidentiranMjesecs/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidentiranMjesec = await _context.EvidentiranMjesecs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evidentiranMjesec == null)
            {
                return NotFound();
            }

            return Ok(evidentiranMjesec);
        }

    }
}
