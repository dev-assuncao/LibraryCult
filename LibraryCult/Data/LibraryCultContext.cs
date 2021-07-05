using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryCult.Models;

namespace LibraryCult.Data
{
    public class LibraryCultContext : DbContext 
    {
        public LibraryCultContext(DbContextOptions<LibraryCultContext> options) : base(options)
        {
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }


    }
}
