using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mini_server.Commands;

namespace mini_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {

        private MessageService _messageService;

        public MessagesController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IEnumerable<MessageModel> Get()
        {
            return _messageService.GetMessages();
        }

        [HttpGet("{id}")]
        public MessageModel GetById([FromRoute] int id)
        {
            string res =  _messageService.messages[id];
            return new MessageModel(id,res);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMessageCommand cmd)
        {
            _messageService.AddMessage(cmd.message);
            return NoContent();
        }

        [HttpPut("{id}")]
        public MessageModel Put([FromRoute] int id,[FromBody] CreateMessageCommand cmd)
        {
            _messageService.messages[id]=cmd.message;
            return new MessageModel(id, _messageService.messages[id]);
        }
        
        [HttpDelete("{id}")]
        public MessageModel Delete([FromRoute] int id)
        {
            MessageModel res =  new MessageModel(id, _messageService.messages[id]);
            _messageService.messages.Remove(id);
            return res;
        }
    }
}
