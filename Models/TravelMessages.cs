namespace webapp_travel_agency.Models;


public class TravelMessages
{
    public TravelPackage TravelPackage { get; set; }
    public List<Message>? Messages { get; set; }
    
    
    public TravelMessages()
    {
        TravelPackage = new TravelPackage();
        Messages = new List<Message>();
    }
}