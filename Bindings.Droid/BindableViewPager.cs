// BindableViewPager.cs
// (c) Copyright 2013 Tomasz Cielecki http://ostebaronen.dk
//
// Derivative of BindableViewPager.cs by Steve Dunford
// http://slodge.blogspot.com/2013/02/binding-to-androids-horizontal-pager.html
// which is a derivative of MvxBindableListView.cs from the
// MvvmCross project by Stuart Lodge
// https://github.com/slodge/MvvmCross/blob/vnext/Cirrious/Cirrious.MvvmCross.Binding.Droid/Views/MvxBindableListView.cs
//
// Licensed using Microsoft Public License (Ms-PL)
// Full License description can be found in the LICENSE
// file.
// 
// Project Lead - Tomasz Cielecli, @Cheesebaron, tomasz@ostebaronen.dk

using System.Collections;
using System.Windows.Input;
using Android.Content;
using Android.Util;
using Cirrious.MvvmCross.Binding.Attributes;
using Cirrious.MvvmCross.Binding.Droid;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace Cheesebaron.MvvmCross.Bindings.Droid
{
    public class BindableViewPager
        : Android.Support.V4.View.ViewPager
    {
        public BindableViewPager(Context context, IAttributeSet attrs)
            : this(context, attrs, new MvxBindablePagerAdapter(context))
        { }

        public BindableViewPager(Context context, IAttributeSet attrs, MvxBindablePagerAdapter adapter)
            : base(context, attrs)
        {
            var itemTemplateId = MvxBindableListViewHelpers.ReadAttributeValue(
                context, attrs, 
                MvxAndroidBindingResource.Instance.BindableListViewStylableGroupId, 
                MvxAndroidBindingResource.Instance.BindableListItemTemplateId);
            adapter.ItemTemplateId = itemTemplateId;
            Adapter = adapter;
            SetUpEventListeners();
        }

        public new MvxBindablePagerAdapter Adapter
        {
            get { return base.Adapter as MvxBindablePagerAdapter; }
            set
            {
                var existing = Adapter;
                if (existing == value)
                    return;

                if (existing != null && value != null)
                {
                    value.ItemsSource = existing.ItemsSource;
                    value.ItemTemplateId = existing.ItemTemplateId;
                }

                base.Adapter = value;
            }
        }

        [MvxSetToNullAfterBinding]
        public IEnumerable ItemsSource
        {
            get { return Adapter.ItemsSource; }
            set { Adapter.ItemsSource = value; }
        }

        public int ItemTemplateId
        {
            get { return Adapter.ItemTemplateId; }
            set { Adapter.ItemTemplateId = value; }
        }

        private void SetUpEventListeners()
        {
            base.PageSelected += (sender, args) => ExecuteCommand(PageSelected, args.P0);
            base.Click += (sender, args) => ExecuteCommand(Click, null);
            base.LongClick += (sender, args) => ExecuteCommand(LongClick, null);
        }

        public new ICommand PageSelected { get; set; }
        public new ICommand Click { get; set; }
        public new ICommand LongClick { get; set; }

        protected void ExecuteCommand(ICommand command, int? position)
        {
            if (null == command) return;

            if (position.HasValue)
            {
                if (!command.CanExecute(position.Value)) return;
                command.Execute(position.Value);    
            }
            else
            {
                if (!command.CanExecute(null)) return;
                command.Execute(null);
            }
        }
    } 
}