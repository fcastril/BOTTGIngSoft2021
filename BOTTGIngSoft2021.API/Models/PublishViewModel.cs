namespace BOTTGIngSoft2021.API.Models
{
    public class PublishViewModel
    {
        public string VersionId { get; set; }
        public bool IsStaging { get; set; }
        public bool DirectVersionPublish { get; set; }
        public PublishViewModel()
        {
            VersionId = "0.1";
        }
    }
}
