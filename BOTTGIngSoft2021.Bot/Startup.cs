// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EmptyBot v4.12.2

using BOTTGIngSoft2021.Bot.Dialogs;
using BOTTGIngSoft2021.Bot.Services.LUIS;
using BOTTGIngSoft2021.Repo;
using BOTTGIngSoft2021.Repo.Interfaces;
using BOTTGIngSoft2021.Repo.Repositories;
using BOTTGIngSoft2021.Service.Interfaces;
using BOTTGIngSoft2021.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Azure.Blobs;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BOTTGIngSoft2021.Bot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var storage = new BlobsStorage(
                Configuration.GetSection("StorageConnectionString").Value ,
                Configuration.GetSection("StorageContainer").Value
                );

            var userState = new UserState(storage);
            services.AddSingleton(userState);

            var conversationState = new ConversationState(storage);
            services.AddSingleton(conversationState);



            services.AddControllers().AddNewtonsoftJson();



            string stringConnection = Configuration.GetConnectionString("Azure");
            services.AddDbContext<BOTTGIngSoft2021Context>(options => options.UseSqlServer(stringConnection));


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepositoryIntent), typeof(RepositoryIntent));
            services.AddTransient<IIntentService, IntentService>();
            services.AddTransient<IUsersBotService, UsersBotService>();

            // Create the Bot Framework Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            services.AddSingleton<ILuisService, LuisService>();
            services.AddTransient<RootDialog>();

            services.AddTransient<IBot, BotTGIngSoft2021<RootDialog>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseWebSockets()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            // app.UseHttpsRedirection();
        }
    }
}
