using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webtestrevised.Models;

namespace webtestrevised.Data
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<CoursePaper> CoursePapers { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
