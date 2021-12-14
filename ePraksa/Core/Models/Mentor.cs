using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeManagement.Core.Models
{
    public class Mentor
    {
        public int Id { get; set; }
        [ForeignKey("Firm")]
        public int FirmId { get; set; }
        public virtual Firm Firm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return FirstName + " " + LastName; } }
        public string Title { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int YearsOfExperience { get; set; }
        public string Competence { get; set; }
        public string CV { get; set; }
        public bool Activated { get; set; }
    }
}
