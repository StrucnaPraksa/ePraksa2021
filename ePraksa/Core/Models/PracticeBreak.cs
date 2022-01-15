using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Core.Models
{
    public class PracticeBreak
    {
        public int Id { get; set; }
        public int PracticeAttendanceId { get; set; }
        public PracticeAttendance PracticeAttendance { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
