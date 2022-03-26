using System.Collections.Generic;
using System.Linq;
using ApiModel;
using ApiRepositories;
using ApiUnitWork;
using AutoFixture;
using Moq;

namespace UnitTests.Mocked
{
    public class UserRepositoryMocked
    {
        private readonly List<User> _users;

        public UserRepositoryMocked()
        {
            _users = Users();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked=new Mock<IUnitOfWork>();
            mocked.Setup(o => o.IUser)
                .Returns(GetUserRepositoryMocked());
            return mocked.Object;
        }

        public IUserRepository GetUserRepositoryMocked()
        {
            var userMock = new Mock<IUserRepository>(); //FakeMethodsOnUserRepository

            userMock.Setup(u => u.GetById(It.IsAny<int>()))
                .Returns((int id) => _users.FirstOrDefault(user => user.id == id));//fakeMethod

            return userMock.Object;
        }
        private List<User> Users()
        {
            var fixture=new Fixture();
            var users = fixture.CreateMany<User>(50).ToList();
            for (var i = 50; i < 50; i++)
            {
                users[i].id = i + 1;
            }
            return users;
        }
    }
}