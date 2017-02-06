using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class Message
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}")]
        public DateTime Time { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}