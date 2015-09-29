using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;
using NHibirnateExample.Domain;

namespace NHibirnateExample.Mapping
{
    public class ProductMap : IAutoMappingOverride<Product>
    {
        public const string ProductIdField = "ProductId";

        public void Override(AutoMapping<Product> mapping)
        {
            mapping.HasManyToMany(x => x.Categories)
                .Table(CategoryMap.ProductsCategoryTable)
                .ParentKeyColumn(ProductIdField)
                .ChildKeyColumn(CategoryMap.CategoryIdField)
                .Access.LowerCaseField(Prefix.Underscore)
                .Cascade.SaveUpdate()
                .AsSet()
                .Inverse();
            mapping.HasMany(x => x.Orders)
                .KeyColumn(ProductIdField)
                .Cascade.AllDeleteOrphan()
                .Inverse();
        }
    }
}