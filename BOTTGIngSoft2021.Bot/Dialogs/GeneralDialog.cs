using BOTTGIngSoft2021.Bot.Services.LUIS;
using BOTTGIngSoft2021.Service.Interfaces;
using BOTTGIngSoft2021.Service.Services;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BOTTGIngSoft2021.Bot.Dialogs
{
    public class GeneralDialog : ComponentDialog
    {
        private readonly ILuisService _luisService;
        private readonly IIntentService _intentService;
        public GeneralDialog(ILuisService luisService, IIntentService intentService)
        {
            var waterfallSteps = new WaterfallStep[]
            {
               MessageGeneral
            };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            _luisService = luisService;
            _intentService = intentService;
        }

        private async Task<DialogTurnResult> MessageGeneral(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {

            var luisResult = await _luisService.luisRecognizer.RecognizeAsync(stepContext.Context, cancellationToken);
            var topIntent = luisResult.GetTopScoringIntent();
            var ret = _intentService.GetName(topIntent.intent);

            await stepContext.Context.SendActivityAsync($"{ret.Answer}");

            return await stepContext.ContinueDialogAsync(cancellationToken);
        }
    }
}
