namespace LogsRecord.models;

/// <summary>
/// Exception class for dealing with situations where there are no services for us to report about.
/// </summary>
public class ServiceNotFoundException : Exception
{
    public ServiceNotFoundException() : base() { }
    public ServiceNotFoundException(string message) : base(message) { }
    public ServiceNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
}