using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp_travel_agency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp_travel_agency.Controllers.API
{
    //api/Travel
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelPackageController : ControllerBase
    {
        TravelContext _ctx;
        public TravelPackageController()
        {
            _ctx = new TravelContext();
        }
        
        //api/Pizza
        [HttpGet]
        public IActionResult GetAll()
        {
            List<TravelPackage> travels = _ctx.Travels.ToList();
            return Ok(travels);
        }
        
        //api/Pizza/GetByName
        [HttpGet()]
        public IActionResult GetByTitle(string? title)
        {
            IQueryable<TravelPackage> travels;

            if(title != null){
                
                travels = _ctx.Travels.Where(travelPackage => travelPackage.Title.ToLower().Contains(title.ToLower()) || travelPackage.Description.ToLower().Contains(title.ToLower()));
            }
            else
            {
                travels = _ctx.Travels;
            }

            return Ok(travels.ToList());
        }
       
        //api/Pizza/GetById/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TravelPackage travel = _ctx.Travels.Where(travelPackage => travelPackage.Id == id).FirstOrDefault();
            return Ok(travel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TravelPackage travel = _ctx.Travels.Where(travelPackage => travelPackage.Id == id).FirstOrDefault();
            
            if (travel == null)
            {
                return NotFound(new { Message = "Viaggio non trovata", Id = id});
            }

            try
            {
                _ctx.Travels.Remove(travel);
                _ctx.SaveChanges();
            }
            catch (SqlException e)
            {
                
            }
            
            return Ok(new { Message = "Viaggio eliminato correttamente", Id = id });
            
        }
    }
}