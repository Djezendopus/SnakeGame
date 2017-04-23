using System;
using System.Media;
using System.Windows.Forms;

namespace Snake_Game
{
    /// <summary>
    /// Форма для вывода текста.
    /// </summary>
    public partial class ShowTextForm : Form
    {
        #region Конструкторы.
        /// <summary>
        /// Загрузка формы при запуске.
        /// </summary>
        /// <param name="text">Текст для вывода.</param>
        public ShowTextForm(string text)
        {
            InitializeComponent();

            tBox.Text = text;            
        }
        #endregion

        #region Методы
        /// <summary>
        /// Событие при нажатии кнопки "Закрыть".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion
    }
}
