using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String Digit = null;
        bool AnyManuplation = false;
        String Manuplation = null;
        String ActualVal = null;
        String IntermediateVal;
        int intermediateVal;
        int CumulativeValue = 0;
        String CheckForManuplation = null;


        private void button1_Click(object sender, EventArgs e)
        {
            //Numbers
            Button btn = (Button)sender;
            int num = Convert.ToInt32(btn.Text);
            Digit = Digit + btn.Text;
            UpdateTheDisplay();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Operations
            Button btn = (Button)sender;
            AnyManuplation = true;
            Manuplation = btn.Text;
            UpdateTheDisplay();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Showing the result
            AnyManuplation = true;
            Manuplation = "=";
            UpdateTheDisplay();
            textBox2.Text = CumulativeValue.ToString();
        }

        private void UpdateTheDisplay()
        {
            if (AnyManuplation)
            {
                int val1 = Convert.ToInt32(IntermediateVal);
                IntermediateVal = null;
                //IntermediateVal = IntermediateVal;
                if (CheckForManuplation != null)
                {
                    if (CheckForManuplation == "+")
                    {
                        CumulativeValue = intermediateVal + val1;
                    }
                    else if (CheckForManuplation == "-")
                    {
                        CumulativeValue = intermediateVal - val1;
                    }
                    else if (CheckForManuplation == "/")
                    {
                        CumulativeValue = intermediateVal / val1;
                    }
                    else if (CheckForManuplation == "*")
                    {
                        CumulativeValue = intermediateVal * val1;
                    }
                    CheckForManuplation = null;
                }
                if (textBox1.Text.Contains("\n"))
                {
                    ActualVal = textBox1.Text.Replace("\n", "");
                    if (Manuplation != "=")
                    {
                        textBox1.Text = ActualVal + Manuplation + "\n";
                    }
                }
                else
                {
                    textBox1.Text = textBox1.Text + Digit + Manuplation + "\n";
                    CumulativeValue = val1;
                }
                if (Manuplation != null && Manuplation != "=")
                {
                    CheckForManuplation = Manuplation;
                }
                Manuplation = null;
                AnyManuplation = false;
                textBox2.Text = CumulativeValue.ToString();
                //CumulativeValue = CumulativeValue;
            }
            else
            {
                //IntermediateVal = IntermediateVal + Digit;
                //Session["IntermediateVal"] = IntermediateVal;
               // textBox1.Text =  Digit;

                IntermediateVal = IntermediateVal + Digit;
               //IntermediateVal = IntermediateVal;
                textBox1.Text = textBox1.Text + Digit;
                Digit = "";
            }

        }
    }
}