using FluentNHibernate.Automapping;
using NHibirnateExample.Domain;

namespace NHibirnateExample
{
    internal class ModelGenerator
    {
        public AutoPersistenceModel Generate()
        {
            return new AutoPersistenceModel()
                .Conventions.AddFromAssemblyOf<ModelGenerator>()
                .UseOverridesFromAssemblyOf<ModelGenerator>()
                .AddEntityAssembly(typeof (Product).Assembly)
                .Where(x => x.Namespace.EndsWith(nameof(Domain)));
        }
    }
}