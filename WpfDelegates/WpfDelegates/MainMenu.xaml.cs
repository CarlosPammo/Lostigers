using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfDelegates
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BtnEntry_Click(object sender, RoutedEventArgs e)
        {
            ListContact mw = new ListContact();
            mw.Show();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
