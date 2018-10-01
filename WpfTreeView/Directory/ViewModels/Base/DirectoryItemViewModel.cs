using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/// <summary>
/// A view model for each directory item
/// </summary>
namespace WpfTreeView
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
        /// indicates if this item is expanded
        /// </summary>
        public bool isExpand { get { return this.Type != DirectoryItemType.File; } }
 

        public  bool IsExpanded
        {
            get
            {
               return this.Children?.Count(f => f != null) > 0;
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

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="fullPath">The full path of this item</param>/>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            ///create Commands
            this.ExpandCommand = new RelayCommand(Expand);

            //Set path and type
            this.FullPath = FullPath;
            this.Type = type;

            //setup the children as needed
            this.ClearChildren();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Removes all children from the list
        /// </summary>
        private void ClearChildren()
        {
            //Clear items
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            //Show the exapnd arrow if we are not a file
            if(this.Type != DirectoryItemType.File)
            {
                this.Children.Add(null);
            }
        }

        #endregion

        /// <summary>
        /// Expands this directory and finds all children
        /// </summary>
        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;

            //find all children
            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
    }
}
