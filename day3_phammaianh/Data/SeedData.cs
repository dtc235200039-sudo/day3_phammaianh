using day3_phammaianh.Models;

namespace day3_phammaianh.Data
{
    public class SeedData
    {
        public static List<Category> Categories = new List<Category>()
        {
            new Category() { Id = 1, Name = "Category 1", Description = "Description 1" },
            new Category() { Id = 2, Name = "Category 2", Description = "Description 2" },
            new Category() { Id = 3, Name = "Category 3", Description = "Description 3" }
        };
    }
}