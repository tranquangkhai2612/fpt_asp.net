using System.ComponentModel.DataAnnotations;

namespace onion.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}
