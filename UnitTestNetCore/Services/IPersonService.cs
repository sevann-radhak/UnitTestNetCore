using System.Collections.Generic;
using UnitTestNetCore.Models;

namespace UnitTestNetCore.Services
{
    public interface IPersonService
    {
        List<string> Errors { get; set; }
        bool IsValid(Person model);
        public Person GetPerson(int id);
    }
}
