using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using MTServerless.Helpers;
using MTServerless.Relations;

namespace MTServerless
{
    public static class RemoveColumn
    {
        [FunctionName("RemoveColumn")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var generator = new Generator.Generator(HttpRequestParser.ParseGeneratorSettings(req));
            var data = generator.Generate();
            var relation = new RemoveColumnRelation();

            return new OkObjectResult(relation.Validate(data));
        }
    }
}
