﻿using System;
using Acr.UserDialogs;
using ReactiveUI;
using Shiny;
using Shiny.Logging;


namespace XamDevSummit.EscRoom
{
    public class GlobalExceptionHandler : IObserver<Exception>, IStartupTask
    {
        readonly IUserDialogs dialogs;
        public GlobalExceptionHandler(IUserDialogs dialogs) => this.dialogs = dialogs;


        public void Start() => RxApp.DefaultExceptionHandler = this;
        public void OnCompleted() { }
        public void OnError(Exception error) { }


        public void OnNext(Exception value)
        {
            Log.Write(value);
            this.dialogs.Alert(value.ToString(), "ERROR");
        }
    }
}