using Autofac;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Sigga
{
    public partial class App : Application
    {

        static IContainer container;
        static readonly ContainerBuilder builder = new ContainerBuilder();

        public App()
        {
            InitializeComponent();
            RegistreModalException();
            //DependencyService.Register<MockDataStore>();
            //DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);
            MainPage = new Menu();
        }

        private void RegistreModalException()
        {
            MessagingCenter.Subscribe<string>(Current, "PopPupErro", _ =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Current.MainPage.DisplayAlert("Ocorreu um erro no APP.", "Entre em contato com a nosse equipe :)", "ok");
                });
            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        //public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        //{
        //    builder.RegisterType<T>().As<TInterface>();
        //}
        //public static void BuildContainer()
        //{
        //    container = builder.Build();
        //}
    }
}
