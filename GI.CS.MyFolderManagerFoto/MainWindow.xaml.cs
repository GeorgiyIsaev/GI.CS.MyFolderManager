﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GI.CS.MyFolderManagerFoto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Column_0.Width = new GridLength(0);
        }

        private void Button_DeleteMinCount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_CatalogMatch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
