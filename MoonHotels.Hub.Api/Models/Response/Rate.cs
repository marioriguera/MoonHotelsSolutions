using System.Text.Json.Serialization;

namespace MoonHotels.Hub.Api.Models.Response
{

    public class Rate
    {
        [JsonConstructor]
        public Rate(
            int mealPlanId,
            bool isCancellable,
            double price
        )
        {
            this.MealPlanId = mealPlanId;
            this.IsCancellable = isCancellable;
            this.Price = price;
        }

        public int MealPlanId { get; }
        public bool IsCancellable { get; }
        public double Price { get; }
    }
}
