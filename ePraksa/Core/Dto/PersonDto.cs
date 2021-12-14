using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Dto
{
    public class PersonDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
       public int FacultyId { get; set; }
        public FacultyDto Faculty { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }



    }
}