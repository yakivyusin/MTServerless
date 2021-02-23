using MTServerless.Models.Input;
using System;
using System.IO;
using System.Linq;
using YetAnotherConsoleTables;

namespace MTServerless.Relations
{
    public class ReverseRelation : IRelation
    {
        public bool Validate(TableItem[] input)
        {
            var metamorphedInput = input.Reverse().ToArray();

            var originalOutput = new StringWriter();
            var metamorphedOutput = new StringWriter();

            ConsoleTable.From(input).Write(originalOutput);
            ConsoleTable.From(metamorphedInput).Write(metamorphedOutput);

            return ValidateItemsOrder(originalOutput, metamorphedOutput, input.Length);
        }

        private bool ValidateItemsOrder(StringWriter original, StringWriter metamorphed, int itemsCount)
        {
            var originalStrings = original
                .ToString()
                .Split(original.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var metamorphedStrings = metamorphed
                .ToString()
                .Split(metamorphed.NewLine, StringSplitOptions.RemoveEmptyEntries);

            bool result = true;

            for (int i = 0; i < itemsCount; i++)
            {
                var originalString = originalStrings[3 + 2 * i];
                var metamorphedString = metamorphedStrings[3 + 2 * (itemsCount - i - 1)];

                result &= originalString == metamorphedString;
            }

            return result;
        }
    }
}
