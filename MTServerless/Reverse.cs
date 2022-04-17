using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MTServerless.Relations;
using System.Threading.Tasks;

namespace MTServerless
{
    public static class Reverse
    {
        [FunctionName("Reverse")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var generator = new Generator.Generator();
            var data = generator.Generate(3);
            var relation = new ReverseRelation();

            return new OkObjectResult(relation.Validate(data));
        }
    }
}
