using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using UnitTestNetCore.Controllers;
using UnitTestNetCore.Models;
using UnitTestNetCore.Services;

namespace WebApp.Tests
{
    [TestClass]
    public class PersonServiceTest
    {
        private PersonService _service;
        
        [TestInitialize]
        public void Setup()
        {
            _service = new PersonService();
        }

        [TestMethod]
        public void Person_wiht_null_name_is_invalid()
        {
            Person person = new Person { Name = string.Empty};

            var result = _service.IsValid(person);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Person_wiht_age_less_than_zero_is_invalid()
        {
            Person person = new Person { Age = -1 };

            var result = _service.IsValid(person);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Person_is_valid()
        {
            Person person = new Person { Name = "Sevann", Age = 20 };

            var result = _service.IsValid(person);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Create_Person_invalid_assings_ViewBag_MessageError()
        {
            var mockPersonService = new Mock<IPersonService>();
            mockPersonService.Setup(ps => ps.IsValid(new Person())).Returns(false);
            mockPersonService.SetupGet(ps => ps.Errors).Returns(new List<string> { "Error"});
            
            HomeController controller = new HomeController(mockPersonService.Object);
            var result = controller.CreatePerson(new Person());

            Assert.IsNotNull(result.ViewData["MessageError"]);
        }
    }
}
