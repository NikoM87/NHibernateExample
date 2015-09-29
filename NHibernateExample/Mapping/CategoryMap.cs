using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;
using NHibirnateExample.Domain;

namespace NHibirnateExample.Mapping
{
    public class CategoryMap : IAutoMappingOverride<Category>
    {
        public const string CategoryIdField = "CategoryId";
        public const string ProductsCategoryTable = "[Products.Categories]";

        public void Override(AutoMapping<Category> mapping)
        {
            mapping.HasManyToMany(x => x.Products)
                .Access.LowerCaseField(Prefix.Underscore)
                .Table(ProductsCategoryTable)
                .ParentKeyColumn(CategoryIdField)
                .ChildKeyColumn(ProductMap.ProductIdField)
                .Cascade.SaveUpdate()
                .AsSet();
        }
    }
}