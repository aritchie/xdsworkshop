using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;


namespace XamDevSummit.EscapeRoom
{
    public abstract class ViewModel : ReactiveObject,
                                      IAutoInitialize,
                                      IInitializeAsync,
                                      INavigatedAware,
                                      IPageLifecycleAware,
                                      IDestructible,
                                      IConfirmNavigationAsync
    {
        CompositeDisposable deactivateWith;
        public CompositeDisposable DeactivateWith
        {
            get
            {
                if (this.deactivateWith == null)
                    this.deactivateWith = new CompositeDisposable();

                return this.deactivateWith;
            }
            set => this.deactivateWith = value;
        }

        public CompositeDisposable DestroyWith { get; set; } = new CompositeDisposable();


        public virtual void OnAppearing()
        {
        }


        public virtual void OnDisappearing()
        {
            this.deactivateWith?.Dispose();
            this.deactivateWith = null;
        }


        public virtual Task InitializeAsync(INavigationParameters parameters) => Task.CompletedTask;
        public virtual void OnNavigatedFrom(INavigationParameters parameters) {}
        public virtual void OnNavigatedTo(INavigationParameters parameters) {}


        public virtual void Destroy()
        {
            this.deactivateWith?.Dispose();
            this.DestroyWith?.Dispose();
        }


        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) => Task.FromResult(true);
        [Reactive] public bool IsBusy { get; protected set; }
        [Reactive] public string Title { get; protected set; }

        protected void BindBusyCommand(IReactiveCommand reactiveCommand)
            => reactiveCommand
                .IsExecuting
                .SubOnMainThread(
                    x => this.IsBusy = x,
                    _ => this.IsBusy = false,
                    () => this.IsBusy = false
                )
                .DisposeWith(this.DestroyWith);
    }
}
