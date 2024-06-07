using System;
using System.Windows.Forms;

namespace NumToWord
{
    public partial class Form1 : Form
    {
        private string[] units = { "", "one", "two", "three", "four",
      "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
      "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
      "eighteen", "nineteen" };
        private string[] tens = {
      "",        // 0
      "",        // 1
      "twenty",  // 2
      "thirty",  // 3
      "forty",   // 4
      "fifty",   // 5
      "sixty",   // 6
      "seventy", // 7
      "eighty",  // 8
      "ninety"   // 9
    };

        public Form1()
        {
            InitializeComponent();
        }

        private string Convert(int n)
        {
            if (n < 0)
            {
                return "minus " + Convert(-n);
            }

            if (n < 20)
            {
                // for numbers between 0 and 19, we use the units array
                return units[n];
            }

            if (n < 100)
            {
                // for numbers between 20 and 99, we use the tens array and the units array
                return tens[n / 10] + ((n % 10 != 0) ? " " : "") + units[n % 10];
            }

            if (n < 1000)
            {
                // for numbers between 100 and 999, we recursively call convert with the quotient and remainder
                return units[n / 100] + " hundred" + ((n % 100 != 0) ? " and " : "") + Convert(n % 100);
            }

            if (n < 1000000)
            {
                // for numbers between 1000 and 999999, we recursively call convert with the quotient and remainder
                return Convert(n / 1000) + " thousand" + ((n % 1000 != 0) ? " " : "") + Convert(n % 1000);
            }

            if (n < 1000000000)
            {
                // for numbers between 1000000 and 999999999, we recursively call convert with the quotient and remainder
                return Convert(n / 1000000) + " million" + ((n % 1000000 != 0) ? " " : "") + Convert(n % 1000000);
            }

            return Convert(n / 1000000000) + " billion" + ((n % 1000000000 != 0) ? " " : "") + Convert(n % 1000000000);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int n))
            {
                textBox2.Text = Convert(n); // Update textBox2 with converted value
            }
            else
            {
                textBox2.Text = "Please enter a valid number."; // Handle invalid input (optional)
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int n;
            //MessageBox.Show("Do you want to close the frame?"+Convert(n)+, "Confirmation", MessageBoxButtons.YesNo);
            
            //// You can optionally use this button click event for other functionalities
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the frame?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close(); // Close the current form
            }
        }
    }
}
