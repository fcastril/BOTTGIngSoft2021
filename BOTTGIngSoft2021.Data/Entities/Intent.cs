namespace BOTTGIngSoft2021.Data.Entities
{
    public class Intent : BaseEntity
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string ReadableType { get; set; }
    }
}
