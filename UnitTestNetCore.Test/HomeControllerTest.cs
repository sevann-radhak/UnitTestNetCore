using NUnit.Framework;
using UnitTestNetCore.Controllers;
using UnitTestNetCore.Models;

namespace UnitTestNetCore.Test
{
    public class HomeControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            PersonServiceDummy servicePerson = new PersonServiceDummy();
            HomeController controller = new HomeController(servicePerson);
            Person person = new Person { Id = 1, Age = -1, Name = "Sevann" };

            Microsoft.AspNetCore.Mvc.ViewResult result = controller.CreatePerson(person);

            Assert.IsNotNull(result.ViewData["MessageError"]);
        }
    }
}