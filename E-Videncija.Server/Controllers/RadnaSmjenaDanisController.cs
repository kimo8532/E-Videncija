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
    [Route("api/radnasmjenadani")]
    [ApiController]
    public class RadnaSmjenaDanisController : Controller
    {
        private readonly EVidencijaDbContext _context;

        public RadnaSmjenaDanisController(EVidencijaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var eVidencijaDbContext = _context.RadnaSmjenaDanis.Include(r => r.IdRadnaSmjenaNavigation);
            return Ok(await eVidencijaDbContext.ToListAsync());
        }

        // GET: RadnaSmjenaDanis/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnaSmjenaDani = await _context.RadnaSmjenaDanis
                .Include(r => r.IdRadnaSmjenaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radnaSmjenaDani == null)
            {
                return NotFound();
            }

            return Ok(radnaSmjenaDani);
        }

        
    }
}
