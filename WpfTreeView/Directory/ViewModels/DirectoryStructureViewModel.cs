using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    /// <summary>
    /// The view model for the application main Directory view
    /// </summary>
    class DirectoryStructureViewModel : BaseViewModel
    {

        #region public properties
        public ObservableCollection<DirectoryItemViewModel> Items { get; set;}

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLocalDrives();
        }

        #endregion
    }
}
