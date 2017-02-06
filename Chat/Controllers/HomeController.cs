using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Models;
using Chat.ViewModel;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        private ViewModel.MessageViewModel _messageViewModel;

        public HomeController(IRepository repository)
        {
            _repository = repository;

            _messageViewModel = new MessageViewModel();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chat()
        {
            ViewData["Users"] = _repository.UsersOnline;
            ViewData["Messages"] = _repository.MessagesOfTheDay;
            ViewData["MessageViewModel"] = _messageViewModel;
            return View();
        }
        
        
        [HttpPost]
        public ActionResult Chat(MessageViewModel messageViewModel)
        {
            if (!String.IsNullOrWhiteSpace(messageViewModel.MessageText))
            {
                _repository.AddMessage(new Message { Author = _messageViewModel.NickName, Time = DateTime.Now, Text = messageViewModel.MessageText });
            }

            
            ViewData["Users"] = _repository.UsersOnline;
            ViewData["Messages"] = _repository.MessagesOfTheDay;
            ViewData["MessageViewModel"] = _messageViewModel;
            return View();
        }
    }
}