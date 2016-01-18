using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoard.Controllers
{
    public class RepliesController : ApiController
    {
        private IMessageBoardRepository repo;

        public RepliesController(IMessageBoardRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Reply> Get(int topicId)
        {
            return repo.GetRepliesByTopic(topicId);
        }

        public HttpResponseMessage Post(int topicId, [FromBody]Reply newReply)
        {
            if (newReply.Created == default(DateTime))
                newReply.Created = DateTime.UtcNow;

            newReply.TopicId = topicId;

            if (repo.AddReply(newReply) && repo.Save())
                return Request.CreateResponse(HttpStatusCode.Created, newReply);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
