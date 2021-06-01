using BOTTGIngSoft2021.Bot.Services.LUIS;
using BOTTGIngSoft2021.Service.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading;
using System.Threading.Tasks;

namespace BOTTGIngSoft2021.Bot.Dialogs
{
    public class RootDialog : ComponentDialog
    {
        private readonly ILuisService _luisService;
        private readonly IIntentService _intentService;
        public RootDialog(ILuisService luisService, IIntentService intentService)
        {
            _luisService = luisService;
            _intentService = intentService;
            var waterfallSteps = new WaterfallStep[]
            {
                InitialProcess,
                FinalProcess
            };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            AddDialog(new GeneralDialog(luisService, _intentService));

            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> InitialProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var luisResult = await _luisService.luisRecognizer.RecognizeAsync(stepContext.Context, cancellationToken);
            return await ManageIntentions(stepContext, luisResult, cancellationToken);
        }

        private async Task<DialogTurnResult> ManageIntentions(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            return await IntentGeneral(stepContext, luisResult, cancellationToken);
        }

        #region IntentLuis

        private async Task<DialogTurnResult> IntentGeneral(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            return await stepContext.BeginDialogAsync(nameof(GeneralDialog), luisResult, cancellationToken = cancellationToken);
        }

        #endregion

        private async Task<DialogTurnResult> FinalProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
