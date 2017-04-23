using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLibrary
{
    /// <summary>
    /// Структура, описывающиая элемент змейки или еду.
    /// </summary>
    public struct SnakeGameElement
    {
        #region Поля и свойства.
        /// <summary>
        /// Координата X.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y.
        /// </summary>
        public int Y { get; set; }
        #endregion

        #region Конструкторы.
        /// <summary>
        /// Создает новый объект класса <see cref="SnakeGameElement"/> с заданными координатами.
        /// </summary>
        /// <param name="X">Координата X.</param>
        /// <param name="Y">Координата Y.</param>
        public SnakeGameElement(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        #endregion
    }
}
