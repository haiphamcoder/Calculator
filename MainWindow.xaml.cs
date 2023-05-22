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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] NumberKeyPad = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? text = button.Content.ToString();
            if (NumberKeyPad.Contains(text))
            {
                if (Result.Text == "0")
                {
                    Result.Text = text;
                }
                else if (Result.Text.Length < 10)
                {
                    Result.Text += text;
                }
            }
            else if (button == btnC)
            {
                Result.Text = "0";
            }
            else if (button == btnBackspace)
            {
                if (Result.Text.Length > 1)
                {
                    Result.Text = Result.Text.Substring(0, Result.Text.Length - 1);
                }
                else
                {
                    Result.Text = "0";
                }
            }
            else if (button == btnPlusMinus)
            {
                if (Result.Text != "0")
                {
                    if (Result.Text[0] == '-' && Result.Text.Length > 1)
                    {
                        Result.Text = Result.Text.Substring(1);
                    }
                    else
                    {
                        Result.Text = "-" + Result.Text;
                    }
                }
            }
        }
    }
}
