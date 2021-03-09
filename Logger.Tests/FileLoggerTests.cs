using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_CreateFile()
        {
            // Arrange
            string filePath = Path.GetRandomFileName();

            try
            {
                // Act
                FileLogger fileLogger = new FileLogger(filePath);
                fileLogger.Debug("Debug Message");

                // Assert
                Assert.IsTrue(File.Exists(filePath));
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void Log_LogMessage()
        {
            // Arrange
            string filePath = Path.GetRandomFileName();

            try
            {
                // Act
                FileLogger fileLogger = new FileLogger(filePath);
                fileLogger.Log(LogLevel.Debug, "Debug Message 4");
                string[] fileContents = File.ReadAllLines(filePath);

                // Assert
                Assert.AreEqual(fileContents.Length, 1);
                Assert.IsTrue(fileContents[0].Contains("Debug Message 4"));
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
