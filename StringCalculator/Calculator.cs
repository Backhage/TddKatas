using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private const string SeparatorIdentifier = "//";

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var separators = new List<char> { ',', '\n' };
            if (ContainsUserDefinedSeparator(input))
            {
                separators.Add(ExtractUserDefinedSeparator(input));
                input = RemoveSeparatorInfo(input);
            }

            IEnumerable<int> values = ExtractValues(input, separators);
            Validate(values);

            return values.Sum();
        }

        private static bool ContainsUserDefinedSeparator(string input)
        {
            return input.StartsWith(SeparatorIdentifier);
        }

        private static char ExtractUserDefinedSeparator(string input)
        {
            return input[SeparatorIdentifier.Length];
        }

        private static string RemoveSeparatorInfo(string input)
        {
            return input.Substring($"{SeparatorIdentifier}.\n".Length);
        }

        private static IEnumerable<int> ExtractValues(string input, List<char> separators)
        {
            return input
                .Split(separators.ToArray())
                .Select(s => int.Parse(s));
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
