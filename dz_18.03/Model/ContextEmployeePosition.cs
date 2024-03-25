using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace dz_18._03.Model
{
    public class ContextEmployeePosition : DbContext
    {
        public DbSet<Position> position { get; set; }
        public DbSet<Employee> employee { get; set; }
        public ContextEmployeePosition() 
        {
            if (Database.EnsureCreated())
            {
                using (var context = new ContextEmployeePosition())
                {
                    context.Database.EnsureCreated();
                    Position position1 = new Position { NamePosition = "Desighner" };
                    Position position2 = new Position { NamePosition = "Developer" };
                    context.position.Add(position1);
                    context.position.Add(position2);
                    Employee employee1 = new Employee { Name = "Nikita", Surname = "Myha", Age = 43, Salary = 23000, position = position1 };
                    Employee employee2 = new Employee { Name = "Zlata", Surname = "Zvet", Age = 25, Salary = 16000, position = position2 };
                    context.employee.Add(employee1);
                    context.employee.Add(employee2);
                    context.SaveChanges();
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SE38RKL;Database=ITCompany;Integrated Security=SSPI;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Position>().HasKey(p => p.Id);
            modelBuilder.Entity<Employee>().HasOne(e => e.position).WithMany(p => p.Employees).HasForeignKey(e => e.PosititonId).IsRequired();
        }
    }
}
