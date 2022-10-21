using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp_travel_agency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp_travel_agency.Controllers.API
{ 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
       
        [HttpPost]
        public IActionResult Send([FromBody] Message message)
        {
           
            TravelContext ctx = new TravelContext();

            ctx.Messages.Add(message);
            ctx.SaveChanges();

            return Ok();
        }
        
    }
}