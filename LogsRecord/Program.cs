using LogsRecord.controllers;
using LogsRecord.models;
using LogsRecord.services;
using LogsRecord.view;

namespace LogsRecord;

static class Program
{
    static void Main(string[] args)
    {
        string? directoryPath;
        while (true)
        {
            ConsoleOutput.PrintInputPathMessage();
            directoryPath = ConsoleUserInput.GetStringFromConsole();
            if (DataValidator.IsPathCorrect(directoryPath)) break;
            ConsoleOutput.PrintWrongPathMessage();
        }
        LogsDirectory directory = new LogsDirectory(directoryPath);
        
        string? pattern;
        while (true)
        {
            ConsoleOutput.PrintInputPatternMessage();
            pattern = ConsoleUserInput.GetStringFromConsole();
            if (DataValidator.IsPatternCorrect(pattern)) break;
            ConsoleOutput.PrintWrongPatternMessage();
        }

        try
        {
            directory.FillReports(pattern);
            ConsoleOutput.PrintReports(directory.Reports);
        }
        catch (ServiceNotFoundException ex)
        {
            ConsoleOutput.PrintExceptionMessage(ex);
        }
    }
}