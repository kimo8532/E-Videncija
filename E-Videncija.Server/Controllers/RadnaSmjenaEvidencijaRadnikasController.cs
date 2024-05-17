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
    [Route("api/radnasmjenaevidencijaradnika")]
    [ApiController]
    public class RadnaSmjenaEvidencijaRadnikasController : Controller
    {
        private readonly EVidencijaDbContext _context;

        public RadnaSmjenaEvidencijaRadnikasController(EVidencijaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var eVidencijaDbContext = _context.RadnaSmjenaEvidencijaRadnikas.Include(r => r.IdRadnaSmjenaRadniciNavigation);
            return Ok(await eVidencijaDbContext.ToListAsync());
        }

        // GET: RadnaSmjenaEvidencijaRadnikas/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnaSmjenaEvidencijaRadnika = await _context.RadnaSmjenaEvidencijaRadnikas
                .Include(r => r.IdRadnaSmjenaRadniciNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radnaSmjenaEvidencijaRadnika == null)
            {
                return NotFound();
            }

            return Ok(radnaSmjenaEvidencijaRadnika);
        }

        
    }
}
