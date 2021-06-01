using BOTTGIngSoft2021.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BOTTGIngSoft2021.Data.Maps
{
    public class IntentMap
    {
        public IntentMap(EntityTypeBuilder<Intent> entityBuilder)
        {
            entityBuilder.HasKey(t => t.CodeId);
            entityBuilder.Property(t => t.Id).IsRequired();
            entityBuilder.HasIndex(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.HasIndex(t => t.Name);
            entityBuilder.Property(t => t.Answer).IsRequired();
        }
    }
}
