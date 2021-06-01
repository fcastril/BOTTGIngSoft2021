namespace BOTTGIngSoft2021.API.Models
{
    public class ExampleViewModel
    {
        public string Text { get; set; }
        public string IntentName { get; set; }
        public ExampleViewModel(string text, string intentName)
        {
            this.Text = text;
            this.IntentName = intentName;
        }
    }
}
