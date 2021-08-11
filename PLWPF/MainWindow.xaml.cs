﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BL;
using PLWPF.Model;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DataManagement dm = new DataManagement();

            IEnumerable<BE.Category> Categories =dm.GetCategories();
            //List<String> a = Categories.Select(t=>t.Name).ToList();
            this.comboBox.ItemsSource = Categories.Select(t => t.Name).ToList();

        }

        
    }
}

