using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Videncija.Service.Common;

namespace E_Videncija.Server.Controllers
{
    [Route("api/userinformations")]
    [ApiController]
    public class UserInformationsController : Controller
    {
        private IService _service;

        public UserInformationsController(IService service)
        {
            _service = service;
        }

        // GET: UserInformations
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_service.GetAllUsers());
        }

        // GET: UserInformations/Details/5
        [HttpGet("{id}")]
        public IActionResult Details(int? id)
        {
            var userInformation = _service.GetUserByUserId(id);

            return Ok(userInformation);
        }
    }
}
