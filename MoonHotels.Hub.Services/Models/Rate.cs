using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Services.Models
{
    /// <summary>
    /// Represents a rate for a meal plan.
    /// </summary>
    internal class Rate : IRate
    {
        public Rate(int mealPlanId, bool isCancellable, decimal price)
        {
            MealPlanId = mealPlanId;
            IsCancellable = isCancellable;
            Price = price;
        }

        /// <inheritdoc/>
        public int MealPlanId { get; set; }

        /// <inheritdoc/>
        public bool IsCancellable { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }
    }
}