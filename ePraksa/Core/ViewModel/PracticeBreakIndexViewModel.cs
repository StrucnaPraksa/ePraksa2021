using PracticeManagement.Core.Models;
using System.Collections.Generic;

namespace PracticeManagement.Core.ViewModel
{
    public class PracticeBreakIndexViewModel
    {
        public PracticeAttendance PracticeAttendance { get; set; }
        public IEnumerable<PracticeBreak> PracticeBreaks { get; set; }
    }
}
