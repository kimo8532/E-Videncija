using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Videncija.DAL;
using E_Videncija.DAL.DataModel;

namespace E_Videncija.Server.Controllers
{
    [Route("api/radnikplaca")]
    [ApiController]
    public class RadnikPlacasController : Controller
    {
        private readonly EVidencijaDbContext _context;

        public RadnikPlacasController(EVidencijaDbContext context)
        {
            _context = context;
        }

        // GET: RadnikPlacas
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var eVidencijaDbContext = _context.RadnikPlacas.Include(r => r.IdEvidentiranogMjesecaNavigation).Include(r => r.IdRadnikNavigation);
            return Ok(await eVidencijaDbContext.ToListAsync());
        }

        // GET: RadnikPlacas/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnikPlaca = await _context.RadnikPlacas
                .Include(r => r.IdEvidentiranogMjesecaNavigation)
                .Include(r => r.IdRadnikNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radnikPlaca == null)
            {
                return NotFound();
            }

            return Ok(radnikPlaca);
        }
    }
}
