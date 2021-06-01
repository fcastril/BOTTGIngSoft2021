using BOTTGIngSoft2021.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BOTTGIngSoft2021.Data.Maps
{
    public class ExampleMap
    {
        public ExampleMap(EntityTypeBuilder<Example> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
        }
    }
}
