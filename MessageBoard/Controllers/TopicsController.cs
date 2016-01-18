using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoard.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository repo;

        public TopicsController(IMessageBoardRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Topic> Get(bool includeReplies = false)
        {
            IEnumerable<Topic> result;

            result = includeReplies ? repo.GetTopicsIncludingReplies() : repo.GetTopics();
            return result.OrderByDescending(o => o.Created).Take(50).ToList();
        }

        public HttpResponseMessage Post([FromBody] Topic newTopic)
        {
            if (newTopic.Created == default(DateTime))
            {
                newTopic.Created = DateTime.UtcNow;
            }

            if (repo.AddTopic(newTopic) && repo.Save())
                return Request.CreateResponse(HttpStatusCode.Created, newTopic);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
