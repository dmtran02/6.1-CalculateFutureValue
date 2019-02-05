using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Duc Tran
 * Professor Frank Friedman
 * CIS 3309 - Assigment 6.2 // FutureValueCalculator
 * Last Updated: February 4, 2019
 */

namespace FutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Calculates the Future Value using the CalculateFutureValue method that uses monthlyInvestment, months, monthlyInterestRate and futureValue
         * that returns the futureValue value at the end of calculation upon clicking the button.
         */

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
            decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            decimal futureValue = 0m;

            CalculateFutureValue(monthlyInvestment, months, monthlyInterestRate, futureValue);
        }

        /*
         * Method that assists in calculating the futureValue for the application
         * Takes in four parameters: monthlyInvestment, months, monthlyInterestRate and futureValue
         * At the end of calculation, the method focuses on the txtMonthlyInvestment text box.
         */

        private void CalculateFutureValue(decimal monthlyInvestment, int months, decimal monthlyInterestRate, decimal futureValue)
        {
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
                txtFutureValue.Text = futureValue.ToString("c");
                txtMonthlyInvestment.Focus();
            }
        }

        /*
         * Event handler for when the user clicks the exit button.
         * Exits the application upon clicking the button.
         */

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
         * Clears the value in the futureValue text box when one of the three parameters, monthlyInvestment,
         * months and monthlyInterestRate are text-changed.
         */

        private void ClearFutureValue(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
        }
    }
}