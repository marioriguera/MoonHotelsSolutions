using System.Text.Json.Serialization;
using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Api.Models.Response
{
    /// <summary>
    /// Represents a rate for a meal plan.
    /// </summary>
    public class RateResponse : IRate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RateResponse"/> class with the specified parameters.
        /// </summary>
        /// <param name="mealPlanId">The ID of the meal plan.</param>
        /// <param name="isCancellable">A value indicating whether the rate is cancellable.</param>
        /// <param name="price">The price of the rate.</param>
        public RateResponse(int mealPlanId, bool isCancellable, double price)
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
        public double Price { get; set; }
    }
}
