using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculadora.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private String number1;
        private String number2;
        private String operation;
        private List<String> operationsList = new List<string>();

        public Page1()
        {
            InitializeComponent();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            String number = "1";
            write(number);
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            String number = "2";
            write(number);
        }
        private void Button3_Clicked(object sender, EventArgs e)
        {
            String number = "3";
            write(number);
        }
        private void Button4_Clicked(object sender, EventArgs e)
        {
            String number = "4";
            write(number);
        }
        private void Button5_Clicked(object sender, EventArgs e)
        {
            String number = "5";
            write(number);
        }
        private void Button6_Clicked(object sender, EventArgs e)
        {
            String number = "6";
            write(number);
        }
        private void Button7_Clicked(object sender, EventArgs e)
        {
            String number = "7";
            write(number);
        }
        private void Button8_Clicked(object sender, EventArgs e)
        {
            String number = "8";
            write(number);

        }
        private void Button9_Clicked(object sender, EventArgs e)
        {
            String number = "9";
            write(number);
        }
        private void Button0_Clicked(object sender, EventArgs e)
        {
            String number = "0";
            write(number);
        }
        private void ButtonDot_Clicked(object sender, EventArgs e)
        {
            String number = ".";
            write(number);
        }

        private void ButtonC_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            lblOperations.Text = "";
        }

        private void deleteFisrTime(String number)
        {

            lblResult.Text = number;
        }
        private void write(String number)
        {
            if (lblResult.Text != "0")
            {
                lblResult.Text += number;
            }
            else
            {
                deleteFisrTime(number);
            }
        }

        private void ButtonSign_Clicked(object sender, EventArgs e)
        {
            double stringNumber = Convert.ToDouble(lblResult.Text) * -1;
            lblResult.Text = stringNumber.ToString();
        }

        private void ButtonPercent_Clicked(object sender, EventArgs e)
        {
            number1 = lblResult.Text;
            operation = "percent";
            lblOperations.Text += String.Format("{0:00}", number1) + "%";
            operationsList.Add(number1);
            operationsList.Add(operation);
            lblResult.Text = "0";

        }

        private void ButtonDiv_Clicked(object sender, EventArgs e)
        {
            number1 = lblResult.Text;
            operation = "div";
            lblOperations.Text += String.Format("{0:00}", number1) + "/";
            operationsList.Add(number1);
            operationsList.Add(operation);
            lblResult.Text = "0";
        }

        private void ButtonTimes_Clicked(object sender, EventArgs e)
        {
            number1 = lblResult.Text;
            operation = "mult";
            lblOperations.Text += String.Format("{0:00}", number1) + "*";
            operationsList.Add(number1);
            operationsList.Add(operation);
            lblResult.Text = "0";
        }

        private void ButtonMinus_Clicked(object sender, EventArgs e)
        {
            number1 = lblResult.Text;
            operation = "subs";
            lblOperations.Text += String.Format("{0:00}", number1) + "-";
            operationsList.Add(number1);
            operationsList.Add(operation);
            lblResult.Text = "0";
        }

        private void ButtonPlus_Clicked(object sender, EventArgs e)
        {
            number1 = lblResult.Text;
            operation = "sum";
            lblOperations.Text += String.Format("{0:00}", number1) + "+";
            operationsList.Add(number1);
            operationsList.Add(operation);
            lblResult.Text = "0";
        }

        private void ButtonResult_Clicked(object sender, EventArgs e)
        {
            number2 = lblResult.Text;
            lblOperations.Text += number2;
            operationsList.Add(number2);
            lblResult.Text = calculate(operationsList);
        }

        private String calculate(List<String> operationsList)
        {
            double actualNumber = 0;
            for (int i = 0; i < operationsList.Count; i++)
            {

                switch (operationsList[i])
                {
                    case "percent":
                        actualNumber = actualNumber * Convert.ToDouble(operationsList[i + 1]) / 100;
                        i++;
                        break;
                    case "div":
                        if (operationsList[i] == "0")
                        {
                            return "Error";
                        } else
                        {
                            actualNumber = actualNumber / Convert.ToDouble(operationsList[i + 1]);
                        }
                        i++;
                        break;
                    case "mult":
                        actualNumber = actualNumber * Convert.ToDouble(operationsList[i + 1]);
                        i++;
                        break;
                    case "subs":
                        actualNumber = actualNumber - Convert.ToDouble(operationsList[i + 1]);
                        i++;
                        break;
                    case "sum":
                        actualNumber = actualNumber + Convert.ToDouble(operationsList[i + 1]);
                        i++;
                        break;
                    default:
                        actualNumber = Convert.ToDouble(operationsList[i]);
                        break;
                }
            }

            return actualNumber.ToString();
        }
    }
}