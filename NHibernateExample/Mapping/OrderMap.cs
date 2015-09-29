using FluentNHibernate.Mapping;
using NHibirnateExample.Domain;

namespace NHibirnateExample.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.NumberOfItems).Column("NumberOfItems");
            Map(x => x.Customer).Column("Customer");
            References(x => x.Product, ProductMap.ProductIdField);
        }
    }
}