using System;
using System.Collections.Generic;
using System.Text;

namespace Celebra.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string   Name                { get; }
        public double   CaloriesPerMinute   { get; }


        public Activity(string name, double caloriesPerMinute)
        {
            Name                = name ?? throw new ArgumentNullException(nameof(name));
            CaloriesPerMinute   = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }




    }
}
