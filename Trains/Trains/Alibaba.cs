using System.Text;
using System.Text.Json;
using Flurl.Http;
using Trains.Models;

namespace Trains.Trains;

public class Alibaba
{
    private readonly string _apiUrl;
    private const int TimeOutOnSecond = 10;

    public Alibaba(string apiUrl)
    {
        _apiUrl = apiUrl;
    }


    public async Task<bool> IsExist(TrainInfoAlibaba i)
    {
        var url = GenerateUrl(i);

        try
        {
            var headers = new Dictionary<string, string>
            {
                { "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7" },
                { "Accept-Encoding", "gzip, deflate, br, zstd" },
                { "Accept-Language", "en-US,en;q=0.9,fa;q=0.8" },
                { "Cache-Control", "max-age=0" },
                { "Connection", "keep-alive" },
                {
                    "Cookie",
                    "TS01b4a14d=011f5aef9e40fe42d3d8a4986138d40868217813daa31292709f1fa9484ced7a7f1d30d4977e6da2a1756dad3b24b567e31c861ab9; TS4c57d03c027=0868248ad2ab20001cdeaa57c1b3c58a140a819d0b385f93a7d8ce72a54900dad0d8a2cb04f8a8b208d5cd4e6c113000d20a1440a0963f7103372407ff70041f40ba5da7cd8cbe6d09d568d2aa72381cf87643f12d8639e172d783cb847c1602"
                },
                { "DNT", "1" },
                { "Host", "ws.alibaba.ir" },
                { "Sec-Fetch-Dest", "document" },
                { "Sec-Fetch-Mode", "navigate" },
                { "Sec-Fetch-Site", "none" },
                { "Sec-Fetch-User", "?1" },
                { "Upgrade-Insecure-Requests", "1" },
                { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36" },
                { "sec-ch-ua", "\"Not A(Brand\";v=\"8\", \"Chromium\";v=\"132\", \"Google Chrome\";v=\"132\"" },
                { "sec-ch-ua-mobile", "?0" },
                { "sec-ch-ua-platform", "\"Windows\"" }
            };


            var data = await url
                .WithHeaders(headers)
                .WithTimeout(TimeSpan.FromSeconds(TimeOutOnSecond))
                .GetJsonAsync<ResponseInfoAlibaba.RootAlibaba>()
                .ConfigureAwait(false);

            if (data.result.departing.Any(a => a.badges.Any() && a.badges.Count > 0))
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

    private string GenerateUrl(TrainInfoAlibaba i)
    {
        var data = JsonSerializer.Serialize(i);
        var hashed = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

        return
            $"{_apiUrl}{hashed}";
    }
}