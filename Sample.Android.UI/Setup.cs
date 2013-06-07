using System.Collections.Generic;
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

        protected override IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                var abbreviations = base.ViewNamespaceAbbreviations;
                abbreviations["cmbd"] = "Cheesebaron.MvvmCross.Bindings.Droid";
                return abbreviations;
            }
        }
    }
}