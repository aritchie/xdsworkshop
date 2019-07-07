using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamDevSummit.EscRoom.Infrastructure;


namespace XamDevSummit.EscRoom.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Shiny.iOSShinyHost.Init(new Startup());
            Forms.Init();
            this.LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
