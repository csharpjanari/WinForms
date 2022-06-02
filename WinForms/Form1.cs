namespace WinForms
{
    public partial class CalculatorForm : Form
    {
        #region variables
        //simple calculator support only these operations
        string[] _operatorList = new string[]
        {
            "+",
            "-",
            "/",
            "*"
        };

        //resrvednumber1 is before operator entered, 2 will be set after = 

        double? _reservedNumber1 = null, _reservedNumber2 = null;

        //we need to know which operation entered, 2 will be set after =

        string _operator = null;

        bool _clearText = false;
        #endregion
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // all buttond will be handled here

            var text = ((Button)sender).Text;

            //if the first number an operator, we need to store first value

            var isOperator = _operatorList.Any(p => p == text);
            if (isOperator)
            {
                if (double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber1 = temp;
                    txtInput.Clear();
                    lblResult.Text = $"{_reservedNumber1} {text}";
                    _operator = text;
                }
            }
            else
            if (text == "=")
            {
                if (double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber2 = temp;
                }
                Calculate();
                txtInput.Clear();
            }
            else
            {
                if(_clearText)
                {
                    txtInput.Text = text;
                }
                else
                {
                    txtInput.Text += text;
                    _clearText = false;
                }
                
            }         
        }

        private void Calculate()
        {
            double? result = 0;
            switch(_operator)
            {
                case "+":
                    result = _reservedNumber2 + _reservedNumber1;
                    break;
                case "/":
                    result = _reservedNumber1 / _reservedNumber2;
                    break;
                case "-":
                    result = _reservedNumber1 - _reservedNumber2;
                    break;
                case "*":
                    result = _reservedNumber2 * _reservedNumber1;
                    break;
                default:
                    break;
            }
            lblResult.Text = result.ToString();
        }

        private void button16_Click(object sender , EventArgs e)
        {
            txtInput.Clear();
            lblResult.Text = String.Empty;
        }

    }
}
