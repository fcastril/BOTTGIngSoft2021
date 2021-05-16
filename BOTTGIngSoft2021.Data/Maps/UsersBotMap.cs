using BOTTGIngSoft2021.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BOTTGIngSoft2021.Data.Maps
{
    public class UsersBotMap
    {
        public UsersBotMap(EntityTypeBuilder<UsersBot> entityBuilder)
        {
            entityBuilder.HasKey(t => t.CodeId);
            entityBuilder.Property(t => t.Id).IsRequired();
            entityBuilder.HasIndex(t => t.Id);
        }
    }
}
