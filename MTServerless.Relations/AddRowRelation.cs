using MTServerless.Models.Input;
using System;
using System.IO;
using YetAnotherConsoleTables;

namespace MTServerless.Relations
{
    public class AddRowRelation : IRelation
    {
        public bool Validate(TableItem[] input)
        {
            var metamorphedInput = new TableItem[input.Length + 1];
            Array.Copy(input, metamorphedInput, input.Length);
            metamorphedInput[input.Length] = new TableItem();

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

            return metamorphedStrings.Length == originalStrings.Length + 2;
        }
    }
}
