﻿using PLWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : Window
    {
        public test()
        {
            InitializeComponent();
            CategoryVM vm = new CategoryVM();
            List<string> productName = new List<string>();
            foreach (var v in vm.CategoriesList)
            {
                foreach (var a in v.Products)
                {
                    productName.Add(a.Name);
                }

            }

            //this.productName.Text = productName[1];
        }
    }
}
