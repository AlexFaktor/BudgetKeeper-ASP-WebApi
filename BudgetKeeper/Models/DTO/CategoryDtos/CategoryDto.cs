

using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Models.DTO.CategoryDtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public CategoryDto()
        { 
        }
        
        public CategoryDto(Category record)
        { 
            Id = record.Id;
            Name = record.Name;
        }
    }
}
