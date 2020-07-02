using System.Collections.Generic;
using UnitTestNetCore.Models;
using UnitTestNetCore.Services;

namespace UnitTestNetCore.Test
{
    public class PersonServiceDummy : IPersonService
    {
        public List<string> Errors { get; set; }

        public bool IsValid(Person model)
        {
            Errors = new List<string>();
            Errors.Add("Error");

            return false;
        }
    }
}
