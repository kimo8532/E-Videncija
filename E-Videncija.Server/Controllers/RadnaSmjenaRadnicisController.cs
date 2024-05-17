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
    [Route("api/radnasmjenaradnici")]
    [ApiController]
    public class RadnaSmjenaRadnicisController : Controller
    {
        private readonly EVidencijaDbContext _context;

        public RadnaSmjenaRadnicisController(EVidencijaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var eVidencijaDbContext = _context.RadnaSmjenaRadnicis.Include(r => r.IdRadnaSmjenaDaniNavigation).Include(r => r.IdUserInformationNavigation);
            return Ok(await eVidencijaDbContext.ToListAsync());
        }

        // GET: RadnaSmjenaRadnicis/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnaSmjenaRadnici = await _context.RadnaSmjenaRadnicis
                .Include(r => r.IdRadnaSmjenaDaniNavigation)
                .Include(r => r.IdUserInformationNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (radnaSmjenaRadnici == null)
            {
                return NotFound();
            }

            return Ok(radnaSmjenaRadnici);
        }
    }
}
