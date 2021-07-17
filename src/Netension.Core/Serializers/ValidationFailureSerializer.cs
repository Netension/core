using Netension.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace Netension.Exceptions
{
    public static class ValidationFailureSerializer
    {
        public static string Serialize(IEnumerable<ValidationFailure> failures)
        {
            using var stream = new MemoryStream();
            new ValidationFailureFormatter().Serialize(stream, failures);

            return new StreamReader(stream).ReadToEnd();
        }

        public static async Task<string> SerializeAsync(IEnumerable<ValidationFailure> failures, CancellationToken cancellationToken)
        {
            using var stream = new MemoryStream();
            new ValidationFailureFormatter().Serialize(stream, failures);

            cancellationToken.ThrowIfCancellationRequested();

            return await new StreamReader(stream).ReadToEndAsync().ConfigureAwait(false);
        }

        public static IEnumerable<ValidationFailure> Deserialize(string value)
        {
            return from line in value.Split(Environment.NewLine)
                   select line.Deserialize();
        }

        public static Task<IEnumerable<ValidationFailure>> DeserializeAsync(string value, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(from line in value.Split(Environment.NewLine)
                                   select line.Deserialize());
        }
    }
}
