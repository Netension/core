using AutoFixture;
using Netension.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Netension.Core.UnitTest.Formatters
{
    public class ValidationFailureFormatter_Test
    {
        private ValidationFailureFormatter CreateSUT()
        {
            return new ValidationFailureFormatter();
        }

        [Fact(DisplayName = "[VFS001][Success]: Serilaize validation failures")]
        [Feature("EH - Exception handling")]
        public void Serialize_ValidationFailures()
        {
            // Arrange
            var sut = CreateSUT();
            var failures = new Fixture().CreateMany<ValidationFailure>();
            var stream = new MemoryStream();

            // Act
            sut.Serialize(stream, failures);

            // Assert
            Assert.Equal(failures, stream.ReadFromValidationFailures());
        }

        [Fact(DisplayName = "[VFS002][Exception]: Stream is null")]
        [Feature("EH - Exception handling")]
        public void Serialize_StreamIsNull()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => sut.Serialize(null, new Fixture().CreateMany<ValidationFailure>()));
        }

        [Fact(DisplayName = "[VFS003][Success]: Graph is null")]
        [Feature("EH - Exception handling")]
        public void Serialize_GraphIsNull()
        {
            // Arrange
            var sut = CreateSUT();
            var stream = new MemoryStream();

            // Act
            sut.Serialize(stream, null);

            // Assert
            Assert.Equal(0, stream.Length);
        }

        [Fact(DisplayName = "[VFS004][Exception]: Graph is not IEnumerable<ValidationFailure>")]
        [Feature("EH - Exception handling")]
        public void Serialize_InvalidGrap()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            // Assert
            Assert.Throws<NotSupportedException>(() => sut.Serialize(new MemoryStream(), new object()));
        }

        [Fact(DisplayName = "[VFS005][Success]: Deserialize IEnumerable<ValidationFailure>")]
        [Feature("EH - Exception handling")]
        public void Deserialize_ValidationFailures()
        {
            // Arrange
            var sut = CreateSUT();
            var failures = new Fixture().CreateMany<ValidationFailure>();
            var stream = new MemoryStream().Write(failures);

            // Act
            var result = sut.Deserialize(stream);

            // Assert
            Assert.Equal(failures, result);
        }

        [Fact(DisplayName = "[VFS006][Exception]: Stream is null")]
        [Feature("EH - Exception handling")]
        public void Deserialize_StreamIsNull()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => sut.Deserialize(null));
        }

        [Fact(DisplayName = "[VFS007][Exception]: Stream is empty")]
        [Feature("EH - Exception handling")]
        public void Deserialize_StreamIsEmpty()
        {
            // Arrange
            var sut = CreateSUT();

            // Act
            var result = sut.Deserialize(new MemoryStream());

            // Assert
            Assert.NotNull(result);
        }
    }

    public static class ValidationFailureFormatterExtensions
    {
        public static MemoryStream Write(this MemoryStream stream, IEnumerable<ValidationFailure> failures)
        {
            using var streamWriter = new StreamWriter(stream, leaveOpen: true);
            foreach (var failure in failures)
            {
                streamWriter.WriteLine(failure.Serialize());
            }
            streamWriter.Flush();
            stream.Position = 0;

            return stream;
        }

        public static IEnumerable<ValidationFailure> ReadFromValidationFailures(this Stream stream)
        {
            using var streamReader = new StreamReader(stream);

            var propertyRegex = new Regex(@"{[\w-_]+}");
            var codeRegex = new Regex(@"#[\d]+");
            var messageRegex = new Regex(@"\[.+\]");

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                yield return new ValidationFailure(
                    propertyRegex.Match(line).Value.TrimStart('{').TrimEnd('}'),
                    int.Parse(codeRegex.Match(line).Value.TrimStart('#')),
                    messageRegex.Match(line).Value.TrimStart('[').TrimEnd(']'));
            }
        }
    }
}
