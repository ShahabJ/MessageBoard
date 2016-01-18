using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        MessageBoardContext context;
        public MessageBoardRepository(MessageBoardContext context)
        {
            this.context = context;
        }

        public bool AddReply(Reply newReply)
        {
            try
            {
                this.context.Replies.Add(newReply);
                return true;
            }
            catch (Exception)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddTopic(Topic newTopic)
        {
            try
            {
                this.context.Topics.Add(newTopic);
                return true;
            }
            catch (Exception)
            {
                //TODO log this error
                return false;
            }
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return context.Replies.Where(w => w.Id.Equals(topicId));
        }

        public IQueryable<Topic> GetTopics()
        {
            return context.Topics;
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            return context.Topics.Include("Replies");
        }

        public bool Save()
        {
            try
            {
                return this.context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                //TODO log this error
                return false;
            }
        }
    }
}
