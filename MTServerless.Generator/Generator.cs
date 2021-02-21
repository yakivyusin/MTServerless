using MTServerless.Models.Generator;
using MTServerless.Models.Input;
using System;

namespace MTServerless.Generator
{
    public class Generator
    {
        private readonly Random _random;
        private readonly int _count;

        public Generator(GeneratorModel model)
        {
            _random = new Random(model.Seed.GetHashCode());
            _count = model.ItemsCount;
        }

        public TableItem[] Generate()
        {
            var result = new TableItem[_count];

            for (int i = 0; i < _count; i++)
            {
                result[i] = new TableItem
                {
                    C1 = _random.Next(1000, 9999),
                    C2 = _random.NextDouble().ToString("0.0000"),
                    C3 = "Default"
                };
            };

            return result;
        }
    }
}
