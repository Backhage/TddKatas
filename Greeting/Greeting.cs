using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greeting
{
    public static class Greeting
    {
        public static string Greet(params string[] names)
        {
            if (names == null)
            {
                return DefaultGreeting();
            }
            return GenerateGreeting(names);
        }

        private static string DefaultGreeting()
        {
            return "Hello, my friend.";
        }

        private static string GenerateGreeting(string[] names)
        {
            var upperCaseNames = names.Where(s => s.All(char.IsUpper)).ToList();
            var regularCaseNames = names.Except(upperCaseNames).ToList();
            var greeting = new StringBuilder();

            AddNormalCaseGreeting(regularCaseNames, greeting);

            if (regularCaseNames.Any() && upperCaseNames.Any())
            {
                greeting.Append(" AND ");
            }

            AddUpperCaseGreeting(upperCaseNames, greeting);

            return greeting.ToString();
        }

        private static void AddNormalCaseGreeting(List<string> names, StringBuilder greeting)
        {
            if (names.Count == 0) return;

            greeting.Append("Hello, ");
            greeting.Append(names.First());

            if (names.Count > 2)
            {
                AddCommaSeparated(names, greeting);
            }

            if (names.Count > 1)
            {
                greeting.Append(" and ");
                greeting.Append(names.Last());
            }

            greeting.Append(".");
        }

        private static void AddUpperCaseGreeting(List<string> names, StringBuilder greeting)
        {
            if (names.Count == 0) return;

            greeting.Append("HELLO ");
            greeting.Append(names.First());

            if (names.Count > 2)
            {
                AddCommaSeparated(names, greeting);
            }

            if (names.Count > 1)
            {
                greeting.Append(" AND ");
                greeting.Append(names.Last());
            }

            greeting.Append("!");
        }

        private static void AddCommaSeparated(List<string> names, StringBuilder greeting)
        {
            greeting.Append(",");
            for (var nameIndex = 1; nameIndex < names.Count - 1; nameIndex++)
            {
                greeting.Append(" ");
                greeting.Append(names[nameIndex]);
                greeting.Append(",");
            }
        }
    }
}
