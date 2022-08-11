using System;
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

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Person = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            Person = 1;
            Main.Content = new Page1();
        }
        private void SecondPlayer_Click(object sender, RoutedEventArgs e)
        {
            Person = 2;
            Main.Content = new Page1();
        }
    }
}
