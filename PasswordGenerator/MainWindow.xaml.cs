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

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGeneratePasswordClick(object sender, RoutedEventArgs e)
        {
            List<char> symbol = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '<', '>', '?', '(', ')', '/', '*', '-', '+', '=','a', 'b',
                                                'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 
                                                'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
                                                'U', 'V', 'W', 'X', 'Y', 'Z' };

            StringBuilder password = new StringBuilder();



            for (int i = 0; i < 30; i++)
            {
                int rndNumber = rnd.Next(0, 72);

                password.Append(symbol[rndNumber]);
            }

            textBoxPassword.Text = password.ToString();

            buttonSavePassword.IsEnabled = true;
        }
    }
}
