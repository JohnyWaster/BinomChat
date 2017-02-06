using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public interface IRepository
    {
        IQueryable<Message> MessagesOfTheDay { get;}
        IQueryable<User> UsersOnline { get;}

        void AddMessage(Message message);

        void AddUser(User user);
    }
}