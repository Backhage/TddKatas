using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        private const string DelimiterIdentifier = "//";
        private const int FilterOutValuesAbove = 1000;

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };
            if (ContainsDelimiters(input))
            {
                delimiters.AddRange(ExtractDelimiters(input));
                input = RemoveDelimiters(input);
            }

            IEnumerable<int> values = ExtractValues(input, delimiters);
            Validate(values);

            return values.Sum();
        }

        private static bool ContainsDelimiters(string input)
        {
            return input.StartsWith(DelimiterIdentifier);
        }

        private static List<string> ExtractDelimiters(string input)
        {
            var delimiterInfo = input.Substring(DelimiterIdentifier.Length, input.IndexOf('\n') - DelimiterIdentifier.Length);
            var delimiters = new List<string>();
            if (delimiterInfo.Contains('['))
            {
                delimiters.AddRange(ExtractBrackedDelimiters(delimiterInfo));
            }
            else
            {
                delimiters.Add(delimiterInfo);
            }
            return delimiters;
        }

        private static List<string> ExtractBrackedDelimiters(string delimiterInfo)
        {
            var delimiters = new List<string>();
            while (delimiterInfo.Contains('['))
            {
                var delimiter = delimiterInfo.Substring(1, delimiterInfo.IndexOf(']') - 1);
                delimiters.Add(delimiter);
                delimiterInfo = delimiterInfo.Substring(1);
                if (delimiterInfo.Contains('['))
                {
                    delimiterInfo = delimiterInfo.Substring(delimiterInfo.IndexOf('['));
                }
            }

            return delimiters;
        }

        private static string RemoveDelimiters(string input)
        {
            return input.Substring(input.IndexOf('\n') + 1);
        }

        private static IEnumerable<int> ExtractValues(string input, List<string> separators)
        {
            return input
                .Split(separators.ToArray(), StringSplitOptions.None)
                .Select(s => int.Parse(s))
                .Where(n => n <= FilterOutValuesAbove);
        }

        private static void Validate(IEnumerable<int> values)
        {
            var negatives = values.Where(n => n < 0);
            if (negatives.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {negatives.ToArray()}");
            }
        }
    }
}
