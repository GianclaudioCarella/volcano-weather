using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Infrasctructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearController : Controller
    {

        private readonly YearService _service;

        public YearController(YearService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Year>> Get()
        {
            return _service.GetYears();
        }

        [HttpPost]
        public ActionResult Post(Year year)
        {
            _service.Create(year);
            return Ok();
        }


    }
}