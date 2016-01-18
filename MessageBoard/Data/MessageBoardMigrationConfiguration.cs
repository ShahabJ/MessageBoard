using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MessageBoard.Data
{
    public class MessageBoardMigrationConfiguration : DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);
#if DEBUG
            if (context.Topics.Count() == 0)
            {
                var topic = new Topic
                {
                    Title = "I love MVC",
                    Created = DateTime.Now,
                    Body="I love ASP.NET MVC and want to learn everything about it",
                    Replies =new List<Reply>
                    {
                        new Reply()
                        {
                            Body="I love MVC too",
                            Created=DateTime.Now
                        },
                        new Reply()
                        {
                            Body="OH no",
                            Created=DateTime.Now
                        }
                    }
                };

                context.Topics.Add(topic);

                var anotherTopic = new Topic
                {
                    Title = "I love C#",
                    Created = DateTime.Now,
                    Body = "I love C# and want to learn everything about it",
                };

                context.Topics.Add(anotherTopic);


                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    var msg = ex.Message;
                }


            }
#endif
        }
    }
}