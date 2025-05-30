﻿using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

/// Query Data: means retrieving entites from the database using LINQ or RawSQL
/// - we use it as type-safe, readable queries, reducing the need of raw sql and supporting
///   complex filtering, sorting,..

class Program
{
   public static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         ///// Ex: #1
         //var courses = context.Courses;

         //Console.WriteLine(courses.ToQueryString());

         //foreach (var course in courses)
         //{
         //Console.WriteLine($"course name: {course.CourseName}," +
         //$" {course.HoursToComplete}" +
         //$" hrs., {course.Price.ToString("C")}");
         //}

         ///////////////////////////////////////////////////////////////////

         ///// Ex: #2
         //var course = context.Courses.Single(x => x.Id == 1);

         //Console.WriteLine($"course name: {course.CourseName}," +
         //$" {course.HoursToComplete}" +
         //$" hrs., {course.Price.ToString("C")}");

         ///////////////////////////////////////////////////////////////////

         ///// Ex: #3
         //var course = context.Courses.Single(x => x.HoursToComplete == 25);

         //Console.WriteLine($"{course.CourseName}, {course.Price.ToString("C")}");

         ///////////////////////////////////////////////////////////////////

         ///// Ex: #4
         //var course = context.Courses.First(x => x.HoursToComplete == 25);

         //Console.WriteLine($"{course.CourseName}, {course.Price.ToString("C")}");

         ///////////////////////////////////////////////////////////////////

         ///// Ex: #5
         //var course = context.Courses.Single(x => x.HoursToComplete == 999);

         //Console.WriteLine($"{course.CourseName}, {course.Price.ToString("C")}");

         ///////////////////////////////////////////////////////////////////

         ///// Ex: #6
         //var course = context.Courses.FirstOrDefault(x => x.HoursToComplete == 999);

         //Console.WriteLine($"{course?.CourseName}, {course?.Price.ToString("C")}");

         ///////////////////////////////////////////////////////////////////

         ///// Ex: #7
         //var course = context.Courses.SingleOrDefault(x => x.HoursToComplete == 999);

         //Console.WriteLine($"{course?.CourseName}, {course?.Price.ToString("C")}");

         ///////////////////////////////////////////////////////////////////

         /// Ex: #8
         var courses = context.Courses.Where(x => x.Price > 3000);

         Console.WriteLine(courses.ToQueryString());

         foreach (var course in courses)
         {
            Console.WriteLine($"course name: {course.CourseName}, " +
            $"{course.HoursToComplete} " +
            $"hrs., {course.Price.ToString("C")}");
         }

      }
   }
}