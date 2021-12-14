using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class PersonFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
               
        [Required]
        public int Faculty { get; set; }

        public IEnumerable<Faculty> Faculties { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public IEnumerable<Person> Person { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }

        
    }
}

