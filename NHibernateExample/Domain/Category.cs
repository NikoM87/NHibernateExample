using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NHibirnateExample.Domain
{
    public class Category
    {
        private readonly ISet<Product> _products = new HashSet<Product>();
        public virtual int Id { get; set; }
        public virtual string DisplayName { get; set; }

        public virtual IReadOnlyCollection<Product> Products
        {
            get { return new ReadOnlyCollection<Product>(new List<Product>(_products)); }
        }

        public virtual void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (!_products.Contains(product))
            {
                _products.Add(product);
                product.AddCategory(this);
            }
        }

        public virtual void RemoveProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (!_products.Contains(product))
            {
                _products.Remove(product);
                product.RemoveCategory(this);
            }
        }
    }
}