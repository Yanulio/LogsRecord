namespace LogsRecord.controllers;

public static class ConsoleUserInput
{
    /// <summary>
    /// Gets a line user printed in console and trims it if its not a null.
    /// </summary>
    /// <returns>The users input string</returns>
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