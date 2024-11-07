using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Student: BaseEntity
    {
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
