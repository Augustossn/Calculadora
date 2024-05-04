using System.Data;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                textBox1.Text += e.KeyChar;
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                buttonEquals_Click(sender, e);
            }
        }

        private void buttonOperation_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Button button = (Button)sender;
                textBox1.Text += $"{button.Text}"; 
            }
        }
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string expression = textBox1.Text;
                DataTable dt = new DataTable();
                try
                {
                    double result = Convert.ToDouble(dt.Compute(expression, ""));
                    textBox1.Text = result.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }

            }
        }
        private void buttonDelente_CLick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
