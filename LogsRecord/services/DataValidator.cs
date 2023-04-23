namespace LogsRecord.services;

public static class DataValidator
{
    /// <summary>
    /// Checks if the given directory path exists.
    /// </summary>
    /// <param name="path">Directory path</param>
    /// <returns>True if the directory exists. False otherwise.</returns>
    public static bool IsPathCorrect(string? path)
    {
        if (path is null) return false;

        return Directory.Exists(path);
    }

    /// <summary>
    /// Checks if the pattern is null or not.
    /// </summary>
    /// <param name="pattern">Service name pattern</param>
    /// <returns>True if pattern is not null. False otherwise.</returns>
    public static bool IsPatternCorrect(string? pattern)
    {
        return pattern is not null;
    }
}