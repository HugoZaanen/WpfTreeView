﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfTreeView.Directory.Data
{
    /// <summary>
    /// info aboput the directory item
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get;set;}
        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// the Name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }
    }
}
