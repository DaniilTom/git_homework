using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess
{
    /*  Томашевич
     * 
     * Используя Windows Forms, разработать игру «Угадай число».
     *  Компьютер загадывает число от 1 до 100, а человек пытается его угадать
     *  за минимальное число попыток. Компьютер говорит, больше или меньше 
     *  загаданное число введенного.  
     * a) Для ввода данных от человека используется элемент TextBox;
     * б) **Реализовать отдельную форму c TextBox для ввода числа.
*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        uint numberEntered;
        uint numberToGuess;

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                TextBox tb = (TextBox)sender;
                numberEntered = uint.Parse(tb.Text);

                if (numberEntered == numberToGuess) labelTip.Text = "Вы угадали.";
                else if(numberEntered < numberToGuess) labelTip.Text = "Введенное число меньше.";
                else labelTip.Text = "Введенное число больше.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Text = "";
            Random rnd = new Random();
            numberToGuess = (uint)rnd.Next(0, 100);
        }
    }
}
