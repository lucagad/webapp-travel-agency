using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers;


[Authorize]
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

    public IActionResult Show(int id)
    {
        using (TravelContext context = new TravelContext())
        {
            TravelPackage travelFounded = context.Travels
                .Where(travelPackage => travelPackage.Id == id).First();
            
            if (travelFounded == null)
            {
                return NotFound($"Il viaggio con id {id} non è stato trovato");
            }
            else
            {
                return View("Show", travelFounded);
            }
        }
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TravelPackage formData)
    {
        if (!ModelState.IsValid)
        {
            return View("Create");
        }

        using (TravelContext context = new TravelContext())
        {
            TravelPackage travelToCreate = new TravelPackage();
            
            travelToCreate.Title = formData.Title;
            travelToCreate.Description = formData.Description;
            
            if (formData.ImgUrl != null)
            {
                travelToCreate.ImgUrl = formData.ImgUrl;
            }
            else
            {
                travelToCreate.ImgUrl="/img/placeholder.jpg";
            }
            
            travelToCreate.Price = formData.Price;
            travelToCreate.StartDate = formData.StartDate;
            travelToCreate.EndDate = formData.EndDate;

            if (Convert.ToInt32((travelToCreate.EndDate - travelToCreate.StartDate).TotalDays) == 0)
            {
                travelToCreate.Days = 1;
            }
            else
            {
                travelToCreate.Days =
                    Convert.ToInt32((travelToCreate.EndDate - travelToCreate.StartDate).TotalDays);
            }
            
            context.Travels.Add(travelToCreate);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        using (TravelContext context = new TravelContext())
        {
            TravelPackage travelSelected = context.Travels
                .Where(travelPackage => travelPackage.Id == id).First();
            
            if (travelSelected == null)
            {
                return NotFound("Viaggio non trovato");
            }
            
            return View (travelSelected);
        }
        
    }

    [HttpPost]
    public IActionResult Update(int id, TravelPackage formData)
    {
        using (TravelContext context = new TravelContext())
        {
            TravelPackage travelSelected =  context.Travels
                .Where(travelPackage => travelPackage.Id == id).FirstOrDefault();

            travelSelected.Title = formData.Title;
            travelSelected.Description = formData.Description;
            
            if (formData.ImgUrl != null)
            {
                travelSelected.ImgUrl = formData.ImgUrl;
            }
            else
            {
                travelSelected.ImgUrl="/img/placeholder.jpg";
            }
            
            travelSelected.Price = formData.Price;
            travelSelected.StartDate = formData.StartDate;
            travelSelected.EndDate = formData.EndDate;
            
            if (Convert.ToInt32((travelSelected.EndDate - travelSelected.StartDate).TotalDays) == 0)
            {
                travelSelected.Days = 1;
            }
            else
            {
                travelSelected.Days =
                    Convert.ToInt32((travelSelected.EndDate - travelSelected.StartDate).TotalDays);
            }
            
            context.Travels.Update(travelSelected);

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        using (TravelContext context = new TravelContext())
        {
            TravelPackage travel =  context.Travels
                .Where(travelPackage => travelPackage.Id == id).FirstOrDefault();
            if (travel == null)
            {
                return NotFound("Non trovato");
            }
            context.Travels.Remove(travel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}