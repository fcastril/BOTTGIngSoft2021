using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Extensions.Configuration;

namespace BOTTGIngSoft2021.Bot.Services.LUIS
{
    public class LuisService: ILuisService
    {
        public LuisRecognizer luisRecognizer { get; set; }
        public LuisService(IConfiguration configuration)
        {
            var luisApplication = new LuisApplication(
                configuration["LuisAppId"],
                configuration["LuisApiKey"],
                configuration["LuisHostName"]
                );

            var recognizerOptions = new LuisRecognizerOptionsV3(luisApplication)
            {
                PredictionOptions = new Microsoft.Bot.Builder.AI.LuisV3.LuisPredictionOptions()
                {
                    IncludeInstanceData = true
                }
            };
            luisRecognizer = new LuisRecognizer(recognizerOptions);
        }
    }
}
