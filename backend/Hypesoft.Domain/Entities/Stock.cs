using Hypesoft.Domain.Exceptions;
using System;

namespace Hypesoft.Domain.Entities
{
    public class Stock
    {
        public int Quantity { get; private set; }

        private const int LowStockThreshold = 10;

        public Stock(int initialQuantity)
        {
            if (initialQuantity < 0)
                throw new DomainException("Initial stock cannot be negative.");

            Quantity = initialQuantity;
        }

        public void Increase(int amount)
        {
            if (amount <= 0)
                throw new DomainException("Increase amount must be greater than zero.");

            Quantity += amount;
        }

        public void Decrease(int amount)
        {
            if (amount <= 0)
                throw new DomainException("Decrease amount must be greater than zero.");

            if (Quantity - amount < 0)
                throw new DomainException("Insufficient stock.");

            Quantity -= amount;
        }

        public void Set(int quantity)
        {
            if (quantity < 0)
                throw new DomainException("Stock cannot be negative.");

            Quantity = quantity;
        }

        public bool IsLowStock()
        {
            return Quantity < LowStockThreshold;
        }
    }
}