using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    /// <summary>
    /// author: Grgo Jelavic
    /// description: logic specifiication required to store and retreive data
    /// date: 14.12.2021.
    /// </summary>
    public interface IInternshipRepository
    {
        IEnumerable<Internship> GetInternships();
        void Add(Internship internship);
        Internship GetInternship(int id);
    }
}
