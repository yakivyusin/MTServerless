using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MTServerless.Models.Generator;
using MTServerless.Relations;
using System;

namespace MTServerless
{
    public static class AddColumn
    {
        [FunctionName("AddColumn")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var generatorModel = new GeneratorModel
            {
                Seed = Guid.Parse(req.Query["seed"]),
                ItemsCount = int.Parse(req.Query["count"])
            };
            var generator = new Generator.Generator(generatorModel);
            var data = generator.Generate();
            var relation = new AddColumnRelation();

            return new OkObjectResult(relation.Validate(data));
        }
    }
}
