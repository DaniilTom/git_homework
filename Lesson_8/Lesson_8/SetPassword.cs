using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_8
{
    public partial class SetPassword : Form
    {
        Int16 password;

        public Int16 Password
        {
            get => password;
        }

        public SetPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // каждый numericUpDown представляет полубайт
            // первые два полубайта UpDown приводятся к старшему байту
            byte topBytes = (byte)((((byte)numeric1.Value) << 4) + ((byte)numeric2.Value));
            // вторые два - к младшему
            byte botBytes = (byte)((((byte)numeric3.Value) << 4) + ((byte)numeric4.Value));

            // затем объединяются в Int16 (short)
            password = BitConverter.ToInt16(new[] { botBytes, topBytes }, 0);


            //password = (Int16)(numeric1.Value + numeric2.Value + numeric2.Value);
            
            this.DialogResult = DialogResult.OK;
        }
    }
}
