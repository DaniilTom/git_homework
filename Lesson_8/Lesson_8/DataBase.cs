using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_8
{
    /*
     * Томашевич
     * 
     * *Используя полученные знания и класс TrueFalse в качестве шаблона,
     * разработать собственную утилиту хранения данных (Например:
     * Дни рождения, Траты, Напоминалка, Английские слова и другие).
     * 
     * */

    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
        }

        private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            if (ab.ShowDialog(this) == DialogResult.OK) ab.Close();

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Int16 key = 0;

            if(MessageBox.Show("Использовать пароль?", "Пароль", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                SetPassword setPas = new SetPassword();
                if (setPas.ShowDialog(this) == DialogResult.OK)
                    key = setPas.Password;
                else
                {
                    MessageBox.Show("Отмена");
                    return;
                }
            }

            if(saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                using (StreamWriter fs = new StreamWriter(saveFileDialog1.FileName))
                {

                    if (key != 0) fs.WriteLine("Encrypted");
                    else fs.WriteLine("NotEncrypted");


                    //dataGridView1.DataSource = ln;

                    foreach(Line line in lineBindingSource)
                    {
                        string encrypted;
                        char[] eng = line.English.ToCharArray();
                        char[] rus = line.Russian.ToCharArray();

                        encrypted = XOREncrypt(eng, key) + "|" + XOREncrypt(rus, key);

                        fs.WriteLine(encrypted);
                    } 
                }   
            }  
        }

        public class Line
        {
            private string eng;
            private string rus;

            public Line(string _eng, string _rus)
            {
                eng = _eng;
                rus = _rus;
            }

            public string English
            {
                get => eng;
                set
                {
                    eng = value;
                }
            }

            public string Russian
            {
                get => rus;
                set
                {
                    rus = value;
                }
            }
        }

        /// <summary>
        /// Осуществляет шифрование через XOR
        /// </summary>
        /// <param name="ch">Последовательность символов</param>
        /// <param name="key">Ключ</param>
        /// <returns>Строка из закодированных символов</returns>
        private string XOREncrypt(char[] ch, short key)
        {
            char[] enCH = new char[ch.Length];

            for(int i = 0; i < ch.Length; i++)
            {
                enCH[i] = (char)(((short)ch[i]) ^ key);
            }

            return new string(enCH);
        }

        private void CheckOnlyAlphabet(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string pattern = "", msg = "";
            if ((string)tb.Tag == "rus")
            {
                pattern = @"[^а-яА-Я]";
                msg = "Только русский алфавит";
            }
            else
            {
                pattern = @"[^a-zA-Z]";
                msg = "Только английский алфавит";
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(tb.Text, pattern))
            {
                MessageBox.Show(msg);
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
            }
        }

        private void addNewPair_Click(object sender, EventArgs e)
        {
            if (textBoxRus.Text != "" || textBoxEng.Text != "")
            {
                lineBindingSource.Add(new Line(textBoxEng.Text, textBoxRus.Text));
                textBoxEng.Text = "";
                textBoxRus.Text = "";
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    //sr.BaseStream.Position = 0;

                    
                    Int16 key = 0;

                    //string t = sr.ReadLine();
                    string[] allData = sr.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    if (allData[0] == "Encrypted")
                    {
                        if (MessageBox.Show("Данные закодированы. Продолжить?", "Пароль", MessageBoxButtons.YesNo) ==
                                DialogResult.Yes)
                        {
                            SetPassword setPas = new SetPassword();
                            if (setPas.ShowDialog(this) == DialogResult.OK)
                                key = setPas.Password;
                            else
                            {
                                MessageBox.Show("Отмена");
                                return;
                            }
                        }

                        else
                        {
                            MessageBox.Show("Отмена");
                            return;
                        }
                    }

                    for(int i = 1; i < allData.Length; i++)
                    {
                        string[] encrypted = allData[i].Split('|');
                        char[] eng = encrypted[0].ToCharArray();
                        char[] rus = encrypted[1].ToCharArray();

                        lineBindingSource.Add(new Line(XOREncrypt(eng, key),
                                                        XOREncrypt(rus, key)));
                    }
                }
            }
        }
    }
}
