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
        private TextBox displayTextBox;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Simple Calculator";
            this.Size = new System.Drawing.Size(300, 400);

            displayTextBox = new TextBox();
            displayTextBox.ReadOnly = true;
            displayTextBox.TextAlign = HorizontalAlignment.Right;
            displayTextBox.Size = new System.Drawing.Size(280, 50);
            displayTextBox.Location = new System.Drawing.Point(10, 10);

            Button[] numberButtons = new Button[10];
            for (int i = 0; i < 10; i++)
            {
                numberButtons[i] = new Button();
                numberButtons[i].Text = i.ToString();
                numberButtons[i].Size = new System.Drawing.Size(60, 60);
                numberButtons[i].Location = new System.Drawing.Point((i % 3) * 70 + 10, (i / 3) * 70 + 70);
                numberButtons[i].Click += NumberButtonClick;
                this.Controls.Add(numberButtons[i]);
            }

            Button addButton = CreateOperationButton("+", 220, 70);
            addButton.Click += OperationButtonClick;

            Button subtractButton = CreateOperationButton("-", 220, 140);
            subtractButton.Click += OperationButtonClick;

            Button multiplyButton = CreateOperationButton("*", 220, 210);
            multiplyButton.Click += OperationButtonClick;

            Button divideButton = CreateOperationButton("/", 220, 280);
            divideButton.Click += OperationButtonClick;

            Button equalsButton = new Button();
            equalsButton.Text = "=";
            equalsButton.Size = new System.Drawing.Size(130, 60);
            equalsButton.Location = new System.Drawing.Point(80, 280);
            equalsButton.Click += EqualsButtonClick;

            this.Controls.Add(displayTextBox);
            this.Controls.Add(addButton);
            this.Controls.Add(subtractButton);
            this.Controls.Add(multiplyButton);
            this.Controls.Add(divideButton);
            this.Controls.Add(equalsButton);
        }

        private Button CreateOperationButton(string text, int x, int y)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new System.Drawing.Size(60, 60);
            button.Location = new System.Drawing.Point(x, y);
            return button;
        }

        private void NumberButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            displayTextBox.Text += button.Text;
        }

        private void OperationButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            displayTextBox.Text += $" {button.Text} ";
        }

        private void EqualsButtonClick(object sender, EventArgs e)
        {
            try
            {
                string expression = displayTextBox.Text;
                var result = new System.Data.DataTable().Compute(expression, "");
                displayTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                displayTextBox.Text = "Error";
            }
        }
    }
}
