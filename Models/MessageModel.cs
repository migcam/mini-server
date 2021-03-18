using System;

namespace mini_server
{
    public class MessageModel
    {
        public int msgId { get; set; }
        public string value { get; set; }

        public MessageModel(int id, string val ){
            this.msgId = id;
            this.value = val;
        }

    }
}
