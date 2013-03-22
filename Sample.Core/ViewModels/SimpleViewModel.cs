using Cirrious.MvvmCross.ViewModels;

namespace Sample.Core.ViewModels
{
    public class SimpleViewModel
        : MvxNotifyPropertyChanged
    {
        private string _name;
        private string _description;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }
    }
}
