using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_7
{
    public partial class Form1 : Form
    {
        /*  Томашевич
         * 
         * а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
         * б) Добавить меню и команду «Играть». При нажатии появляется сообщение,
         *      какое число должен получить игрок. Игрок должен получить это число
         *      за минимальное количество ходов.
         * в) *Добавить кнопку «Отменить», которая отменяет последние ходы.
         *      Используйте обобщенный класс Stack.
         * Вся логика игры должна быть реализована в классе с удвоителем.
*/
        UInt32 commandNum = 0;
        UInt32 numToGuess = 0;
        UInt32 currentNum = 0;

        string answer;

        Stack<ActionBack> stackBack;

        struct ActionBack
        {
            string what; // строковое представление действия

            public ActionBack(string _what) // конструктор для инициализации what
            {
                what = _what;
            }
            public uint StepBack(uint num) // самодействие
            {
                switch(what)
                {
                    case "add_1":
                        num -= 1;
                        break;

                    case "mul_2":
                        num /= 2;
                        break;
                }

                return num;
            }
        }

        public Form1()
        {
            InitializeComponent();

            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            this.Text = "Удвоитель";

            lblNumber.TextChanged += NumCount;

            stackBack = new Stack<ActionBack>();

        }

        private void btns_Action_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            switch(bt.AccessibleName)
            {
                case "add_1":
                    currentNum += 1;
                    break;

                case "mul_2":
                    currentNum *= 2;
                    break;
            }

            lblNumber.Text = currentNum.ToString();
            stackBack.Push(new ActionBack(bt.AccessibleName));

            if (currentNum == numToGuess) MessageBox.Show("Готово");
        }

        private void NumCount(object sender, EventArgs e)
        {
            commandNum++;
            labelCommand.Text = commandNum.ToString();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "0";
            Random rnd = new Random();
            numToGuess = (uint) rnd.Next();

            MessageBox.Show("Число: " + numToGuess.ToString(), "Новая игра");

            labelNumToGuess.Text = numToGuess.ToString();

            uint i = numToGuess;

            uint tryCount = 0;

            answer = "";

            while(i != 0)
            {
                if (i % 2 == 0)
                {
                    i /= 2;
                    answer = "*2 " + answer;
                }
                else
                {
                    i--;
                    answer = "+1 " + answer;
                }
                tryCount++;
            }

            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Минимальное кол-во действий: " +
                tryCount.ToString();
            notifyIcon1.BalloonTipTitle = "Подсказка";
            notifyIcon1.ShowBalloonTip(5);

        }

        private void tipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Комбинация: " + answer;
            notifyIcon1.BalloonTipTitle = "Подсказка";
            notifyIcon1.ShowBalloonTip(5);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "0";
        }

        private void backTo(object sender, EventArgs e)
        {
            if(stackBack.Count == 0)
            {
                MessageBox.Show("Стэк пуст");
                return;
            }
            currentNum = stackBack.Pop().StepBack(currentNum);
            lblNumber.Text = currentNum.ToString();
        }
    }
}
