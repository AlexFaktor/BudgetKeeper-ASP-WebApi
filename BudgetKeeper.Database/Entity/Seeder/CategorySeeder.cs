namespace BudgetKeeper.Database.Entity.Seeder
{
    public static class CategorySeeder
    {
        public static IEnumerable<CategoryRecord> CreateBaseCategory()
        {
            return new List<CategoryRecord>
            {
                new() { Id = Guid.NewGuid(), Name = "Activities" },
                new() { Id = Guid.NewGuid(), Name = "Credit" },
                new() { Id = Guid.NewGuid(), Name = "Fine" },
                new() { Id = Guid.NewGuid(), Name = "Gifts" },
                new() { Id = Guid.NewGuid(), Name = "Health" },
                new() { Id = Guid.NewGuid(), Name = "Preservation" },
                new() { Id = Guid.NewGuid(), Name = "Products" },
                new() { Id = Guid.NewGuid(), Name = "Salary" },
                new() { Id = Guid.NewGuid(), Name = "Software" } ,
                new() { Id = Guid.NewGuid(), Name = "Taxes" },
                new() { Id = Guid.NewGuid(), Name = "Unknown" },
            };
        }
    }
}
