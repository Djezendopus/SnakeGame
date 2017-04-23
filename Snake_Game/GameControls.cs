using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    /// <summary>
    /// Класс, описывающий клавиши управления игрой.
    /// </summary>
    [Serializable]
    class GameControls
    {
        #region Поля и свойства.
        /// <summary>
        /// Клавиша для задания направления змейки вверх.
        /// </summary>
        public Keys UpKey { get; set; }
        /// <summary>
        /// Клавиша для задания направления змейки вниз.
        /// </summary>
        public Keys DownKey { get; set; }
        /// <summary>
        /// Клавиша для задания направления змейки влево.
        /// </summary>
        public Keys LeftKey { get; set; }
        /// <summary>
        /// Клавиша для включения/выключения сетки на игровом поле.
        /// </summary>
        public Keys GridDrawKey { get; set; }
        /// <summary>
        /// Клавиша для задания направления змейки вправо.
        /// </summary>
        public Keys RightKey { get; set; }
        /// <summary>
        /// Клавиша для паузы игры.
        /// </summary>
        public Keys PauseKey { get; set; }
        /// <summary>
        /// Клавиша для перезапуска игры.
        /// </summary>
        public Keys RestartKey { get; set; }
        /// <summary>
        /// Клавиша для увеличения скорости змейки.
        /// </summary>
        public Keys IncreaseSpeedKey { get; set; }
        /// <summary>
        /// Клавиша для уменьшения скорости змейки.
        /// </summary>
        public Keys ReduceSpeedKey { get; set; }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает экземпляр класса <see cref="GameControls"/> со значениями клавиш по умолчанию.
        /// </summary>
        public GameControls()
        {
            UpKey = Keys.Up;
            DownKey = Keys.Down;
            LeftKey = Keys.Left;
            RightKey = Keys.Right;
            GridDrawKey = Keys.G;
            PauseKey = Keys.Space;
            RestartKey = Keys.Enter;
            IncreaseSpeedKey = Keys.ShiftKey;
            ReduceSpeedKey = Keys.ControlKey;
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представление клавиш управления игрой.
        /// </summary>
        /// <returns>Строковое представление клавиш управления игрой.</returns>
        public override string ToString()
        {
            return "Вверх: " + UpKey.ToString() +
                   "\nВниз: " + DownKey.ToString() +
                   "\nВлево: " + LeftKey.ToString() +
                   "\nВправо: " + RightKey.ToString() +
                   "\nСетка: " + GridDrawKey.ToString() +
                   "\nПауза: " + PauseKey.ToString() +
                   "\nРестарт: " + RestartKey.ToString() +
                   "\nБыстрее: " + IncreaseSpeedKey.ToString() +
                   "\nМедленнее: " + ReduceSpeedKey.ToString();
        }
        #endregion
    }
}
