using Messages.Data;
using Messages.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Messages.Service
{
    public class MessagesService : IMessagesService
    {
        private readonly MessagesDbContext context;

        public MessagesService(MessagesDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Message> All()
        {
            return context.Messages.ToList();
        }

        public async Task<Message> Create(string content, string username)
        {
            var message = new Message
            {
                CreatedOn = DateTime.UtcNow,
                User = username,
                Content = content
            };

            await context.Messages.AddAsync(message);

            await context.SaveChangesAsync();

            return message;
        }
    }
}
