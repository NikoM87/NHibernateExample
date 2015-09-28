using FluentNHibernate.Mapping;
using NHibirnateExample.Domain;

namespace NHibirnateExample.Mapping
{
    internal class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Category).Column("Category");
            Map(x => x.Name).Column("Name");
            Map(x => x.Price).Column("Price");
        }
    }
}