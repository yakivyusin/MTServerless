using MTServerless.Models.Input;
using System;
using System.IO;
using System.Linq;
using YetAnotherConsoleTables;

namespace MTServerless.Relations
{
    public class AddColumnRelation : IRelation
    {
        private const string NewValue = "New";

        public bool Validate(TableItem[] input)
        {
            var metamorphedInput = input
                .Select(x => new
                {
                    x.C1,
                    x.C2,
                    x.C3,
                    C4 = NewValue
                })
                .ToArray();

            var originalOutput = new StringWriter();
            var metamorphedOutput = new StringWriter();

            ConsoleTable.From(input).Write(originalOutput);
            ConsoleTable.From(metamorphedInput).Write(metamorphedOutput);

            return ValidateLengths(originalOutput, metamorphedOutput);
        }

        private bool ValidateLengths(StringWriter original, StringWriter metamorphed)
        {
            var originalStrings = original
                .ToString()
                .Split(original.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var metamorphedStrings = metamorphed
                .ToString()
                .Split(metamorphed.NewLine, StringSplitOptions.RemoveEmptyEntries);

            return originalStrings
                .Zip(metamorphedStrings)
                .All(x => x.Second.Length == x.First.Length + 3 + NewValue.Length);
        }
    }
}
