using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class InputNameForm : Form
    {

        public InputNameForm()
        {
            InitializeComponent();
        }

        private void fName_Load(object sender, EventArgs e)
        {
            toolTip_tBox_Name.SetToolTip(tBox_Name, "Введите ваше имя\n(не более 16 символов)");
            toolTip_tBox_Name.IsBalloon = true;
        }

        private void btn_Confrime_Click(object sender, EventArgs e)
        {
            GameForm main = this.Owner as GameForm;
            if (main != null)
                if (tBox_Name.Text.Replace(" ", "") == "")
                    MessageBox.Show("Поле имени пустое, введите имя!", "Ошибка ввода имени", MessageBoxButtons.OK);
                else
                {
                    this.DialogResult = DialogResult.OK;
                    main.tmp = tBox_Name.Text;
                    this.Dispose();
                }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tBox_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Confrime_Click(sender, e);
        }
    }
}
