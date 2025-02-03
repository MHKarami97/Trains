using Trains;
using Trains.Models;
using Trains.Trains;

class Program
{
    static async Task Main()
    {
        const int waitOnSecond = 10;
        Console.WriteLine("Program started...");
        const string apiUrlMrBlit = "https://train.mrbilit.com/api/GetAvailable/v2";
        const string apiUrlAlibaba = "https://ws.alibaba.ir/api/v2/train/available/";

        var mrBlit = new MrBlit(apiUrlMrBlit);
        var alibaba = new Alibaba(apiUrlAlibaba);

        using var cts = new CancellationTokenSource();
        var token = cts.Token;

        Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.S)
                {
                    cts.Cancel();
                }
            }
        });

        Console.WriteLine("Press 's' to stop");
        Console.WriteLine("-----------------");

        try
        {
            var counter = 0;

            var trainInfoMrBlit = new TrainInfoMrBlit
            {
                From = 1,
                To = 37,
                Date = new DateTime(2025, 02, 06),
                AdultCount = 2
            };

            var trainInfoAlibaba = new TrainInfoAlibaba
            {
                From = 1,
                To = 37,
                DepartureDate = new DateTime(2025, 02, 06),
                PassengerCount = 2
            };

            while (!token.IsCancellationRequested)
            {
                var resultMrBlitTask = mrBlit.IsExist(trainInfoMrBlit);

                var resultAlibabaTask = alibaba.IsExist(trainInfoAlibaba);

                await Task.WhenAll(resultMrBlitTask, resultAlibabaTask);

                var resultMrBlit = await resultMrBlitTask;
                var resultAlibaba = await resultAlibabaTask;

                if (resultMrBlit)
                {
                    Helper.Alert("MrBlit");
                }

                if (resultAlibaba)
                {
                    Helper.Alert("Alibaba");
                }

                Console.WriteLine($"Id: {++counter}, Time: {DateTime.Now:HH:mm:ss.fff}");

                await Task.Delay(TimeSpan.FromSeconds(waitOnSecond), token);
            }
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("\nStopping...");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            Console.WriteLine("Any key to close...");
            Console.ReadKey();
        }
    }
}