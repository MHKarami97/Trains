using Console = System.Console;

namespace Trains;

public class Helper
{
    public static void Alert(string provider)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();

        Console.WriteLine("!!! TRAIN AVAILABLE !!!");
        Console.WriteLine(provider);

        for (var i = 0; i < 100; i++)
        {
            Console.Beep(1000, 500);
            Thread.Sleep(500);
        }
    }
}