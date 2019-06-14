using System;
using Enum;
using Logic;
using NUnit.Framework;
using System.Data.SqlClient;
using Data.Dto;

namespace Tests
{
    public class UserTests
    {
        private UserLogic _userLogic;
        
        [SetUp]
        public void Setup()
        {
            _userLogic = new UserLogic();
        }

        [Test]
        public void User_Test_NUnit_Runs()
        {
            Assert.Pass();
        }

        [Test]
        public void User_Login_UserShouldLogin_CorrectCredentials()
        {
            const string email = "rik@rik.nl";
            const string password = "Rik";
            
            
            var expected = MessageType.Success;
            var actual = _userLogic.CheckLogin(email, password).Type;

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void User_Login_UserShouldNotLogin_IncorectCredentials()
        {
            var user = new UserDto
            {
                Email = "rik@rik.nll",
                Password = "Rik",
            };


            var expected = MessageType.Warning;
            var actual = _userLogic.CheckLogin(user.Email, user.Password).Type;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void User_Login_UserShouldNotLogin_UserBlocked()
        {
            var user = new UserDto
            {
                Email = "gert@gert.nl",
                Password = "Gert",
            };


            var expected = MessageType.Warning;
            var actual = _userLogic.CheckLogin(user.Email, user.Password).Type;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void User_Register_UserShouldRegister_ValidationSucceeded()
        {
            var user = new UserDto
            {
                Email = "test@test.nl",
                Password = "Test",
                FirstName = "Test",
                LastName = "Test",
                BirthDate = new DateTime().Date,
                Length = 178,
                Blocked = false,
                Right = new RightDto {Id = 1}
            };
            
            var expected = true;
            var actual = _userLogic.Register(user, user.Password);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void User_Register_UserShouldNotRegister_Duplicate()
        {
            var user = new UserDto
            {
                Email = "rik@rik.nl",
                Password = "Rik",
                FirstName = "Rik",
                LastName = "Peeters",
                BirthDate = new DateTime().Date,
                Length = 178,
                Blocked = false,
                Right = new RightDto {Id = 1}
            };
            
            var expected = false;
            var actual = _userLogic.Register(user, user.Password);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void User_Register_UserShouldNotRegister_ValidationError()
        {
            var user = new UserDto
            {
                Email = "testtest@rik.nl",
                Password = "Test",
                FirstName = "Rik",
                LastName = "Peeters",
                BirthDate = new DateTime().Date,
                Length = 2000,
                Blocked = false,
                Right = new RightDto {Id = 1}
            };
            
            var expected = false;
            var actual = _userLogic.Register(user, user.Password);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void User_Edit_DataOfUserShouldUpdate_ValidationSucceeded()
        {
            var adminUserId = 1;
            var user = new UserDto
            {
                Id = 1,
                Email = "rik@rik.nl",
                Password = "Test",
                FirstName = "Rik",
                LastName = "Peeters",
                BirthDate = new DateTime().Date,
                Length = 178,
                Blocked = false,
                Right = new RightDto {Id = 1}
            };
            
            var expected = true;
            var actual = _userLogic.Edit(adminUserId, user);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void User_Edit_DataOfUserShouldNotUpdate_ValidationError()
        {
            var adminUserId = 1;
            var user = new UserDto
            {
                Id = 1,
                Email = "rik@rik.nl",
                Password = "Test",
                FirstName = "Rik",
                LastName = "Peeters",
                BirthDate = new DateTime().Date,
                Length = 2000,
                Blocked = false,
                Right = new RightDto {Id = 1}
            };
            
            var expected = false;
            var actual = _userLogic.Edit(adminUserId, user);
            
            Assert.AreEqual(expected, actual);
        }
        
    }
}