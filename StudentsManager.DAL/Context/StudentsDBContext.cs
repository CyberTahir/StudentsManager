using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Entities;
using System.Data;

namespace StudentsManager.DAL.Context
{
    public class StudentsDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentsGroup> StudentsGroup { get; set; }

        public StudentsDBContext(DbContextOptions opt) : base(opt) { }
    }
}
