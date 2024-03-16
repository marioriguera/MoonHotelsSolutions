using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Contracts
{
    /// <summary>
    /// Represents a rate for a meal plan.
    /// </summary>
    public interface IRate
    {
        /// <summary>
        /// Gets or sets the ID of the meal plan.
        /// </summary>
        public int MealPlanId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the rate is cancellable.
        /// </summary>
        public bool IsCancellable { get; set; }

        /// <summary>
        /// Gets or sets the price of the rate.
        /// </summary>
        public double Price { get; set; }
    }
}
