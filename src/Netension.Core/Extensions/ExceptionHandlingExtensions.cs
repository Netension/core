using System.Text.RegularExpressions;

namespace Netension.Exception
{
    public static class ExceptionHandlingExtensions
    {
        public static string Serialize(this ValidationFailure failure) => $"{{{failure.Property}}}: #{failure.Code} - [{failure.Message}]";
        public static ValidationFailure Deserialize(this string value)
        {
            return new(
                new Regex(@"{[\w-_]+}").Match(value).Value.TrimStart('{').TrimEnd('}'),
                int.Parse(new Regex(@"#[\d]+").Match(value).Value.TrimStart('#')),
                new Regex(@"\[.+\]").Match(value).Value.TrimStart('[').TrimEnd(']'));
        }
    }
}
