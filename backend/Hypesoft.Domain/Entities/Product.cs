using System;
using Hypesoft.Domain.Exceptions;

namespace Hypesoft.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Stock Stock { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Product(string name, string description, decimal price, Guid categoryId, int initialStock)
        {
            ValidateName(name);
            ValidateDescription(description);
            ValidatePrice(price);
            ValidateCategory(categoryId);

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Stock = new Stock(initialStock);
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // Proprietary methods product
        public void Rename(string newName)
        {
            EnsureIsActive();
            ValidateName(newName);

            Name = newName;
            UpdateTimestamp();
        }

        public void ChangeDescription(string newDescription)
        {
            EnsureIsActive();
            ValidateDescription(newDescription);

            Description = newDescription;
            UpdateTimestamp();
        }

        public void ChangePrice(decimal newPrice)
        {
            EnsureIsActive();
            ValidatePrice(newPrice);

            Price = newPrice;
            UpdateTimestamp();
        }

        public void ChangeCategory(Guid newCategoryId)
        {
            EnsureIsActive();
            ValidateCategory(newCategoryId);

            CategoryId = newCategoryId;
            UpdateTimestamp();
        }

        public void IncreaseStock(int amount)
        {
            EnsureIsActive();
            Stock.Increase(amount);
            UpdateTimestamp();
        }

        public void DecreaseStock(int amount)
        {
            EnsureIsActive();
            Stock.Decrease(amount);
            UpdateTimestamp();
        }

        public void SetStock(int quantity)
        {
            EnsureIsActive();
            Stock.Set(quantity);
            UpdateTimestamp();
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdateTimestamp();
        }

        public void Activate()
        {
            IsActive = true;
            UpdateTimestamp();
        }

        // Private Validations
        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty.");

            if (name.Length < 3 || name.Length > 150)
                throw new DomainException("Name must be between 3 and 150 characters.");
        }

        private void ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be empty.");

            if (description.Length > 500)
                throw new DomainException("Description cannot exceed 500 characters.");
        }

        private void ValidatePrice(decimal price)
        {
            if (price <= 0)
                throw new DomainException("Price must be greater than zero.");
        }

        private void ValidateCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                throw new DomainException("CategoryId cannot be empty.");
        }

        private void EnsureIsActive()
        {
            if (!IsActive)
                throw new DomainException("Cannot modify an inactive product.");
        }

        private void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}