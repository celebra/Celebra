using System;
using System.Collections.Generic;
using System.Text;

namespace Celebra.BL.Model
{
    [Serializable]
    public class Food
    {
        public int    Id                { get; set; }
        public string Name              { get; set; }
        public double Calories          { get; set; }
        public double Proteins          { get; set; }
        public double Fats              { get; set; }
        public double Carbohydrates     { get; set; }
        

        public Food() { }
        public Food(string name) : this(name, 1, 1, 1, 1) {}
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            #region Check
            if (proteins <= 0)
            {
                throw new ArgumentNullException("Error Input Data", nameof(proteins));
            }
            if (fats <= 0)
            {
                throw new ArgumentNullException("Error Input Data", nameof(fats));
            }
            if (carbohydrates <= 0)
            {
                throw new ArgumentNullException("Error Input Data", nameof(carbohydrates));
            }
            if (calories <= 0)
            {
                throw new ArgumentNullException("Error Input Data", nameof(calories));
            }
            #endregion

            Proteins        = proteins      / 100;
            Fats            = fats          / 100;
            Carbohydrates   = carbohydrates / 100;
            Calories        = calories      / 100;
        }


        private double isOneGramm(double value)
        { return value / 100.0; }

    }
}
