using System;
using System.Collections.Generic;
using System.Collections.Generic;

namespace TelegramBotLog
{
    class UsersHistory
    {
        Dictionary<long, User> history;

        public UsersHistory()
        {
            history = new Dictionary<long, User>();
        }

        public void AddMessage(long UserID, string TextMessage)
        {
            if (history.ContainsKey(UserID))
            {
                history[UserID].Message.Add(TextMessage);
            }
            else
            {
                history.Add(UserID, new User() { Message = new List<string>() { TextMessage } });
            }
        }


        public string GetID(long UserID)
        {
            return history[UserID].Id.ToString();
        }

        public string GetLog(long UserID)
        {
            string result = String.Empty;

            foreach (var message in history[UserID].Message)
            {
                result += $">> {message}\n";
            }
            return result;
        }
    }
}