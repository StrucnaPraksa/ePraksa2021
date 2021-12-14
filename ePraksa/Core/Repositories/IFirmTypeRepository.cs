using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Repositories
{
    public interface IFirmTypeRepository
    {
        IEnumerable<FirmType> GetFirmTypes();
    }
}