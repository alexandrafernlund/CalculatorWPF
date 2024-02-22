using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorWPF
{
    public partial class MainWindow : Window
    {
        private string currentOperation = string.Empty;
        private double firstNumber = 0;
        private bool isNewNumber = true;

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text == "-" && isNewNumber)
            {
                isNewNumber = false;
            }

            if (isNewNumber)
            {
                Display.Text = string.Empty;
                isNewNumber = false;
            }

            Display.Text += ((Button)sender).Content.ToString();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                if (!string.IsNullOrEmpty(currentOperation))
                {
                    double secondNumber = double.Parse(Display.Text);
                    switch (currentOperation)
                    {
                        case "+":
                            firstNumber += secondNumber;
                            break;
                        case "-":
                            firstNumber -= secondNumber;
                            break;
                        case "*":
                            firstNumber *= secondNumber;
                            break;
                        case "/":
                            if (secondNumber != 0)
                                firstNumber /= secondNumber;
                            else
                                MessageBox.Show("Cannot divide by zero!");
                            break;
                    }
                    Display.Text = firstNumber.ToString();
                }

                isNewNumber = true;
                currentOperation = ((Button)sender).Content.ToString();
                firstNumber = double.Parse(Display.Text);
            }
            else
            {
                if (((Button)sender).Content.ToString() == "-")
                {
                    Display.Text = "-";
                }
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentOperation) && !isNewNumber)
            {
                double secondNumber = double.Parse(Display.Text);
                switch (currentOperation)
                {
                    case "+":
                        firstNumber += secondNumber;
                        break;
                    case "-":
                        firstNumber -= secondNumber;
                        break;
                    case "*":
                        firstNumber *= secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            firstNumber /= secondNumber;
                        else
                            MessageBox.Show("Cannot divide by zero!");
                        break;
                }
                Display.Text = firstNumber.ToString();
                isNewNumber = true;
                currentOperation = string.Empty;
            }
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains(","))
            {
                Display.Text += ",";
                isNewNumber = false;
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                HandleNumericInput(((int)e.Key - (int)Key.D0).ToString());
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                HandleNumericInput(((int)e.Key - (int)Key.NumPad0).ToString());
            }
            else if (e.Key == Key.Add || e.Key == Key.OemPlus)
            {
                HandleOperatorInput("+");
            }
            else if (e.Key == Key.Subtract || e.Key == Key.OemMinus)
            {
                HandleOperatorInput("-");
            }
            else if (e.Key == Key.Multiply)
            {
                HandleOperatorInput("*");
            }
            else if (e.Key == Key.Divide || e.Key == Key.OemQuestion)
            {
                HandleOperatorInput("/");
            }
            else if (e.Key == Key.Enter)
            {
                Equal_Click(null, null);
            }
            else if (e.Key == Key.Decimal || e.Key == Key.OemComma)
            {
                Comma_Click(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                Display.Text = string.Empty;
                isNewNumber = true;
                currentOperation = string.Empty;
                firstNumber = 0;
            }
        }

        private void HandleNumericInput(string input)
        {
            if (isNewNumber)
            {
                Display.Text = string.Empty;
                isNewNumber = false;
            }
            Display.Text += input;
        }

        private void HandleOperatorInput(string input)
        {
            if (!isNewNumber)
            {
                if (!string.IsNullOrEmpty(currentOperation))
                {
                    double secondNumber = double.Parse(Display.Text);
                    switch (currentOperation)
                    {
                        case "+":
                            firstNumber += secondNumber;
                            break;
                        case "-":
                            firstNumber -= secondNumber;
                            break;
                        case "*":
                            firstNumber *= secondNumber;
                            break;
                        case "/":
                            if (secondNumber != 0)
                                firstNumber /= secondNumber;
                            else
                                MessageBox.Show("Cannot divide by zero!");
                            break;
                    }
                    Display.Text = firstNumber.ToString();
                }

                isNewNumber = true;
                currentOperation = input;
                firstNumber = double.Parse(Display.Text);
            }
            else
            {
                if (input == "-")
                {
                    Display.Text = "-";
                }
            }
        }
    }
}
