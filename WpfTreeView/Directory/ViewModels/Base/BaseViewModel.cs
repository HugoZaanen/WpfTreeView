using PropertyChanged;
using System.ComponentModel;

namespace WpfTreeView
{
    /// <summary>
    /// base view model that fires Poperty changed event as needed
    /// </summary>
    
    class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// the event that is fired when any child changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};
    }
}
