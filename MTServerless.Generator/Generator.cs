using System;

namespace MTServerless.Generator
{
    public class Generator
    {
        public string Generate(int id) => id switch
        {
            1 => "\"side effect of antibiotics in babies\"",
            2 => "\"tempted peaceably\"",
            3 => "\"Vincent Van Gogh\" \"Elvis Presley\" \"Albert Einstein\" \"Plato\"",
            4 => "Amsterdam tomorrow",
            5 => "\"stanford\"",
            _ => throw new ArgumentOutOfRangeException(nameof(id))
        };
    }
}
