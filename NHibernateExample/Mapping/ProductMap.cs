using FluentNHibernate.Mapping;
using NHibirnateExample.Domain;

namespace NHibirnateExample.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public const string ProductIdField = "ProductId";

        public ProductMap()
        {
            Table("Products");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Price);
            HasManyToMany(x => x.Categories)
                .Table("ProductsCategories")
                .ParentKeyColumn(ProductIdField)
                .ChildKeyColumn(CategoryMap.CategoryIdField)
                .Access.LowerCaseField(Prefix.Underscore)
                .Cascade.SaveUpdate()
                .AsSet()
                .Inverse();
            HasMany(x => x.Orders)
                .KeyColumn(ProductIdField)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}