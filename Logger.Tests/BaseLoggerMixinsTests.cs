using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null, "");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Warning(null, "");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Information(null, "");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Debug(null, "");

            // Assert
        }

        [TestMethod]
        [DataRow(LogLevel.Error)]
        [DataRow(LogLevel.Warning)]
        [DataRow(LogLevel.Information)]
        [DataRow(LogLevel.Debug)]
        public void WithData_LogsMessage(LogLevel loglevel)
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            switch (loglevel)
            {
                case LogLevel.Error:
                    logger.Error("Message {0}", 42);
                    break;
                case LogLevel.Warning:
                    logger.Warning("Message {0}", 42);
                    break;
                case LogLevel.Information:
                    logger.Information("Message {0}", 42);
                    break;
                case LogLevel.Debug:
                    logger.Debug("Message {0}", 42);
                    break;
                default:
                    break;
            }
            
            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(loglevel, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }
    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
