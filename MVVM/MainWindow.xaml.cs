﻿using MVVM.ViewModel;
using System.Data;
using System.Windows;

namespace MVVM {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }
    }
}
