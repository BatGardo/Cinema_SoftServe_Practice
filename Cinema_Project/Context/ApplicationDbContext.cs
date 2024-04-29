using Cinema_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cinema_Project.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<Actor> Actors { get; set; }

    }
}
