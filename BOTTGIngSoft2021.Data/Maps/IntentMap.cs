using BOTTGIngSoft2021.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BOTTGIngSoft2021.Data.Maps
{
    public class IntentMap
    {
        public IntentMap(EntityTypeBuilder<Intent> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
