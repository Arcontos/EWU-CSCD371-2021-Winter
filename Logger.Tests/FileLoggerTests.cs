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
                fileLogger.Debug("Debug Message {0}", 4);
                fileLogger.Information("Information Message {0}", 3);
                fileLogger.Warning("Warning Message {0}", 2);
                fileLogger.Error("Error Message {0}", 1);
                string[] fileContents = File.ReadAllLines(filePath);

                // Assert
                Assert.AreEqual(fileContents.Length, 4);
                Assert.IsTrue(fileContents[0].Contains("Debug Message 4"));
                Assert.IsTrue(fileContents[1].Contains("Information Message 3"));
                Assert.IsTrue(fileContents[2].Contains("Warning Message 2"));
                Assert.IsTrue(fileContents[3].Contains("Error Message 1"));
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
