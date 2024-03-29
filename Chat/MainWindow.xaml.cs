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

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Auth auth = new Auth();
        private readonly AppWindow appWindow = new AppWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            auth.SetCredientals(Login.Text, Pass.Password);
            if (!auth.CredientalsCheck())
            {
                MessageBox.Show("Błąd podczas logowania!", "Auth");
            } else
            {
                this.Hide();
                appWindow.Show();
            }

        }
    }
}
