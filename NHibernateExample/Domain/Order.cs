using System;

namespace NHibirnateExample.Domain
{
    public class Order
    {
        protected Order()
        {
        }

        public Order(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            product.Orders.Add(this);
            Product = product;
        }

        public virtual int Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual int NumberOfItems { get; set; }
        public virtual string Customer { get; set; }
    }
}