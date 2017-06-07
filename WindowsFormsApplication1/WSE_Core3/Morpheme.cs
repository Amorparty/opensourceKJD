using System;
using System.Collections.Generic;
using System.Text;

namespace WSE_Core3
{
    public class Morpheme
    {
        public string Name
        {
            get;
            set;
        }
        public int Count
        {
            get;
            set;
        }
        public Morpheme()
        {
            Name = string.Empty;
            Count = 0;
        }

        public Morpheme(string name, int count)
        {
            Name = name;
            Count = count;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
