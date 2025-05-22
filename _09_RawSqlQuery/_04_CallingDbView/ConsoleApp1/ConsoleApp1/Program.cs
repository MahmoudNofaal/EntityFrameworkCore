using ConsoleApp1.Data;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var coursesOverviews = context.CourseOverviews.ToList();
                foreach (var courseOverview in coursesOverviews)
                {
                    Console.WriteLine(courseOverview);
                }
            }
            Console.ReadKey();
        }
    }
}