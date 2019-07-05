
using ApiWIthAJAXChat.Models.BindingModels;
using Messages.Domain;
using Messages.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiWIthAJAXChat.Controllers
{
    public class MessagesController : MyApiController
    {
        private readonly IMessagesService service;

        public MessagesController(IMessagesService service)
        {
            this.service = service;
        }

        [HttpGet(Name = "All")]
        [Route("all")]
        public IEnumerable<Message> All()
        {
            var allMessages = service.All().OrderBy(x => x.CreatedOn);
            //this.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return allMessages;
        }

        [HttpPost(Name = "Create")]
        [Route("Create")]
        public ActionResult<Message> Create([FromBody]MessagesCreateBindingModel message)
        {
            var addedMessage = service.Create(message.Content, message.Username).GetAwaiter().GetResult();
            return addedMessage;
        }
    }
}
