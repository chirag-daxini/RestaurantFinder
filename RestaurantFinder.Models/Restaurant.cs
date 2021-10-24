using System.Collections.Generic;
using System.Linq;

namespace RestaurantFinder.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }
        public Rating Rating { get; set; }
        public bool IsOpenNow { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Rating.Average} - {string.Join(",", CuisineTypes.Select(x => x.Name))}";
        }
    }
}
