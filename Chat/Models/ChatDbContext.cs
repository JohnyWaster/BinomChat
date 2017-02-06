using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext()
        {
            Database.SetInitializer<ChatDbContext>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; } 
    }
}