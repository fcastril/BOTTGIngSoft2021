using System;

namespace BOTTGIngSoft2021.Data.Entities
{
    public class UsersBot : BaseEntity
    {
        public string Channel { get; set; }
        public DateTime RegisterDate { get; set; }
        public string UserNameChannel { get; set; }
    }
}
