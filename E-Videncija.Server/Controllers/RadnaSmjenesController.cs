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
    [Route("api/radnasmjene")]
    [ApiController]
    public class RadnaSmjenesController : Controller
    {
        private readonly EVidencijaDbContext _context;

        public RadnaSmjenesController(EVidencijaDbContext context)
        {
            _context = context;
        }

        // GET: RadnaSmjenes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.RadnaSmjenes.ToListAsync());
        }

        // GET: RadnaSmjenes/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnaSmjene = await _context.RadnaSmjenes
                .FindAsync(id);
            if (radnaSmjene == null)
            {
                return NotFound();
            }

            return Ok(radnaSmjene);
        }

     
    }
}
