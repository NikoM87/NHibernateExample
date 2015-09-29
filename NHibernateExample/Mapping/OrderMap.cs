using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibirnateExample.Domain;

namespace NHibirnateExample.Mapping
{
    public class OrderMap : IAutoMappingOverride<Order>
    {
        public void Override(AutoMapping<Order> mapping)
        {
            mapping.References(x => x.Product, ProductMap.ProductIdField);
        }
    }
}