using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NHibirnateExample.Domain
{
    public class Product
    {
        private readonly ISet<Category> _categories = new HashSet<Category>();
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Price { get; set; }

        public virtual IReadOnlyCollection<Category> Categories
        {
            get { return new ReadOnlyCollection<Category>(new List<Category>(_categories)); }
        }

        public virtual ICollection<Order> Orders { get; } = new HashSet<Order>();

        public override string ToString()
        {
            var r = "Id: " + Id + Environment.NewLine +
                    "Name: " + Name + Environment.NewLine +
                    "Price: " + Price + Environment.NewLine +
                    "Categories: ";
            foreach (var category in Categories)
            {
                r += category.DisplayName + ", ";
            }
            r += Environment.NewLine;

            return r;
        }

        public virtual void AddCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (!_categories.Contains(category))
            {
                _categories.Add(category);
                category.AddProduct(this);
            }
        }

        public virtual void RemoveCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (!_categories.Contains(category))
            {
                _categories.Remove(category);
                category.RemoveProduct(this);
            }
        }
    }
}