using System;
using System.Collections.Generic;
using System.Text;

namespace Celebra.BL.Model
{
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
