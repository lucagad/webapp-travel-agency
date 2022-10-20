using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_travel_agency.Models;

[Table("TravelPackage")]
public class TravelPackage
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [StringLength (50, ErrorMessage = "Il nome non può avere più di 50 caratteri")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [StringLength (100, ErrorMessage = "La descrizione non può avere più di 100 caratteri")]
    public string Description  { get; set; }
    
    public string? ImgUrl { get; set; }
    
    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [Range(0.01, 2999.99, ErrorMessage = "Il prezzo deve essere compreso tra 0.01 ed 2999.99")]
    public double Price { get; set; }
    
    public int Days { get; set; }
    
    public int Destinations { get; set; }
  
    public TravelPackage()
    {
        
    }
    
    public TravelPackage(string title, string description, string? img , double price, int days ,int destinations)
    {
        Title = title;
        Description = description;
        if (img != null)
        {
            ImgUrl = img;
        }
        else
        {
            ImgUrl = "/img/placeholder.jpg";
        }
        Price = price;
        Days = days;
        Destinations = destinations;
    }
}
