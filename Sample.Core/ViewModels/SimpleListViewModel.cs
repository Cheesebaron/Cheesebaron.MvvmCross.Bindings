using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Platform.Diagnostics;
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

        private static void ShowPageChanged(int toPage)
        {
            MvxTrace.TaggedTrace("SimpleListViewModel", "Page changed to {0}", toPage);
        }

        public ICommand PageChanged
        {
            get { return new MvxRelayCommand<int>(ShowPageChanged); }
        }
    }
}
