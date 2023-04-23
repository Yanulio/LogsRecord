using LogsRecord.models;

namespace LogsRecord.view;

public static class ConsoleOutput
{
    public static void PrintInputPathMessage()
    {
        Console.WriteLine("Please, enter a path to the logs directory: ");
    }
    public static void PrintInputPatternMessage()
    {
        Console.WriteLine("Please, enter a pattern of service name to search for: ");
    }
    public static void PrintWrongPathMessage()
    {
        Console.WriteLine("The path to directory is incorrect, please, try again!");
    }
    
    public static void PrintWrongPatternMessage()
    {
        Console.WriteLine("The pattern you tried to enter is incorrect, please, try again!");
    }

    public static void PrintReports(List<ServiceReport> reports)
    {
        foreach (var report in reports)
        {
            Console.WriteLine(report.ToString() + Environment.NewLine);
        }
    }

    public static void PrintExceptionMessage(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    public static void PrintFileExceptionMessage(Exception ex, string path)
    {
        Console.WriteLine($"An error occured while reading file {path}:");
        Console.WriteLine(ex.Message);
    }
}