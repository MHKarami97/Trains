namespace Trains.Models;

public class CancellationTermEntry
{
    public object Amount { get; set; }
    public int PercentAmount { get; set; }
    public string Title { get; set; }
}

public class Class
{
    public int Id { get; set; }
    public int Price { get; set; }
    public int Capacity { get; set; }
    public string WagonName { get; set; }
    public bool AirConditioning { get; set; }
    public bool Media { get; set; }
    public bool IsCompartment { get; set; }
    public int CompartmentCapacity { get; set; }
    public int Discount { get; set; }
    public int WagonId { get; set; }
    public string CapacityString { get; set; }
    public bool HasHotel { get; set; }
    public bool IsAvailable { get; set; }
    public string CancellationTerms { get; set; }
    public bool ReservationAvailable { get; set; }
    public string PngLogoPath { get; set; }
    public string SvgLogoPath { get; set; }
    public int MinPersons { get; set; }
    public int Owner { get; set; }
    public string OwnerName { get; set; }
    public bool HasCompartmentCapacity { get; set; }
    public object HotelId { get; set; }
    public object HotelName { get; set; }
    public bool RoundTrip { get; set; }
    public bool HasSpecialDiscount { get; set; }
    public object Score { get; set; }
    public List<CancellationTermEntry> CancellationTermEntries { get; set; }
    public List<SuggestedService> SuggestedServices { get; set; }
    public List<WagonService> WagonServices { get; set; }
}

public class Corporation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> Ids { get; set; }
}

public class Filters
{
    public List<Corporation> Corporations { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }
    public List<WagonType> WagonTypes { get; set; }
}

public class FromLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Title { get; set; }
}

public class Meta
{
    public bool AlwaysHasTrain { get; set; }
    public bool RouteNotFound { get; set; }
}

public class Price
{
    public int SellType { get; set; }
    public List<Class> Classes { get; set; }
}

public class RootMrBlit
{
    public List<Train> Trains { get; set; }
    public Filters Filters { get; set; }
    public ToLocation ToLocation { get; set; }
    public FromLocation FromLocation { get; set; }
    public string ContentPath { get; set; }
    public Meta Meta { get; set; }
    public List<object> TrainPackages { get; set; }
}

public class SuggestedService
{
    public int Id { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public object FromId { get; set; }
    public int ToId { get; set; }
    public string Carrier { get; set; }
    public string Number { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string UnitTitle { get; set; }
    public bool NeedDescription { get; set; }
    public List<string> Images { get; set; }
}

public class ToLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Title { get; set; }
}

public class Train
{
    public int Id { get; set; }
    public int From { get; set; }
    public int To { get; set; }
    public string FromName { get; set; }
    public string ToName { get; set; }
    public int TrainNumber { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int Provider { get; set; }
    public string ProviderName { get; set; }
    public int CorporationId { get; set; }
    public List<int> CorporationIds { get; set; }
    public string CorporationName { get; set; }
    public string Weekday { get; set; }
    public string DateString { get; set; }
    public string ArrivalDateString { get; set; }
    public bool FromCache { get; set; }
    public bool Cancellable { get; set; }
    public bool IsForeign { get; set; }
    public List<Price> Prices { get; set; }
    public object Score { get; set; }
}

public class WagonService
{
    public bool HasService { get; set; }
    public string Title { get; set; }
}

public class WagonType
{
    public int Id { get; set; }
    public string Name { get; set; }
}