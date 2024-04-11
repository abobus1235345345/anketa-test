using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> answers = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            InitializeTest();
        }

        private void InitializeTest()
        {
            
            answers.Add("Вопрос 1", "Нет ответа");
            answers.Add("Вопрос 2", "Нет ответа");

            
            int y = 10;
            foreach (var pair in answers)
            {
                Label questionLabel = new Label();
                questionLabel.Text = pair.Key;
                questionLabel.Location = new System.Drawing.Point(10, y);
                this.Controls.Add(questionLabel);

                RadioButton radioButton1 = new RadioButton();
                radioButton1.Text = "да";
                radioButton1.Location = new System.Drawing.Point(10, y + 20);
                radioButton1.CheckedChanged += (sender, e) =>
                {
                    if (radioButton1.Checked)
                        answers[pair.Key] = "Правильный ответ";
                };
                this.Controls.Add(radioButton1);

                RadioButton radioButton2 = new RadioButton();
                radioButton2.Text = "нет";
                radioButton2.Location = new System.Drawing.Point(10, y + 40);
                radioButton2.CheckedChanged += (sender, e) =>
                {
                    if (radioButton2.Checked)
                        answers[pair.Key] = "Неправильный ответ";
                };
                this.Controls.Add(radioButton2);

                y += 80; 
            }

            
            Button submitButton = new Button();
            submitButton.Text = "Submit Answers";
            submitButton.Location = new System.Drawing.Point(10, y);
            submitButton.Click += ShowResultsButton_Click;
            this.Controls.Add(submitButton);
        }

        private void ShowResultsButton_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();

            foreach (var answer in answers)
            {
                listBoxResults.Items.Add($"{answer.Key}: {answer.Value}");
            }
        }
    



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
