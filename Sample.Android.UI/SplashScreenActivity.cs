using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace Sample.Droid.UI
{
    [Activity(Label = "Splushy", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class SplashScreenActivity
        : MvxBaseSplashScreenActivity
    {
        public SplashScreenActivity()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}

