using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_NullFilePath()
        { 
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            BaseLogger baseLogger = logFactory.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsNull(baseLogger);
        }

        [TestMethod]
        public void CreateLogger_WithFilePath()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            logFactory.ConfigureFileLogger(Path.GetRandomFileName());
            BaseLogger baseLogger = logFactory.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsNotNull(baseLogger);
        }
    }
}
