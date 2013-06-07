using Android.App;
using Sample.Core.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace Sample.Droid.UI.Views
{
    [Activity(Label = "ViewPager!!!", LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class ViewPagerShizzleView
        : MvxActivity
    {
        public new SimpleListViewModel ViewModel
        {
            get { return (SimpleListViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_SimpleViewPagerView);
        }
    }
}
