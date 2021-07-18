using System;
using System.Linq;
using AutoFixture.Kernel;
using Microsoft.Extensions.Logging;

namespace MELT.AutoFixture
{
    /// <summary>
    /// A <see cref="ISpecimenBuilder"/> used to build <see cref="ILogger{TCategoryName}"/> instances.
    /// </summary>
    internal class GenericLoggerSpecimenBuilder : ISpecimenBuilder
    {
        /// <inheritdoc/>
        public object Create(object request, ISpecimenContext context)
        {
            if (!(request is Type t)
             || !t.IsGenericType
             || t.GetGenericTypeDefinition() != typeof(ILogger<>))
            {
                return new NoSpecimen();
            }

            var loggerType = t.GetGenericArguments().Single();

            var loggerFactory = (ILoggerFactory)context.Resolve(typeof(ILoggerFactory));

            if (loggerFactory is null)
            {
                return new NoSpecimen();
            }

            var createLoggerMethod = typeof(LoggerFactoryExtensions).GetMethods()
                                                                    .Where(m => m.Name == "CreateLogger")
                                                                    .Where(m => m.IsGenericMethod)
                                                                    .SingleOrDefault();

            if (createLoggerMethod is null)
            {
                return new NoSpecimen();
            }

            var logger = createLoggerMethod.MakeGenericMethod(loggerType).Invoke(null, new[] { loggerFactory });

            return logger!;
        }
    }
}
