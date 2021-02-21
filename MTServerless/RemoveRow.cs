using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using MTServerless.Helpers;
using MTServerless.Relations;

namespace MTServerless
{
    public static class RemoveRow
    {
        [FunctionName("RemoveRow")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var generator = new Generator.Generator(HttpRequestParser.ParseGeneratorSettings(req));
            var data = generator.Generate();
            var relation = new RemoveRowRelation();

            return new OkObjectResult(relation.Validate(data));
        }
    }
}
