using System.Collections.Generic;
using System.Linq;
using UnitTestNetCore.Models;

namespace UnitTestNetCore.Services
{
    public class PersonService : IPersonService
    {
        public List<string> Errors { get; set; }

        public bool IsValid(Person model)
        {
            Errors = new List<string>();

            if (string.IsNullOrEmpty(model.Name))
            {
                Errors.Add("The name is not valid");
            }

            if (model.Age > 200)
            {
                Errors.Add("The age can not be higher tan 200");
            }

            if (model.Age < 0)
            {
                Errors.Add("The age can not be less than 0");
            }

            return !Errors.Any();
        }

        public Person GetPerson(int id)
        {
            return new Person { Id = id, Name = $"Person: {id}", Age = id * 2};
        }
    }
}
