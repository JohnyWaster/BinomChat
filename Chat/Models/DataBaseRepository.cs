using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class DataBaseRepository : IRepository
    {
        private ChatDbContext context = new ChatDbContext(); 
        public IQueryable<Message> MessagesOfTheDay {
            get
            {
                var nowDate = DateTime.Now.Date;
                return context.Messages.Where(a => DbFunctions.TruncateTime(a.Time) == nowDate);
            }
        }

        public IQueryable<User> UsersOnline
        {
            get { return context.Users; }
        }

        public void AddMessage(Message message)
        {
            if(message==null)
                return;

            context.Messages.Add(message);
            context.SaveChanges();
        }

        public void AddUser(User user)
        {
            if (user == null)
                return;

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}