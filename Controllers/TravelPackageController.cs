using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers;


/*[Authorize]*/
public class TravelPackageController : Controller
{
    public IActionResult Index()
    {
        List<TravelPackage> travelPackages;

        using (TravelContext db = new TravelContext())
        {
            travelPackages = db.Travels.ToList();
        }

        return View("Index", travelPackages);
    }

    /*public IActionResult Show(int id)
    {
        
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TravelPackage formData)
    {
        
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        
    }

    [HttpPost]
    public IActionResult Update(int id, TravelPackage formData)
    {
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        
    }*/
}