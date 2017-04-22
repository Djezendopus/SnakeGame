using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake_Game
{
    /// <summary>
    /// Форма для ввода значения и его передачи в родительскую форму.
    /// </summary>
    public partial class InputNameForm : Form
    {
        #region Конструкторы.
        /// <summary>
        /// Конструктор формы ввода с заданным заголовком и выбором метода ввода.
        /// </summary>
        public InputNameForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Передача значения в родительскую форму с использованием выбранного метода ввода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            GameForm main = this.Owner as GameForm;
            if (main != null)
                //main.playerName = textBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        /// <summary>
        /// Отмена передачи значения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из игры?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Dispose();
            }
        }
        #endregion
    }
}
