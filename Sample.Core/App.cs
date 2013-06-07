using Cirrious.MvvmCross.ViewModels;
using Sample.Core.ViewModels;

namespace Sample.Core
{
    public class App
        : MvxApplication
    {
        public App()
        {
            RegisterAppStart<SimpleListViewModel>();
        }
    }
}
