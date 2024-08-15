﻿using CSharpFunctionalExtensions;
using System.Text.Json.Serialization;
using TestApplication.Domain.Shared;

namespace TestApplication.Domain.Models
{
    public class Category 
    {
        public Guid Id { get;private set; }
        public string Name { get;private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        [JsonIgnore]
        public IList<Item> Items { get; private set; } = [];

        //EF Core
        private Category(){ }
        private Category(Guid id,string name,string descriprion)
        {
            Id = id;
            Name = name;
            Description = descriprion;
        }

        public static Result<Category> Create(Guid id,string name, string description)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Category>("Name can not be empty");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure<Category>("Name can not be empty");
            }

            var category = new Category(id,name,description);
            return Result.Success(category);
        }
    }
}
