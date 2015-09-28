using FluentNHibernate.Mapping;
using NHibirnateExample.Domain;

namespace NHibirnateExample.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public const string CategoryIdField = "CategoryId";

        public CategoryMap()
        {
            Table("Category");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.DisplayName);
            HasManyToMany(x => x.Products)
                .Access.LowerCaseField(Prefix.Underscore)
                .Table("ProductsCategories")
                .ParentKeyColumn(CategoryIdField)
                .ChildKeyColumn(ProductMap.ProductIdField)
                .Cascade.SaveUpdate()
                .AsSet();
        }
    }
}