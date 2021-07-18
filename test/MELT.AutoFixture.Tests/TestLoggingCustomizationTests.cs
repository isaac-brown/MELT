using Xunit;
using AutoFixture;
using Microsoft.Extensions.Logging;

namespace MELT.AutoFixture.Tests
{
#pragma warning disable CS0612 // ITestSink/TestSink is obsolete

    /// <summary>
    /// Unit tests for the <see cref="TestLoggingCustomization"/> class.
    /// </summary>
    public class TestLoggingCustomizationTests
    {
        [Fact]
        public void CustomizedFixture_ShouldCreateGenericLogger()
        {
            // Arrange.
            IFixture sut = new Fixture();
            sut.Customize(new TestLoggingCustomization());

            // Act.
            var logger = sut.Create<ILogger<Fixture>>();

            // Assert.
            Assert.IsType<Logger<Fixture>>(logger);
        }

        [Fact]
        public void CustomizedFixture_ShouldCreateTestSink()
        {
            // Arrange.
            IFixture sut = new Fixture();
            sut.Customize(new TestLoggingCustomization());

            // Act.
            var sink = sut.Create<ITestSink>();

            // Assert.
            Assert.IsType<TestSink>(sink);
        }

        [Fact]
        public void CustomizedFixture_ShouldCreateTestLoggerFactory()
        {
            // Arrange.
            IFixture sut = new Fixture();
            sut.Customize(new TestLoggingCustomization());

            // Act.
            var factory = sut.Create<ITestLoggerFactory>();

            // Assert.
            Assert.IsType<TestLoggerFactory>(factory);
        }

        [Fact]
        public void CustomizedFixture_ShouldCreateTestLoggerProvider()
        {
            // Arrange.
            IFixture sut = new Fixture();
            sut.Customize(new TestLoggingCustomization());

            // Act.
            var loggerProvider = sut.Create<ITestLoggerProvider>();

            // Assert.
            Assert.IsType<TestLoggerProvider>(loggerProvider);
        }

        [Fact]
        public void CustomizedFixture_ShouldCreateTestLoggerSink()
        {
            // Arrange.
            IFixture sut = new Fixture();
            sut.Customize(new TestLoggingCustomization());

            // Act.
            var scope = sut.Create<ITestLoggerSink>();

            // Assert.
            Assert.IsType<TestSink>(scope);
        }
    }
}
