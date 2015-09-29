using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibirnateExample.Mapping.Convention
{
    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(Inflector.Inflector.Pluralize(instance.EntityType.Name));
        }
    }
}