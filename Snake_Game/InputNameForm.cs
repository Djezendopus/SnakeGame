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
    /// <summary>
    /// Форма для ввода имени игрока.
    /// </summary>
    public partial class InputNameForm : Form
    {
        #region Конструкторы.
        /// <summary>
        /// Загрузка формы при запуске.
        /// </summary>
        public InputNameForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Событие при нажатии кнопки "Принять".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Событие при нажатии кнопки "Отмена".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Событие при нажатии клавиши клавиатуры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBox_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Confrime_Click(sender, e);
        }
        #endregion
    }
}
