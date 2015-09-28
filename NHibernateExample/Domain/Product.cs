using System;

namespace NHibirnateExample.Domain
{
    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual int Price { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + Environment.NewLine +
                   "Name: " + Name + Environment.NewLine +
                   "Category: " + Category + Environment.NewLine +
                   "Price: " + Price + Environment.NewLine;
        }
    }
}