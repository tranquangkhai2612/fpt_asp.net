﻿using Microsoft.EntityFrameworkCore;
using MyMY.Models;

namespace MyMY.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
