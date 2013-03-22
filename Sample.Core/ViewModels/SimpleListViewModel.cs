using System.Collections.ObjectModel;
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
    }
}
