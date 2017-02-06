using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Chat.Models;
using Moq;
using Ninject;

namespace Chat.Infrastracture
{
    // реализация пользовательской фабрики контроллеров,
    // наследуясь от фабрики используемой по умолчанию
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // конфигурирование контейнера
            Mock<IRepository> mock = new Mock<IRepository>();

            mock.Setup(m => m.UsersOnline).Returns(new List<User>
            {new User() {Name = "user1"}, new User { Name = "user2"}}.AsQueryable());

            mock.Setup(m => m.MessagesOfTheDay).Returns(new List<Message>
            {new Message {Time = new DateTime(), Author = "Artur", Text = "firstMess"},
                new Message {Time = DateTime.Now, Author = "Peter Crouch", Text = "secondMess"}}.AsQueryable());

            ninjectKernel.Bind<IRepository>().To<DataBaseRepository>();
        }
    }
}