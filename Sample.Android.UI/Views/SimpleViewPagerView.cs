using Android.App;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Sample.Core.ViewModels;

namespace Sample.Droid.UI.Views
{
    [Activity(Label = "ViewPager!!!", LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class ViewPagerShizzleView
        : MvxBindingActivityView<SimpleListViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_SimpleViewPagerView);
        }
    }
}
