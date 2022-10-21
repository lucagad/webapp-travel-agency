using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency;
using webapp_travel_agency.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TravelContextConnection") ?? throw new InvalidOperationException("Connection string 'TravelContextConnection' not found.");

builder.Services.AddDbContext<TravelContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TravelContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//defaultValue();
app.Run();


static void defaultValue()
{
    
    using (TravelContext db = new TravelContext()) 
    {
     
        // Creazione Viaggi
        db.Add(new TravelPackage { 
            Title = "Islanda: a caccia dell'aurora boreale", 
            Description = "Quando far un viaggio in Islanda per vedere l’aurora boreale? Sicuramente l’inverno è la stagione giusta: tra ottobre e marzo è il periodo migliore per ammirare la regina della notte danzare nel cielo e anche vedere paesaggi innevati.", 
            ImgUrl= "https://strapi-imaginary.weroad.it/resource/medium/12846/viaggio-avventura-islanda-mondo-aurora-boreale.jpg", 
            Price = 1499, 
            StartDate = DateTime.Today, 
            EndDate = DateTime.Today.AddDays(2)});
        db.Add(new TravelPackage { 
            Title = "Vietnam: da Hanoi a Ho Chi Minh City", 
            Description = "Il Vietnam è il Paese giusto per immergersi nel cuore del Sud Est Asiatico: i paesaggi naturali sono incredibili, le città frenetiche come tutte le città asiatiche, le persone sorridenti ed accoglienti.", 
            ImgUrl= "https://strapi-imaginary.weroad.it/resource/medium/20101/vietnam-weroad-ninh-binh-gruppo.jpeg", 
            Price = 1299, 
            StartDate = DateTime.Today.AddDays(2), 
            EndDate = DateTime.Today.AddDays(7)});
        db.Add(new TravelPackage { 
            Title = "Guadalupa beachlife: spiagge delle Antille Francesi e Mar dei Caraibi", 
            Description = "Guadalupa è un piccolo paradiso terrestre nel cuore dei Caraibi: un’isola a forma di farfalla che fa parte delle Piccole Antille francesi, che si affaccia sull’Oceano Atlantico e sul Mar dei Caraibi.", 
            ImgUrl= "https://strapi-imaginary.weroad.it/resource/medium/20242/thailandia-mare-spiaggia-inverno.jpeg", 
            Price = 1499, 
            StartDate = DateTime.Today.AddDays(7), 
            EndDate = DateTime.Today.AddDays(21) });
        
        db.SaveChanges();
            
        Console.WriteLine("Dati Inseriti");
            
    }
}