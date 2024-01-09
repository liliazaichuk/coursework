using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxFigures.SelectedIndexChanged += (sender, e) => ShowInputForm();
            calculateButton.Click += (sender, e) => CalculateArea();
        }

        private void ShowInputForm()
        {
            inputTextBox.Clear();
            resultLabel.Text = "";

            switch (comboBoxFigures.SelectedItem.ToString())
            {
                case "Квадрат":
                    inputLabel.Text = $"Введiть сторону квадрата:";
                    break;
                case "Коло":
                    inputLabel.Text = $"Введiть радіус кола:";
                    break;

                case "Трикутник":
                    inputLabel.Text = "Введiть три сторони трикутника (через пробіл):";
                    break;

                case "Прямокутник":
                    inputLabel.Text = $"Введiть дві сторони прямокутника (через пробiл):";
                    break;
                case "Овал":
                    inputLabel.Text = $"Введiть два радiуса овала (через пробiл):";
                    break;

                case "Ромб":
                    inputLabel.Text = "Введiть дві діагоналі ромба (через пробiл):";
                    break;

                case "Трапеція":
                    inputLabel.Text = "Введiть нижню основу, верхню основу і висоту (через пробiл):";
                    break;
                case "Правильний многокутник з n кутів":
                    inputLabel.Text = "Введiть кількість кутів і довжину сторони (через пробiл):";
                    break;
            }
        }

        private void CalculateArea()
        {

            double result = 0.0;
            string[] inputValues = inputTextBox.Text.Split(' ');

            switch (comboBoxFigures.SelectedItem.ToString())
            {
                case "Квадрат":
                    if (double.TryParse(inputValues[0], out double side))
                        result = side * side;
                    break;

                case "Трикутник":
                    if (double.TryParse(inputValues[0], out double sideA) &&
                        double.TryParse(inputValues[1], out double sideB) &&
                        double.TryParse(inputValues[2], out double sideC))
                    {
                        double p = (sideA + sideB + sideC) / 2;
                        result = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
                    }
                    break;

                case "Коло":
                    if (double.TryParse(inputValues[0], out double radius))
                        result = Math.PI * radius * radius;
                    break;

                case "Прямокутник":
                    if (double.TryParse(inputValues[0], out double length) &&
                        double.TryParse(inputValues[1], out double width))
                        result = length * width;
                    break;

                case "Овал":
                    if (double.TryParse(inputValues[0], out double radius1) &&
                        double.TryParse(inputValues[1], out double radius2))
                        result = Math.PI * radius1 * radius2;
                    break;

                case "Ромб":
                    if (double.TryParse(inputValues[0], out double diagonal1) &&
                        double.TryParse(inputValues[1], out double diagonal2))
                        result = 0.5 * diagonal1 * diagonal2;
                    break;

                case "Трапеція":
                    if (double.TryParse(inputValues[0], out double base1) &&
                        double.TryParse(inputValues[1], out double base2) &&
                        double.TryParse(inputValues[2], out double height))
                        result = 0.5 * (base1 + base2) * height;
                    break;
                case "Правильний многокутник з n кутів":
                    if (double.TryParse(inputValues[0], out double n) &&
                        double.TryParse(inputValues[1], out double a))
                        result = (n * a * a) / (4 * 1 / Math.Tan((180 / n) * Math.PI / 180));
                    break;
            }

            if (result == 0)
            {
                resultLabel.Text = $"Помилка: некоректно введені дані\n*підказка: не ціле число слід записати через кому";
            }
            else { resultLabel.Text = $"Площа: {result:F2}"; }
        }
    }
}
