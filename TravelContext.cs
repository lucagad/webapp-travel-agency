using webapp_travel_agency.Models;

namespace webapp_travel_agency;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class TravelContext : IdentityDbContext<IdentityUser>
{
    public DbSet<TravelPackage> Travels { get; set; }
 
    
    public TravelContext()
    {

    }

    public TravelContext(DbContextOptions<TravelContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=db_travel;Persist Security Info=True;User ID=sa;Password=NET2022!");
    }
}
