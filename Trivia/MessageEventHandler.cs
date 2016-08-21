using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public delegate void MessageEventHandler(object sender, MessageEventArgs e);
    public class MessageEventArgs : EventArgs
    {
        public int Id;
        public MessageEventArgs(int id)
        {
            Id = id;
        }
    }
}
