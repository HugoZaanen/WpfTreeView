using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            var d = new DirectoryStructureViewModel();
            var item1 = d.Items[0];
            d.Items[0].ExpandCommand.Execute(null);
        }
        #endregion       
    }
}
