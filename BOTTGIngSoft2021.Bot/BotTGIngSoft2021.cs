// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Service.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;

namespace BOTTGIngSoft2021.Bot
{
    public class BotTGIngSoft2021<T> : ActivityHandler where T:Dialog
    {
        private readonly BotState _userState;
        private readonly BotState _conversationState;
        private readonly Dialog _dialog;
        private IUsersBotService _usersBotService;

        public BotTGIngSoft2021(UserState userState, ConversationState conversationState, T dialog, IUsersBotService usersBotService)
        {
            _userState = userState;
            _conversationState = conversationState;
            _dialog = dialog;
            _usersBotService = usersBotService;
        }
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Bienvenido a BotTGIngSoft2021!"), cancellationToken);
                }
            }
        }
        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);
            await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        }
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {

            //await SaveUser(turnContext);
            
            await _dialog.RunAsync(
                turnContext,
                _conversationState.CreateProperty<DialogState>(nameof(DialogState)),
                cancellationToken
                ); 
        }

        private async Task SaveUser(ITurnContext<IMessageActivity> turnContext)
        {
            var userBot = new UsersBot();
            userBot.Id = turnContext.Activity.From.Id;
            userBot.UserNameChannel = turnContext.Activity.From.Name;
            userBot.Channel = turnContext.Activity.ChannelId;
            userBot.RegisterDate = DateTime.UtcNow;

            var user = _usersBotService.Get(userBot.Id);

            if (user == null)
            {
                _usersBotService.Insert(userBot);
            }
        }
    }
}
