using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        private string[] operators = { "+", "−", "✕", "÷" };
        private string? operand1 = "0";
        private string? math = "";
        private string? operand2 = "0";

        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? text = button.Content.ToString();
            if (NumberKeyPad.Contains(text))
            {
                if (Result.Text == "0" || Result.Text == "Error")
                {
                    Result.Text = text;
                    EnableFunctionButtons(true);
                }
                else if (Result.Text.Length < 10)
                {
                    Result.Text += text;
                }
            }
            else if (operators.Contains(text))
            {
                
            }
            else if (button == btnDot)
            {
                if (!Result.Text.Contains('.'))
                {
                    Result.Text += ".";
                }
            }
            else if (button == btnC)
            {
                Result.Text = "0";
                math = "";
                operand1 = "0";
                operand2 = "0";
                EnableFunctionButtons(true);
            }
            else if (button == btnCE)
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
            else if (button == btnCal)
            {
                
            }
        }

        private string? Calculate(string? operand1, string? operand2, string? math)
        {
            double a = Convert.ToDouble(operand1);
            double b = Convert.ToDouble(operand2);
            string? result = operand1;
            switch (math)
            {
                case "+": result = Convert.ToString(a + b); break;
                case "−": result = Convert.ToString(a - b); break;
                case "✕": result = Convert.ToString(a * b); break;
                case "÷":
                    if ((int)b == b && b == 0)
                    {
                        result = "Error";
                        EnableFunctionButtons(false);
                    }
                    else
                    {
                        result = Convert.ToString(a / b);
                    }
                    break;
            }
            return result;
        }

        private void EnableFunctionButtons(bool status)
        {
            btnDivide.IsEnabled = status;
            btnMultiple.IsEnabled = status;
            btnPlusMinus.IsEnabled = status;
            btnCal.IsEnabled = status;
            btnMinus.IsEnabled = status;
            btnAdd.IsEnabled = status;
            btnDot.IsEnabled = status;
            btnCE.IsEnabled = status;
            btnBackspace.IsEnabled = status;
        }
    }
}
