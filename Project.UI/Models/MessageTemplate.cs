using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.Models
{
    public class MessageTemplate
    {
     
        public const string tempDataName = "MessageData";

        public string Content { get; set; }
        public byte Duration { get; set; }
        public bool Closeable { get; set; }
        public MessageType MessageTip { get; set; }
    }

     public enum MessageType
    {
        Success=1,
        Warning=2,
        Error=3
    }
}