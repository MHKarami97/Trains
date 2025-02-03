namespace Trains.Models;

public class ResponseInfoAlibaba
{
    public class Departing
    {
        public object proposalId { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public int rationCode { get; set; }
        public int trainNumber { get; set; }
        public string wagonName { get; set; }
        public int wagonType { get; set; }
        public DateTime moveDatetime { get; set; }
        public DateTime departureDateTime { get; set; }
        public int seat { get; set; }
        public int cost { get; set; }
        public int fullPrice { get; set; }
        public bool isCompartment { get; set; }
        public int compartmentCapacity { get; set; }
        public bool hasAirCondition { get; set; }
        public bool hasMedia { get; set; }
        public Services services { get; set; }
        public string timeOfArrival { get; set; }
        public string companyName { get; set; }
        public int serviceType { get; set; }
        public string logoSuffix { get; set; }
        public bool hasDiscount { get; set; }
        public bool isSpecialOffer { get; set; }
        public List<object> specialOfferTexts { get; set; }
        public bool isFadakSpecialOffer { get; set; }
        public int minPassengerCount { get; set; }
        public string minLimitationMessage { get; set; }
        public int maxPassengerCount { get; set; }
        public int exclusiveCompartmentMaxPassengerCount { get; set; }
        public string maxLimitationMessage { get; set; }
        public bool hasFreeFood { get; set; }
        public bool nonRefundable { get; set; }
        public bool isCharter { get; set; }
        public string wagonClass { get; set; }
        public bool hasFoodOffer { get; set; }
        public List<object> foodOfferTexts { get; set; }
        public int axleCode { get; set; }
        public object oldExitDatetime { get; set; }
        public object oldFrom { get; set; }
        public object oldTo { get; set; }
        public List<object> badges { get; set; }
        public object discountBadge { get; set; }
        public int sortOrder { get; set; }
        public bool isFamilyCoupe { get; set; }
        public bool isTransitCar { get; set; }
        public string originName { get; set; }
        public string destinationName { get; set; }
        public string orginCode { get; set; }
        public string originCode { get; set; }
        public string destinationCode { get; set; }
        public DateTime arrivalDateTime { get; set; }
        public string availableType { get; set; }
    }

    public class Result
    {
        public List<Departing> departing { get; set; }
        public List<object> returning { get; set; }
        public object departingPreBuy { get; set; }
        public bool isCompleted { get; set; }
        public long departRouteRequestId { get; set; }
        public bool departingAlternativeRoute { get; set; }
        public int returnRouteRequestId { get; set; }
        public bool returnAlternativeRoute { get; set; }
    }

    public class RootAlibaba
    {
        public Result result { get; set; }
        public object targetUrl { get; set; }
        public bool success { get; set; }
        public object error { get; set; }
        public bool unauthorizedRequest { get; set; }
        public bool __wrapped { get; set; }
        public object __traceId { get; set; }
    }

    public class Services
    {
        public bool airCondition { get; set; }
        public bool media { get; set; }
    }
}