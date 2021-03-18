using System;
using System.Collections.Generic;

namespace mini_server
{
    public class MessageService
    {
        public Dictionary<int,string> messages { get; set; }
        public MessageService(){
            messages = new Dictionary<int,string>();
            messages.Add(1,"Hola");
            messages.Add(2,"Mundo");
        }

        public void AddMessage(string val){
            
            messages.Add(messages.Count+1, val);
        }
        
        public IEnumerable<MessageModel> GetMessages()
        {
            List<MessageModel> res = new List<MessageModel>();
            foreach(var item in messages)
                res.Add(new MessageModel(item.Key,item.Value));
            
            return res;
        }
    }
}
