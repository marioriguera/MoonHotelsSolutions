using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Services.Models
{
    /// <summary>
    /// Represents a rate for a meal plan.
    /// </summary>
    internal class Rate : IRate
    {
        /// <inheritdoc/>
        public int MealPlanId { get; set; }

        /// <inheritdoc/>
        public bool IsCancellable { get; set; }

        /// <inheritdoc/>
        public double Price { get; set; }
    }
}