using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Netension.Exception
{
    public class ValidationFailureFormatter : IFormatter
    {
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }

        public object Deserialize(Stream serializationStream)
        {
            if (serializationStream is null) throw new ArgumentNullException(nameof(serializationStream));

            var result = new List<ValidationFailure>();

            using var streamReader = new StreamReader(serializationStream);
            while (!streamReader.EndOfStream)
            {
                result.Add(streamReader.ReadLine().Deserialize());
            }

            return result;
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            if (serializationStream is null) throw new ArgumentNullException(nameof(serializationStream));
            if (graph == null) return;
            if (graph is not IEnumerable<ValidationFailure> failures) throw new NotSupportedException($"{graph.GetType()} is not supported!");

            using var streamWriter = new StreamWriter(serializationStream, leaveOpen: true);
            foreach (var failure in failures)
            {
                streamWriter.WriteLine(failure.Serialize());
            }
            streamWriter.Flush();
            serializationStream.Position = 0;
        }
    }
}
