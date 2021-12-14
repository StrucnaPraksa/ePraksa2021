using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
        //IEnumerable<Profesor> GetAvailableProfesors();
        Person GetPerson(int PersonId);
        //Profesor GetProfile(string userId);
        void Add(Person Person);
    }
}