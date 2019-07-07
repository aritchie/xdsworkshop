using System;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using Xamarin.Forms;


namespace XamDevSummit.EscRoom
{
    public partial class App : PrismApplication
    {
        protected override async void OnInitialized()
        {
            this.InitializeComponent();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewModelTypeName = viewType.FullName.Replace("Page", "ViewModel");
                var viewModelType = Type.GetType(viewModelTypeName);
                return viewModelType;
            });
            await this.NavigationService.Navigate("NavigationPage/MainPage");
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
        }
    }
}
