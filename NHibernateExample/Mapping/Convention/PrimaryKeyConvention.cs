using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibirnateExample.Mapping.Convention
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Native();
            instance.Column("Id");
        }
    }
}