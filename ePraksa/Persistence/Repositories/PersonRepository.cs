using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Person> GetPersons()
        {
            return _context.Persons              
                .Include(f => f.Faculty)
                .ToList();
        }

        /// <summary>
        /// Get single Person - Admin
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Person GetPerson(int PersonId)
        {
            return _context.Persons
                .Include(s => s.Faculty)
                .SingleOrDefault(d => d.Id == PersonId);

        }

        //public Profesor GetProfile(string userId)
        //{
        //    return _context.Profesors
        //        .Include(s => s.Specialization)
        //        .Include(u => u.Physician)
        //        .SingleOrDefault(d => d.PhysicianId == userId);
        //}
        public void Add(Person Person)
        {
            _context.Persons.Add(Person);
        }

    }
}