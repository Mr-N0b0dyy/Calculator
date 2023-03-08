using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Policy;

namespace Calculator
{
    public partial class SimpleCalculator : Form
    {
        bool optcase = false; // if an operator has been used or not
        double result = 0; // for holding the result
        string opt = ""; //for holding the operator
        string userName = "";
        string surname = "";
        string email = "";
        string age = "";
        bool isSubmitted = false; //Chesks if the information has been submitted or not
        DateTime birthDate= DateTime.MinValue;
        
        public SimpleCalculator()
        {
            InitializeComponent();
            textResult.Text = "0";
        }
        public void nonsubmition() { MessageBox.Show("Please Eneter Your Information Before", "Submition Undone"); }
        public void zeroDivision()
        {
            MessageBox.Show("Can't divided by 0 ", "Divided by Zero");
            textResult.Text = "0";
            opt = "";
            result = 0;
            optcase = false;
        }
        
        private void NumberEvent(object sender, EventArgs e) //handles number buttons
        {
            if (isSubmitted)
            {
                if (textResult.Text == "0" || optcase) // if there aren't any number other than 0 or an operator has been clicked
                    textResult.Clear();
                optcase = false;
                Button btn = (Button)sender;
                textResult.Text += btn.Text;
            }
            else { nonsubmition(); }
        }
        private void OptEvent(object sender, EventArgs e) //handles operator buttons
        {
            if (isSubmitted)
            {
                Button btn = (Button)sender;
                string newOpt = btn.Text; // for holding the new operator
                lblresult.Text = lblresult.Text + " " + textResult.Text + " " + newOpt; // for showing the operation in label box

                switch (opt)
                {
                    case "+": textResult.Text = (result + Double.Parse(textResult.Text)).ToString(); break;
                    case "-": textResult.Text = (result - Double.Parse(textResult.Text)).ToString(); break;
                    case "*": textResult.Text = (result * Double.Parse(textResult.Text)).ToString(); break;
                    case "/":
                        if (textResult.Text != "0")
                        {
                            textResult.Text = (result / Double.Parse(textResult.Text)).ToString();
                        }
                        else
                        {
                            zeroDivision();
                        }
                        break;
                }
                result = Double.Parse(textResult.Text);

                optcase = true;
                opt = newOpt;
            }
            else { nonsubmition(); }



        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            if (isSubmitted) { textResult.Text = "0"; }
            else { nonsubmition(); }
        }

        private void buttonC_Click(object sender, EventArgs e) // Clears everything
        {
            if (isSubmitted)
            {
                textResult.Text = "0";
                opt = "";
                result = 0;
                optcase = false;
            }
            else
            {
                nonsubmition();
            }
        }

        private void buttonEq_Click(object sender, EventArgs e) // for = button
        {
            if (isSubmitted)
            {
                lblresult.Text = "";
                optcase = true; // if an operator has been used or not
                switch (opt)
                {
                    case "+": textResult.Text = (result + Double.Parse(textResult.Text)).ToString(); break;
                    case "-": textResult.Text = (result - Double.Parse(textResult.Text)).ToString(); break;
                    case "*": textResult.Text = (result * Double.Parse(textResult.Text)).ToString(); break;
                    case "/":
                        if (textResult.Text != "0")
                        {
                            textResult.Text = (result / Double.Parse(textResult.Text)).ToString();
                        }
                        else
                        {
                           zeroDivision();
                        }
                        break;
                }
                result = Double.Parse(textResult.Text);
                result = 0;

                opt = "";
            }
            else { nonsubmition(); }

        }

        private void buttonPoint_Click(object sender, EventArgs e) // for . button
        {
            if (isSubmitted) {
                if (textResult.Text == "0") // if multiple zeros added
                {
                    textResult.Text = "0";

                }
                else if (optcase) // if 
                {
                    textResult.Text = "0";
                }
                if (!textResult.Text.Contains(","))
                {
                    textResult.Text += ",";
                }
                optcase = false;
            }
            else{nonsubmition(); }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Takes and stores the information
            userName = UserName.Text;
            surname = SurName.Text;
            email = EMail.Text;
            age = Age.Text;
            birthDate = BirthDate.Value;
            if (userName == "" || surname == "" || email == ""|| age == "" || birthDate == DateTime.Now) //Checks if the information has been written correctly
            {
                MessageBox.Show("Please Eneter Your Information", "Incorrect Submition");
            }
            else
            {
                isSubmitted = true;
            }
        }

        private void BetterCalc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Sends to a better calculator
        {
            Process.Start("https://www.desmos.com/scientific?lang=tr");
            BetterCalc.LinkVisited = true;
        }

        private void Age_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("For showing leave event", "Test");
        }
    }
}
