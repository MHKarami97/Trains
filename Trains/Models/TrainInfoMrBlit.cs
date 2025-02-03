namespace Trains.Models;

public class TrainInfoMrBlit
{
    public int From { get; set; }
    public int To { get; set; }
    public DateTime Date { get; set; }
    public int AdultCount { get; set; }
    public int Gender { get; set; } = 3;
    public int ChildCount { get; set; } = 0;
    public int InfantCount { get; set; } = 0;
    public bool Exclusive { get; set; } = false;
    public string AvailableStatus { get; set; } = "BOTH";
}