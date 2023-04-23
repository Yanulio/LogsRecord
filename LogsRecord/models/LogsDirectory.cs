using System.Text.RegularExpressions;
using LogsRecord.view;

namespace LogsRecord.models;

public class LogsDirectory
{
    private string? _path;
    private readonly Dictionary<string, List<string>> _servicesLogsDictionary;
    public List<ServiceReport> Reports { get; }= new List<ServiceReport>();

    /// <summary>
    /// Constructs the LogsDirectory object and searches through given directory for .log files.
    /// </summary>
    /// <param name="path">directory path</param>
    public LogsDirectory(string? path)
    {
        this._path = path;
        
        DirectoryInfo directory = new DirectoryInfo(path);
        FileInfo[] files = directory.GetFiles("*.log");
        _servicesLogsDictionary = new Dictionary<string, List<string>>();
        foreach (var file in files)
        {
            string serviceName = file.Name.Split('.')[0];
            if (!_servicesLogsDictionary.ContainsKey(serviceName))
            {
                _servicesLogsDictionary[serviceName] = new List<string>();
            }
            _servicesLogsDictionary[serviceName].Add(file.FullName);
        }
    }

    private List<string> GetMatchingServices(string? pattern)
    {
        List<string> matchingServices = new List<string>();
        foreach (var service in _servicesLogsDictionary.Keys)
        {
            if (Regex.IsMatch(service, pattern))
            {
                matchingServices.Add(service);
            }
        }

        return matchingServices;
    }

    private ServiceReport ReadServiceLogs(string service)
    {
        DateTime minDate = DateTime.MaxValue;
        DateTime maxDate = DateTime.MinValue;
        Dictionary<string, int> categoryCounter = new Dictionary<string, int>();
        foreach (var filePath in _servicesLogsDictionary[service])
        {
            try
            {
                using StreamReader file = new StreamReader(filePath);
                string? log;
                while ((log = file.ReadLine()) != null)
                {
                    if (log.Length > 0 && log[0] == '[')
                    {
                        string[] logContents = log.Split(new[] {']', '['}, StringSplitOptions.RemoveEmptyEntries);
                        string logDateStr = logContents[0];
                        string category = logContents[1];
                        if (!categoryCounter.ContainsKey(category))
                        {
                            categoryCounter[category] = 0;
                        }

                        categoryCounter[category] += 1;

                        DateTime logDate = DateTime.Parse(logDateStr);
                        if (logDate > maxDate) maxDate = logDate;
                        if (logDate < minDate) minDate = logDate;
                    }
                }
            }
            catch (IOException ex)
            {
                ConsoleOutput.PrintFileExceptionMessage(ex, filePath);
            }
        }
        ServiceReport report = new ServiceReport(service, 
            minDate, maxDate, categoryCounter,
            _servicesLogsDictionary[service].Count - 1);
        
        return report;
    }
    
    /// <summary>
    /// Gets the matching service names for the pattern and makes a report for each of them.
    /// If there are no matching services, throws the ServiceNotFoundException exception.
    /// </summary>
    /// <param name="pattern">Pattern to match service names to.</param>
    /// <exception cref="ServiceNotFoundException">If there are no matching to the pattern services.</exception>
    public void FillReports(string? pattern)
    {
        List<string> services = GetMatchingServices(pattern);
        
        if (services.Count == 0)
        {
            throw new ServiceNotFoundException("The directory doesn't have any matching log files.");
        }
        
        foreach (var service in services)
        {
            Reports.Add(ReadServiceLogs(service));
        }
    }
}