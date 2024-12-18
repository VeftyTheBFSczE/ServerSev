using System;
using System.IO;

public static class Logger
{
    private static readonly object _lock = new object();

    public static void Log(string message, string level = "INFO")
    {
        lock (_lock)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} [{level}]: {message}");
            }
        }
    }

    public static void LogError(string message)
    {
        Log(message, "ERROR");
    }
}
