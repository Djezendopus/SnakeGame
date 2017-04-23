using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    /// <summary>
    /// Структура, описывающая игровое действие и его управляющую клавишу.
    /// </summary>
    public struct GameAction
    {
        #region Поля и свойства.
        /// <summary>
        /// Строка описания действия.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Клавиша, управляющая действием.
        /// </summary>
        public Keys Key { get; internal set; }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает экземпляр класса <see cref="Settings"/> с заданными описанием действия и управляющей клавишей.
        /// </summary>
        /// <param name="name">Строка описания действия.</param>
        /// <param name="key">Клавиша, управляющая действием.</param>
        public GameAction(string name, Keys key)
        {
            Name = name;
            Key = key;
        }
        #endregion

        #region Методы.
        /// <summary>
        /// Строковое представление игрового действия и его управляющей клавиши.
        /// </summary>
        /// <returns>Строковое представление игрового действия и его управляющей клавиши</returns>
        public override string ToString()
        {
            return Name + ": " + Key.ToString();
        }

        /// <summary>
        /// Изменить управляющую клавишу.
        /// </summary>
        /// <param name="key">Клавиша, управляющая действием.</param>
        public void ChangeKey(Keys key)
        {
            Key = key;
        }
        #endregion
    }
}
