using AutoFixture;
using AutoFixture.Kernel;
using MELT;
using Microsoft.Extensions.Logging;

namespace MELT.AutoFixture
{
#pragma warning disable CS0612 // ITestSink/TestSink is obsolete

    /// <summary>
    /// Customizes a fixture with MELT implementations.
    /// </summary>
    public class TestLoggingCustomization : ICustomization
    {
        /// <inheritdoc/>
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new GenericLoggerSpecimenBuilder());

            fixture.Customizations.Add(new TypeRelay(
                from: typeof(ILoggerFactory),
                to: typeof(TestLoggerFactory)));

            fixture.Customizations.Add(new TypeRelay(
                from: typeof(ITestSink),
                to: typeof(TestSink)));

            fixture.Customizations.Add(new TypeRelay(
                from: typeof(ITestLoggerFactory),
                to: typeof(TestLoggerFactory)));

            fixture.Customizations.Add(new TypeRelay(
                from: typeof(ITestLoggerProvider),
                to: typeof(TestLoggerProvider)));

            fixture.Customizations.Add(new TypeRelay(
                from: typeof(IScope),
                to: typeof(Scope)));

            fixture.Customizations.Add(new TypeRelay(
                from: typeof(ITestLoggerSink),
                to: typeof(TestSink)));
        }
    }
}
