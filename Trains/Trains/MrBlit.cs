using Flurl.Http;
using Trains.Models;

namespace Trains.Trains;

public class MrBlit
{
    private readonly string _apiUrl;
    private const int TimeOutOnSecond = 10;

    public MrBlit(string apiUrl)
    {
        _apiUrl = apiUrl;
    }

    public async Task<bool> IsExist(TrainInfoMrBlit i)
    {
        var url = GenerateUrl(i);

        try
        {
            var data = await url
                .WithTimeout(TimeSpan.FromSeconds(TimeOutOnSecond))
                .GetJsonAsync<RootMrBlit>()
                .ConfigureAwait(false);

            if (data.Trains.Any(a => a.Prices.Any(b => b.Classes.Any(c => c.Capacity > 0))))
            {
                return true;
            }

            return false;
        }
        catch (FlurlHttpException e)
        {
            var body = await e.GetResponseStringAsync();
            throw new Exception(body);
        }
    }


    private string GenerateUrl(TrainInfoMrBlit i)
    {
        return
            $"{_apiUrl}?from={i.From}&to={i.To}&date={i.Date:yyyy-MM-dd}&genderCode={i.Gender}&adultCount={i.AdultCount}&childCount={i.ChildCount}&infantCount={i.InfantCount}&exclusive={i.Exclusive}&availableStatus={i.AvailableStatus}";
    }
}