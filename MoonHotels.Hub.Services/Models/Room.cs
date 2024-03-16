using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Services.Models
{
    /// <summary>
    /// Represents a room with its rates.
    /// </summary>
    internal class Room : IRoom
    {
        public Room(int roomId, int mealId, bool isCacellable, decimal price)
        {
            RoomId = roomId;
            AddRate(mealId, isCacellable, price);
        }

        public Room(int roomId, IEnumerable<IRate> rates)
        {
            RoomId = roomId;
            Rates = rates;
        }

        /// <inheritdoc/>
        public int RoomId { get; set; }

        /// <inheritdoc/>
        public IEnumerable<IRate> Rates { get; private set; } = new List<Rate>();

        private void AddRate(int mealId, bool isCacellable, decimal price)
        {
            Rates = Rates.Append(new Rate(mealId, isCacellable, price));
        }
    }
}