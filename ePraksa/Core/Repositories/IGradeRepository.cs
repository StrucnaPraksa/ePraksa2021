using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Repositories
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetGrades();

        Grade GetGrade(int id);

        void Add(Grade grade);

        void Remove(Grade grade);
        IEnumerable<Grade> GetGrades(int id);

    }
}