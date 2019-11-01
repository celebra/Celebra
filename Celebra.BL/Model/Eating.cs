using System;
using System.Collections.Generic;
using System.Linq;

namespace Celebra.BL.Model
{
    [Serializable]
    public class Eating
    {
        public int                          Id      { get; set; }
        public DateTime                     Moment  { get; }
        public Dictionary<Food, double>     Foods   { get; }
        public User                         User    { get; }
        
        
        
        public Eating(User user)
        {
            User    = user ?? throw new ArgumentNullException(nameof(user));
            Moment  = DateTime.UtcNow;
            Foods   = new Dictionary<Food, double>();
        }
        
        
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
      

    }
}
