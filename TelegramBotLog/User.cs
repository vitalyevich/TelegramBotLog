using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotLog
{
    class User
    {
        static User() { allId = 1; }
        static int allId;

        public User()
        {
            Id = allId; allId++;
            Message = new List<string>();
        }

        public int Id { get; set; }
        public List<string> Message { get; set; }

    }
}
