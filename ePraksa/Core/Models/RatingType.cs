using System;

namespace PracticeManagement.Core.Models
{
    public class RatingType
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public string Name { get { return Value.ToString() + " - " + Description; } }
    }

}
