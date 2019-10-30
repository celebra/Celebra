using System;

namespace Celebra.BL.Model
{
    [Serializable]
    public class User
    {
        public string       Name        { get; }
        public Gender       Gender      { get; }
        public DateTime     BirthDate   { get; }
        public double       Weight      { get; set; }
        public double       Height      { get; set; }

        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Check...
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Error Input Data", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentNullException("Error Input Data", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentNullException("Error Input Data", nameof(height));
            }
            #endregion
            Name        = name ?? throw new ArgumentNullException(nameof(name));
            Gender      = gender ?? throw new ArgumentNullException(nameof(gender));
            BirthDate   = birthDate;
            Weight      = weight;
            Height      = height;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
