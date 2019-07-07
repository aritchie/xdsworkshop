using System;
using Android.App;
using Android.Runtime;
using XamDevSummit.EscRoom.Infrastructure;


namespace XamDevSummit.EscRoom.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication() : base() { }
        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }


        public override void OnCreate()
        {
            base.OnCreate();
            Shiny.AndroidShinyHost.Init(this, new Startup());
        }
    }
}