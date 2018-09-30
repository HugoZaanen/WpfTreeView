namespace WpfTreeView.Directory.ViewModels
{
    /// <summary>
    /// base view model that fires Poperty changed event as needed
    /// </summary>
    [implementPropertyChanged]
    class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// the event that is fired when any child changes its value
        /// </summary>
        public event PorpertyChangedEventHandler PropertyChanged = (sender, e) => {};
    }
}
