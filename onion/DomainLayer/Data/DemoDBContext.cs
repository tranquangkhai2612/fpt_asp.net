using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Data
{
    public class DemoDBContext: DbContext
    {
        public DemoDBContext(DbContextOptions<DemoDBContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
