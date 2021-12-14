using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Repositories
{
    public interface IFirmRepository
    {
        IEnumerable<Firm> GetFirms();
        Firm GetFirm(int id);
        void Add(Firm firm);
        void Remove(Firm firm);
    }
}