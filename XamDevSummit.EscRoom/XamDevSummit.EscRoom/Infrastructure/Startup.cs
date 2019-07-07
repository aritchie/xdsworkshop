using System;
using Acr.UserDialogs;
using Microsoft.Extensions.DependencyInjection;
using Plugin.BluetoothLE;
using Shiny;
using Shiny.BluetoothLE;


namespace XamDevSummit.EscRoom.Infrastructure
{
    public class Startup : Shiny.Startup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.UseBleCentral();
            services.AddSingleton<IAdapter>(CrossBleAdapter.Current);
            services.AddSingleton<IUserDialogs>(UserDialogs.Instance);
            services.RegisterStartupTask<GlobalExceptionHandler>();
        }
    }
}
