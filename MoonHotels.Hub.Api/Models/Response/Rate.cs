using System.Text.Json.Serialization;

namespace MoonHotels.Hub.Api.Models.Response
{
    /// <summary>
    /// Represents a rate for a meal plan.
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rate"/> class with the specified parameters.
        /// </summary>
        /// <param name="mealPlanId">The ID of the meal plan.</param>
        /// <param name="isCancellable">A value indicating whether the rate is cancellable.</param>
        /// <param name="price">The price of the rate.</param>
        [JsonConstructor]
        public Rate(int mealPlanId, bool isCancellable, double price)
        {
            MealPlanId = mealPlanId;
            IsCancellable = isCancellable;
            Price = price;
        }

        /// <summary>
        /// Gets the ID of the meal plan.
        /// </summary>
        public int MealPlanId { get; }

        /// <summary>
        /// Gets a value indicating whether the rate is cancellable.
        /// </summary>
        public bool IsCancellable { get; }

        /// <summary>
        /// Gets the price of the rate.
        /// </summary>
        public double Price { get; }
    }
}
