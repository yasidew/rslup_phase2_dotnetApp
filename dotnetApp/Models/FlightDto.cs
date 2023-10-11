using Microsoft.AspNetCore.SignalR;

public class FlightDto {
    public int Id{get; set; }
    public string DepartureCity{get; set;}
    public string ArrivalCity{get; set;}
    public String Airline{get; set;}
}