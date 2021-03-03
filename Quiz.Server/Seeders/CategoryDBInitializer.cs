using Quiz.Server.Data;
using System.Linq;

namespace Quiz.Server.Seeders
{
    public class CategoryDBInitializer
    {
        public static void Seed(DataContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            context.Categories.AddRange(
                new Category
                {
                    Name = "Financial"
                },
                new Category
                {
                    Name = "Comprehension"
                },
                new Category
                {
                    Name = "Numerical"
                },
                new Category
                {
                    Name = "Amazon"
                },
                new Category
                {
                    Name = "Cubiks"
                }
            );

            context.SaveChanges();
        }
    }
}
