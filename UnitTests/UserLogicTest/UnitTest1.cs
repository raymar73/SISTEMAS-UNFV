using System;
using ApiBussinessLogic.Implementations;
using ApiBussinessLogic.Interfaces;
using ApiUnitWork;
using FluentAssertions;
using UnitTests.Mocked;
using Xunit;

namespace UnitTests
{
    public class UserLogicTest
    {
        
        private readonly IUnitOfWork _unitMocked;
        private readonly IUserLogic _userLogic;

        public UserLogicTest() {
            var unitMocked = new UserRepositoryMocked();
            _unitMocked = unitMocked.GetInstance();
            _userLogic = new UserLogic(_unitMocked); //dependendeInyectMocked
        }

        [Fact]
        public void Test1()
        {
            var result = _userLogic.GetById(1);
            result.Should().NotBeNull();
            result.id.Should().BeGreaterThan(0);
        }
    }
}