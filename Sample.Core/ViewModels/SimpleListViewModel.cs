using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;

namespace Sample.Core.ViewModels
{
    public class SimpleListViewModel
        : MvxViewModel
    {
        private ObservableCollection<SimpleViewModel> _items;
        public ObservableCollection<SimpleViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        public SimpleListViewModel()
        {
            Items = new ObservableCollection<SimpleViewModel>();
            for (var i = 0; i < 5; i++)
                Items.Add(new SimpleViewModel { Name = "Item " + i, Description = "I am Item " + i });
        }

        private static void ShowItemPageChanged(SimpleViewModel toPage)
        {
            MvxTrace.TaggedTrace("SimpleListViewModel", "Page changed to {0}", toPage.Name);
        }

        public ICommand ItemPageChangedCommand
        {
            get { return new MvxCommand<SimpleViewModel>(ShowItemPageChanged); }
        }

        private static void ShowPageChanged(int toPage)
        {
            MvxTrace.TaggedTrace("SimpleListViewModel", "Page changed to {0}", toPage);
        }

        public ICommand PageChangedCommand
        {
            get { return new MvxCommand<int>(ShowPageChanged); }
        }
    }
}
