namespace Logger
{
    public class LogFactory
    {
        private string? FilePath { get; set; }

        public BaseLogger? CreateLogger(string className)
        {
            if (FilePath is null)
            {
                return null;
            }

            return new FileLogger(FilePath)
            {
                ClassName = className
            };
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }
    }
}
