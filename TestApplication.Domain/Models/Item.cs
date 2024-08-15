using CSharpFunctionalExtensions;
using TestApplication.Domain.Shared;

namespace TestApplication.Domain.Models
{
    public class Item :ITimeEntity
    {
        public Guid Id { get;private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public int Price { get; private set; }

        public int Count { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category? Category { get; private set; }

        public DateTime CreatedTime { get; private set; }

        public DateTime? UpdatedTime { get; private set; }

        public void UpdateCreatedTime()
        {
            CreatedTime = DateTime.UtcNow;
        }

        public void UpdateUpdatedTime()
        {
            UpdatedTime = DateTime.UtcNow;
        }

        //EF Core
        private Item (){}
        private Item(Guid id,string name, string description, int price, int count, Guid categoryId)
        {
            Id= id;
            Name = name;
            Description = description;
            Price = price;
            Count = count;
            CategoryId = categoryId;
            UpdatedTime = null; 
        }


        public static Result<Item>Create(Guid id,string name, string description, int price, int count, Guid categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Item>("Name can not be empty");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure<Item>("Name can not be empty");
            }
            if (price<0)
            {
                return Result.Failure<Item>("Price can not be less than 0");
            }
            if (count < 0)
            {
                return Result.Failure<Item>("Count can not be less than 0");
            }

            var item = new Item(id,name, description, price, count, categoryId);
            return item;
        }


    }
}
