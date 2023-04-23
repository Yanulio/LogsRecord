namespace LogsRecord.services;

public static class DataValidator
{
    public static bool IsPathCorrect(string? path)
    {
        if (path is null) return false;

        return Directory.Exists(path);
    }

    public static bool IsPatternCorrect(string? path)
    {
        return path is not null;
    }
}