namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {

        private string number1 = "";
        private string number2 = "";
        private string tempOperator;
        private string op;
        const double max = 999999999999999;
        const double min = -99999999999999;
        const int maxc = 15;
        public MainPage()
        {
            InitializeComponent();

        }
        private void Clear(object sender, EventArgs e)
        {
            message.Text = "";
            calculate.Text = "";
            input.Text = "";
            number1 = "";
            number2 = "";
            tempOperator = "";
            op = "";
        }
        private void Delete(object sender, EventArgs e)
        {
            message.Text = "";
            if (input.Text.Length != 0)
            {
                input.Text = input.Text.Substring(0, input.Text.Length - 1);
            }
            ProvjeraDuzine();

        }

        private void ProvjeraDuzine()
        {
            if (input.Text.Length > 9)
            {
                input.FontSize = 40;
            }
            else
            {
                input.FontSize = 55;
            }
        }
        private void InputNumber(object sender, EventArgs e)
        {
            message.Text = "";
            Button button = (Button)sender;
            int number = int.Parse(button.Text);
            ProvjeraDuzine();
            if (input.Text.Length < 15)
            {
                input.Text += number.ToString();
            }
        }

        private void AddDot(object sender, EventArgs e)
        {
            message.Text = "";
            if (input.Text.Contains(","))
            {
                message.Text = "Vec postoji ','!";
                return;
            }
            else
            {
                ProvjeraDuzine();
                if (input.Text.Length == 0)
                {
                    input.Text += "0";
                }
                input.Text += ",";
            }
        }

        private void NegationNumber(object sender, EventArgs e)
        {
            if (input.Text!="")
            {
                input.Text = (double.Parse(input.Text) * -1).ToString();
            }
            
        }

        
        private void Calculation()
        {
            if (number2 == "0" && tempOperator == "/")
            {
                message.Text = "Dijeljenje sa 0 nije moguce!";
                calculate.Text = "";
                input.Text = "";
                number1 = "";
                number2 = "";
                tempOperator = "";
            }
            else if (number1 != null && number2 != null && number1 != "" && number2 != "")
            {
                double result;
                if (tempOperator == "+")
                {
                    result = Convert.ToDouble(number1) + Convert.ToDouble(number2);
                }else if(tempOperator == "-")
                {
                    result = Convert.ToDouble(number1) - Convert.ToDouble(number2);
                }else if(tempOperator== "*")
                {
                    result = Convert.ToDouble(number1) * Convert.ToDouble(number2);
                }else if(tempOperator == "/")
                {
                    result = Convert.ToDouble(number1) / Convert.ToDouble(number2);
                }else
                {
                    result = (Convert.ToDouble(number1) / 100) * Convert.ToDouble(number2);
                }

               

                if (result > max || result < min)
                {
                    message.Text = "Previše velik / previše mal broj!";
                    calculate.Text = "";
                    input.Text = "";
                    number1 = "";
                    number2 = "";
                    tempOperator = "";
                }
                else
                {
                    if (result.ToString().Length > maxc)
                    {
                        string temp = result.ToString().Substring(0, 15);
                        input.Text = temp;
                        ProvjeraDuzine();
                    }
                    else
                    {
                        input.Text = result.ToString();
                        ProvjeraDuzine();
                    }
                    number1 = "";
                    number2 = "";
                    tempOperator = "";
                }
            }
        }
        private void Operate(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            op = button.Text;
            Execution();
        }
        private void Execution()
        {
            message.Text = "";
            if (string.IsNullOrEmpty(input.Text))
            {
                input.Text = "0";
                if (tempOperator == "*" || tempOperator == "/")
                {
                    input.Text = "1";
                }
                else if (tempOperator == "%")
                {
                    input.Text = "100";
                }
            }

            if (number1 == "" && op != "=")
            {
                if (input.Text[input.Text.Length - 1] == ',')
                {
                    number1 = input.Text.Substring(0, input.Text.Length - 1);
                }
                else
                {
                    number1 = input.Text;
                }

                input.Text = "";
                tempOperator = op;
                calculate.Text = number1 + " " + tempOperator;
            }
            else
            {
                if (input.Text[input.Text.Length - 1] == ',')
                {
                    number2 = input.Text.Substring(0, input.Text.Length - 1);
                }
                else
                {
                    number2 = input.Text;
                }

                Calculation();
                if (op != "=")
                {
                    Execution();
                }
                else
                {
                    calculate.Text = "";
                }
                
            }
        }


    }


}