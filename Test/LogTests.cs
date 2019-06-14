using System;
using Enum;
using Logic;
using NUnit.Framework;
using System.Data.SqlClient;
using Data.Dto;

namespace Tests
{
    public class LogTests
    {
        private FoodlogLogic _foodlogLogic;
        private GoalLogLogic _goallogLogic;
        private WeightLogLogic _weightLogLogic;
        
        [SetUp]
        public void Setup()
        {
            _foodlogLogic = new FoodlogLogic();
            _goallogLogic = new GoalLogLogic();
            _weightLogLogic = new WeightLogLogic();
        }
        
        [Test]
        public void Log_Test_NUnit_Runs()
        {
            Assert.Pass();
        }

        [Test]
        public void FoodLog_Add_FoodlogShouldBeAdded_ValidationSucceeded()
        {
            var user = new UserDto
            {
                Id = 1,
            };
            var foodlog = new FoodlogDto
            {
                Amount = 5,
                DateTime = DateTime.Now,
                Article = new ArticleLogic().GetBy(1),
                Dish = null,
                User = new UserLogic().GetBy(user.Id, user.Id),
                Unit = Unit.Stuks
            };
            
            var expected = true;
            var actual = _foodlogLogic.Add(user.Id, foodlog);
            
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void FoodLog_Add_FoodlogShouldBeAddedTwo_ValidationSucceeded()
        {
            var user = new UserDto
            {
                Id = 1,
            };
            var foodlog = new FoodlogDto
            {
                Amount = 5,
                DateTime = DateTime.Now,
                Article = null,
                Dish = new DishLogic().GetBy(1),
                User = new UserLogic().GetBy(user.Id, user.Id),
                Unit = Unit.Stuks
            };
            
            var expected = true;
            var actual = _foodlogLogic.Add(user.Id, foodlog);
            
            Assert.AreEqual(expected, actual);

        }
        
        [Test]
        public void FoodLog_Add_FoodlogShouldNotBeAdded_ValidationError()
        {
            var user = new UserDto
            {
                Id = 1,
            };
            var foodlog = new FoodlogDto
            {
                Amount = 5,
                DateTime = DateTime.Now,
                Article = null,
                Dish = null,
                User = new UserLogic().GetBy(user.Id, user.Id),
                Unit = Unit.Stuks
            };
            
            var expected = false;
            var actual = _foodlogLogic.Add(user.Id, foodlog);
            
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void GoalLog_Add_GoalShouldBeAdded_ValidationSucceeded()
        {
            var user = new UserDto
            {
                Id = 1,
            };
            var goallog = new GoalLogDto
            {
                Calories = 2500,
                DateTime = DateTime.Now,
                User = user,
            };

            var expected = true;
            var actual = _goallogLogic.Add(user.Id, goallog);

            Assert.AreEqual(expected, actual);
        }
    }
    
    
}