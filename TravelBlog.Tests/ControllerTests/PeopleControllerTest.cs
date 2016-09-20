using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Controllers;
using TravelBlog.Models;
using Xunit;
using Moq;
using System.Linq;
using TravelBlog.Tests.Models;

namespace TravelBlog.Tests
{
    public class PeoplesControllerTest : IDisposable
    {
        Mock<IPeopleRepository> mock = new Mock<IPeopleRepository>();
        EFPeopleRepository db = new EFPeopleRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(m => m.Peoples).Returns(new People[]
            {
                new People {PersonId = 1, Name = "Joe" },
                new People {PersonId = 2, Name = "Sam" },
                new People {PersonId = 3, Name = "Jessica" }
            }.AsQueryable());
        }
        
        public void Dispose()
        {
            db.DeleteAll();
        }

        [Fact]
        public void Post_MethodAddsPeople_Test()
        {
            // Arrange
            PeoplesController controller = new PeoplesController();
            People testPeople = new People();
            testPeople.Name = "test people";

            // Act
            controller.Create(testPeople);
            ViewResult indexView = new PeoplesController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<People>;

            // Assert
            Assert.Contains<People>(testPeople, collection);
        }

        [Fact]
        public void GetModelListPeopleIndex_Test()
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new PeoplesController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<People>>(result);
        }

        [Fact]
        public void Mock_ConfirmEntry_Test()
        {
            // Arrange
            DbSetup();
            PeoplesController controller = new PeoplesController(mock.Object);
            People testPeople = new People();
            testPeople.Name = "Joe";
            testPeople.PersonId = 1;

            //Act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<People>;

            //Assert
            Assert.Contains<People>(testPeople, collection);
        }

        [Fact]
        public void DB_CreateNewEntry_Test()
        {
            // Arrange
            PeoplesController controller = new PeoplesController(db);
            People testPeople = new People();
            testPeople.Name = "TestDb People";

            // Act
            controller.Create(testPeople);
            var collection = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<People>;

            // Assert
            Assert.Contains<People>(testPeople, collection);
        }
    }
}