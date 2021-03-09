using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string FilePath { get; }

        public FileLogger(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public override void Log(LogLevel log, string message)
        {
            using StreamWriter streamWriter = File.AppendText(FilePath);
            streamWriter.WriteLine($"{DateTime.Now:\"MM / dd / yyyy hh: mm:ss tt\"} {ClassName} {log}: {message}");
        }
    }
}
