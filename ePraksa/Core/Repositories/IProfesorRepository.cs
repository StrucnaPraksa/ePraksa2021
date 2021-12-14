using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IProfesorRepository
    {
        IEnumerable<Profesor> GetProfesors();
        IEnumerable<Profesor> GetAvailableProfesors();
        Profesor GetProfesor(int id);
        Profesor GetProfile(string userId);
        void Add(Profesor Profesor);
    }
}