using System;

namespace Celebra.BL.Model
{
    [Serializable]
    public class Gender
    {
        public int      Id      { get; set; }
        public string   Name    { get; set; }

        public Gender(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Gender()
        {
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
