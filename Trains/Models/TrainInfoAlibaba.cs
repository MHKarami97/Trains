namespace Trains.Models;

public class TrainInfoAlibaba
{
    public int From { get; set; }
    public int To { get; set; }
    public DateTime DepartureDate { get; set; }
    public int PassengerCount { get; set; }
    public int TicketType { get; set; } = 1;
    public bool IsExclusiveCompartment { get; set; } = false;
    public object? ReturnDate { get; set; } = null;
    public object? ServiceType { get; set; } = null;
    public int Channel { get; set; } = 1;
    public object? AvailableTargetType { get; set; } = null;
    public object? Requester { get; set; } = null;
    public int UserId { get; set; } = 1331289;
    public bool OnlyWithHotel { get; set; } = false;
    public object? ForceUpdate { get; set; } = null;
}