using MTServerless.Artifact;
using System;
using System.Linq;

namespace MTServerless.Relations
{
    public class TopOneAbsentRelation
    {
        public bool Validate(string query)
        {
            var searchEngine = new DuckDuckGo();
            var sourceResponse = searchEngine.Query(query);
            var followUpQuery = query + $" site:{sourceResponse[0].Url.Host}";
            var followUpResponse = searchEngine.Query(followUpQuery);

            return followUpResponse.Any(x => x.Url.Equals(sourceResponse[0].Url));
        }
    }
}
