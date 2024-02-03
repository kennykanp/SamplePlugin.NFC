using MauiAppNFC.ViewModels;

namespace MauiAppNFC
{
    public partial class App : Application
    {
        public App(IServiceProvider provider)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            var viewModel = provider.GetService<MainViewModel>();
            MainPage = new MainPage(viewModel);
        }
    }
}
