using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Sample.Core;

namespace Sample.Droid.UI
{
    public class Setup
        : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IList<Assembly> AndroidViewAssemblies
        {
            get 
            {
                var assemblies = base.AndroidViewAssemblies;
                assemblies.Add(typeof(Cheesebaron.MvvmCross.Bindings.Droid.BindableViewPager).Assembly);
                return assemblies;
            }
        }
    }
}