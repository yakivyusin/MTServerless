using Microsoft.AspNetCore.Http;
using MTServerless.Models.Generator;
using System;

namespace MTServerless.Helpers
{
    public static class HttpRequestParser
    {
        public static GeneratorModel ParseGeneratorSettings(HttpRequest request)
        {
            return new GeneratorModel
            {
                Seed = Guid.Parse(request.Query["seed"]),
                ItemsCount = int.Parse(request.Query["count"])
            };
        }
    }
}
