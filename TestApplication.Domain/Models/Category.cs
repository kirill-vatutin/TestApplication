using CSharpFunctionalExtensions;
using TestApplication.Domain.Shared;

namespace TestApplication.Domain.Models
{
    public class Category :BaseEntity
    {
        public string Name { get;private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public IList<Item> Items { get; private set; } = [];

        //EF Core
        private Category() { }
        private Category(string name,string descriprion)
        {
            Name = name;
            Description = descriprion;
        }

        public static Result<Category> Create(string name, string description)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Category>("Name can not be empty");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure<Category>("Name can not be empty");
            }

            var category = new Category(name,description);
            return Result.Success(category);
        }
    }
}
