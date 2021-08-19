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
using BE;
using PLWPF.Model;
using PLWPF.ViewModel;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StoreVM storevm;

        public MainWindow()
        {
            InitializeComponent();
            storevm = new StoreVM();
            MyUserControls.TabControlOfShop tc = new MyUserControls.TabControlOfShop();
            this.store.ItemsSource = storevm.store.StoresList.Select(t => t.Name);
        }

        private void Button_Click_QR(object sender, RoutedEventArgs e)
        {
            ShoppingCardVM scVM = new ShoppingCardVM();
            scVM.shoppingCart.Store = storevm.store.StoresList.Where(t=>t.Name==(String)this.store.SelectedItem).FirstOrDefault();
            scVM.shoppingCart.BuyDate = (DateTime)this.date.SelectedDate;
        }

        private void Button_Click_SC(object sender, RoutedEventArgs e)
        {
            ShoppingCardVM scVM = new ShoppingCardVM();
            scVM.shoppingCart.Store = storevm.store.StoresList.Where(t => t.Name == (String)this.store.SelectedItem).FirstOrDefault();
            scVM.shoppingCart.BuyDate = (DateTime)this.date.SelectedDate;
        }
    }
}

