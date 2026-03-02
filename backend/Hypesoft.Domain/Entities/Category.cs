using System;
using Hypesoft.Domain.Exceptions;

namespace Hypesoft.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Category(string name)
        {
            ValidateName(name);

            Id = Guid.NewGuid();
            Name = name;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Rename(string newName)
        {
            EnsureIsActive();
            ValidateName(newName);

            Name = newName;
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

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Category name cannot be empty.");

            if (name.Length < 3 || name.Length > 100)
                throw new DomainException("Category name must be between 3 and 100 characters.");
        }

        private void EnsureIsActive()
        {
            if (!IsActive)
                throw new DomainException("Cannot modify an inactive category.");
        }

        private void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}