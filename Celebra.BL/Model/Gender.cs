using System;

namespace Celebra.BL.Model
{
    [Serializable]
    public class Gender
    {
        public string Name { get; }
        public Gender(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
