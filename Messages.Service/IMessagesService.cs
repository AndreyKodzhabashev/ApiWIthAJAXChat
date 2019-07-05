using Messages.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Service
{
    public interface IMessagesService
    {

        IEnumerable<Message> All();

        Task<Message> Create(string content, string username);
    }
}
