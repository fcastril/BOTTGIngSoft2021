using Microsoft.Bot.Builder.AI.Luis;

namespace BOTTGIngSoft2021.Bot.Services.LUIS
{
    public interface ILuisService
    {
        public LuisRecognizer luisRecognizer { get; set; }
    }
}
