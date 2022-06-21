using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EenVoudigeToDoApi.Models;
namespace EenVoudigeToDoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //laptop
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\ozgun\Desktop\EindOpdracht WEB4FLEX\EenVoudigeToDoApi\EenVoudigeToDoApi\ToDoDb.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();
            modelBuilder.Entity<Board>()
                .HasIndex(b => b.Id)
                .IsUnique();
            modelBuilder.Entity<ToDo>()
                .HasIndex(td => td.Id)
                .IsUnique();
        }
        public DbSet<User> User { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<ToDo> ToDo { get; set; }

    }
}
