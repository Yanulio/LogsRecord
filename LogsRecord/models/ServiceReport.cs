using System.Text;

namespace LogsRecord.models;

public class ServiceReport
{
    private readonly string _serviceName;
    private readonly DateTime _earliestLog;
    private readonly DateTime _latestLog;
    private readonly Dictionary<string, int> _logsCategoryCounter;
    private readonly int _rotationAmount;

    public ServiceReport(
        string serviceName, 
        DateTime earliestLog, 
        DateTime latestLog, 
        Dictionary<string, int> logsCategoryCounter, 
        int rotationAmount)
    {
        this._serviceName = serviceName;
        this._earliestLog = earliestLog;
        this._latestLog = latestLog;
        this._logsCategoryCounter = new Dictionary<string, int>(logsCategoryCounter);
        this._rotationAmount = rotationAmount;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Report:{Environment.NewLine}1. Service name: ");
        sb.Append(_serviceName);
        sb.Append($"{Environment.NewLine}2. Earliest log: ");
        sb.Append(_earliestLog);
        sb.Append($"{Environment.NewLine}3. Latest log: ");
        sb.Append(_latestLog);
        sb.Append($"{Environment.NewLine}4. Number of logs in each category: {Environment.NewLine}");
        foreach (var category in _logsCategoryCounter)
        {
            sb.Append(category.Key);
            sb.Append(": ");
            sb.Append(category.Value);
            sb.Append(Environment.NewLine);
        }
        sb.Append("5. Number of rotations: ");
        sb.Append(_rotationAmount);
        return sb.ToString();
    }
}