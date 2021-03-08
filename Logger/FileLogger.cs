using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private readonly string FilePath;

        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        public override void Log(LogLevel log, string message)
        {
            using (StreamWriter streamWriter = File.AppendText(FilePath))
            {
                streamWriter.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + ' ' + ClassName + ' ' + Enum.GetName(typeof(LogLevel), log) + ": " + message);
            }
        }
    }
}
