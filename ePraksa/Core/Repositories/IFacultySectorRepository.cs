using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IFacultySectorRepository
    {
        IEnumerable<FacultySector> GetFacultySectors();
    }
}