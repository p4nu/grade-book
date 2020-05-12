using System;

namespace GradeBook
{
    public class NamedObject
    {
        string name;

        public NamedObject(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                this.name = name;
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(name)}.");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException($"Invalid {nameof(name)}.");
                }
            }
        }
    }
}
