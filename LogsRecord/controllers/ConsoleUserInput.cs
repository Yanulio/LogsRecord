namespace LogsRecord.controllers;

public static class ConsoleUserInput
{
    public static string? GetStringFromConsole()
    {
        string? path = Console.ReadLine();
        if (path is not null)
        {
            return path.Trim();
        }
        return path;
    }
}