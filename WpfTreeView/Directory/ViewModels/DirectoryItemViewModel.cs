using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTreeView.Directory.Data;

/// <summary>
/// A view model for each directory item
/// </summary>
namespace WpfTreeView.Directory.ViewModels 
{
    class DirectoryItemViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The full path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// the name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// A list of all children contained inside this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; } 

        /// <summary>
        /// indicates if this item can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        /// <summary>
        /// indicates if this item canbe expanded
        /// </summary>
        public bool CenExpand { get { return this.Type != DirectoryItemType.File; } }
        #endregion
        public  bool IsExpanded
        {
            get
            {
               return this.Children.Count(f => f != null);
            }
            set
            {
                //If the UI tells is to expand
                if (value == true)
                    //Find all children
                    Expand();
                else
                    this.ClearChildren();
            }
        }

        #region HelperMethods

        /// <summary>
        /// Removes all children from the list
        /// </summary>
        private void ClearChildren()
        {
            //Clear items
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            //Show the exapnd arrow if we are not a file
            if(this.Type != DirecotryItemType.File)
            {
                this.Chidlren.Add(null);
            }
        }

        /// <summary>
        /// Expands this directory and finds all children
        /// </summary>
        private void Expand()
        {

        }
        #endregion
    }
}
