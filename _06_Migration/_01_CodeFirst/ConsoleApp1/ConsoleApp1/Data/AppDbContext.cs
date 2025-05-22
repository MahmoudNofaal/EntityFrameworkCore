using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data;

public class AppDbContext : DbContext
{

   public DbSet<Course> Courses { get; set; }
   public DbSet<Instructor> Instructors { get; set; }
   public DbSet<Office> Offices { get; set; }
   public DbSet<Section> Sections { get; set; }
   public DbSet<Schedule> Schedules { get; set; }
   public DbSet<Student> Students { get; set; }
   public DbSet<SectionSchedule> SectionSchedules { get; set; }
   public DbSet<Enrollment> Enrollments { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);

      var configuration = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();

      var connectionString = configuration.GetSection("constr").Value;

      optionsBuilder.UseSqlServer(connectionString);


   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // not best practice
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

   }

}

